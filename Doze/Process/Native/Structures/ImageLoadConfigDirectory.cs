using System.Runtime.InteropServices;

namespace Doze.Process.Native.Structures
{
    [StructLayout(LayoutKind.Explicit, Size = 164)]
    internal readonly struct ImageLoadConfigDirectory32
    {
        [FieldOffset(0x003C)]
        internal readonly int SecurityCookie;
    }

    [StructLayout(LayoutKind.Explicit, Size = 264)]
    internal readonly struct ImageLoadConfigDirectory64
    {
        [FieldOffset(0x0058)]
        internal readonly long SecurityCookie;
    }
}
