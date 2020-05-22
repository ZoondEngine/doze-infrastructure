using System.Runtime.InteropServices;

namespace Doze.Process.Native.Structures
{
    [StructLayout(LayoutKind.Explicit, Size = 24)]
    internal readonly struct ImageTlsDirectory32
    {
        [FieldOffset(0x000C)]
        internal readonly int AddressOfCallbacks;
    }

    [StructLayout(LayoutKind.Explicit, Size = 40)]
    internal readonly struct ImageTlsDirectory64
    {
        [FieldOffset(0x0018)]
        internal readonly long AddressOfCallbacks;
    }
}
