﻿using Doze.Process.Exceptions;
using Doze.Process.Invoker;
using Doze.Process.Invoker.Structures;
using Doze.Process.Native.Enumerations;
using Doze.Process.Native.Imports;
using Doze.Process.PortableExecutable.Structures;
using Doze.Process.Remote.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Process
{
    internal sealed class ProcessAccessor
    {
        internal List<Module> Modules { get; }

        internal System.Diagnostics.Process Process { get; }

        private readonly PebAccessor _pebAccessor;

        internal ProcessAccessor(System.Diagnostics.Process process)
        {
            _pebAccessor = new PebAccessor(process);

            Modules = _pebAccessor.ReadModuleEntries().ToList();

            Process = process;
        }

        internal TStructure CallRoutine<TStructure>(CallingConvention callingConvention, IntPtr functionAddress, params long[] parameters) where TStructure : unmanaged
        {
            // Write the shellcode used to perform the function call into a buffer

            var returnBuffer = Process.AllocateMemory(Unsafe.SizeOf<TStructure>(), ProtectionType.ReadWrite);

            var routineDescriptor = new RoutineDescriptor(Process.GetArchitecture(), callingConvention, functionAddress, parameters, returnBuffer);

            var shellcode = Assembler.AssembleRoutine(routineDescriptor);

            var shellcodeBuffer = Process.AllocateMemory(shellcode.Length, ProtectionType.ExecuteReadWrite);

            Process.WriteMemory(shellcodeBuffer, shellcode);

            // Create a thread to execute the shellcode

            var ntStatus = Ntdll.NtCreateThreadEx(out var threadHandle, AccessMask.SpecificRightsAll | AccessMask.StandardRightsAll, IntPtr.Zero, Process.SafeHandle, shellcodeBuffer, IntPtr.Zero, ThreadCreationFlags.HideFromDebugger | ThreadCreationFlags.SkipThreadAttach, IntPtr.Zero, 0, 0, IntPtr.Zero);

            if (ntStatus != NtStatus.Success)
            {
                throw ExceptionBuilder.BuildWin32Exception("NtCreateThreadEx", ntStatus);
            }

            if (Kernel32.WaitForSingleObject(threadHandle, int.MaxValue) == -1)
            {
                throw ExceptionBuilder.BuildWin32Exception("WaitForSingleObject");
            }

            threadHandle.Dispose();

            Process.FreeMemory(shellcodeBuffer);

            try
            {
                return Process.ReadStructure<TStructure>(returnBuffer);
            }

            finally
            {
                Process.FreeMemory(returnBuffer);
            }
        }

        internal IntPtr GetFunctionAddress(string moduleName, string functionName)
        {
            // Find the exported function by name

            var functionModule = Modules.First(module => module.Name.Equals(moduleName, StringComparison.OrdinalIgnoreCase));

            var exportedFunction = functionModule.PeImage.Value.ExportDirectory.Value.ExportedFunctions.First(function => function.Name.Equals(functionName, StringComparison.OrdinalIgnoreCase));

            return GetFunctionAddress(functionModule, exportedFunction);
        }

        internal IntPtr GetFunctionAddress(string moduleName, int functionOrdinal)
        {
            // Find the exported function by ordinal

            var functionModule = Modules.First(module => module.Name.Equals(moduleName, StringComparison.OrdinalIgnoreCase));

            var exportedFunction = functionModule.PeImage.Value.ExportDirectory.Value.ExportedFunctions.First(function => function.Ordinal == functionOrdinal);

            return GetFunctionAddress(functionModule, exportedFunction);
        }

        internal string ResolveDllName(string dllName)
        {
            if (dllName.StartsWith("api-ms") || dllName.StartsWith("ext-ms"))
            {
                return _pebAccessor.ApiSetMappings.Value[dllName];
            }

            return dllName;
        }

        internal void RefreshModules()
        {
            Modules.Clear();

            Modules.AddRange(_pebAccessor.ReadModuleEntries());
        }

        private IntPtr GetFunctionAddress(Module module, ExportedFunction exportedFunction)
        {
            // Determine if the function is forwarded to another function

            if (exportedFunction.ForwarderString is null)
            {
                return module.BaseAddress + exportedFunction.Offset;
            }

            // Get the module and function that the function is forwarded to

            var forwardedData = exportedFunction.ForwarderString.Split('.');

            if (forwardedData[0].StartsWith("api-ms") || forwardedData[0].StartsWith("ext-ms"))
            {
                return module.BaseAddress + exportedFunction.Offset;
            }

            var forwardedModule = ResolveDllName($"{forwardedData[0]}.dll");

            var forwardedFunction = forwardedData[1];

            return GetFunctionAddress(forwardedModule, forwardedFunction);
        }
    }
}
