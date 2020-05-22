using Doze.Process.Native.Imports;
using Microsoft.Win32.SafeHandles;

namespace Doze.Process.Native.Handles
{
    internal sealed class SafeWin32Handle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeWin32Handle() : base(true) { }

        protected override bool ReleaseHandle()
        {
            return Kernel32.CloseHandle(handle);
        }
    }
}
