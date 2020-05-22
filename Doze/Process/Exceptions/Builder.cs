using Doze.Process.Native.Enumerations;
using Doze.Process.Native.Imports;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Doze.Process.Exceptions
{
    internal static class ExceptionBuilder
    {
        internal static ApplicationException BuildRemoteRoutineCallException(string routineDescription)
        {
            return new ApplicationException($"Failed to call {routineDescription} in the remote process");
        }

        internal static Win32Exception BuildWin32Exception(string routineName)
        {
            var errorCode = Marshal.GetLastWin32Error();

            return new Win32Exception(errorCode, $"Failed to call {routineName} with error code {errorCode}");
        }

        internal static Win32Exception BuildWin32Exception(string routineName, NtStatus ntStatus)
        {
            var errorCode = Ntdll.RtlNtStatusToDosError(ntStatus);

            return new Win32Exception(errorCode, $"Failed to call {routineName} with error code {errorCode}");
        }
    }
}
