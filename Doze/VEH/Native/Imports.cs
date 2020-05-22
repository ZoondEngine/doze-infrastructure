using System;
using System.Runtime.InteropServices;

namespace Doze.VectoredExceptions.Native
{
    public static class Msvcrt
    {
        [DllImport("msvcrt.dll", SetLastError = true)]
        public static extern int _resetstkoflw();
    }

    public static class Kernel32
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr AddVectoredExceptionHandler(IntPtr FirstHandler, PVECTORED_EXCEPTION_HANDLER VectoredHandler);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr RemoveVectoredExceptionHandler(IntPtr InstalledHandler);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern unsafe bool SetThreadStackGuarantee(int* StackSizeInBytes);
    }
}
