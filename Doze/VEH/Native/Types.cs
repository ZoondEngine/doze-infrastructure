using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Doze.VectoredExceptions.Native
{
    public enum VEH : long
    {
        EXCEPTION_CONTINUE_SEARCH = 0,
        EXCEPTION_EXECUTE_HANDLER = 1,
        EXCEPTION_CONTINUE_EXECUTION = -1
    }

    public delegate VEH PVECTORED_EXCEPTION_HANDLER(ref EXCEPTION_POINTERS exceptionPointers);

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct EXCEPTION_POINTERS
    {
        public EXCEPTION_RECORD* ExceptionRecord;
        public IntPtr Context;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct EXCEPTION_RECORD
    {
        public uint ExceptionCode;
        public uint ExceptionFlags;
        public EXCEPTION_RECORD* ExceptionRecord;
        public IntPtr ExceptionAddress;
        public uint NumberParameters;
        public IntPtr* ExceptionInformation;
    }
}
