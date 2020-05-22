﻿using Doze.Process.Native.Enumerations;
using Doze.Process.Native.Handles;
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace Doze.Process.Native.Imports
{
    internal static class Ntdll
    {
        [DllImport("ntdll.dll")]
        internal static extern NtStatus NtCreateThreadEx(out SafeWin32Handle threadHandle, AccessMask accessMask, IntPtr objectAttributes, SafeProcessHandle processHandle, IntPtr startAddress, IntPtr startParameter, ThreadCreationFlags flags, IntPtr zeroBits, int stackSize, int maximumStackSize, IntPtr attributeList);

        [DllImport("ntdll.dll")]
        internal static extern NtStatus NtQueryInformationProcess(SafeProcessHandle processHandle, ProcessInformationClass processInformationClass, ref byte processInformation, int processInformationLength, out int returnLength);

        [DllImport("ntdll.dll")]
        internal static extern int RtlNtStatusToDosError(NtStatus ntStatus);
    }
}
