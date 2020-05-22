using System.Runtime.InteropServices;

namespace Doze.Process.Native.Structures
{
    [StructLayout(LayoutKind.Explicit, Size = 32)]
    internal readonly struct ImageDelayLoadDescriptor
    {
        [FieldOffset(0x0004)]
        internal readonly int DllNameRva;

        [FieldOffset(0x000C)]
        internal readonly int ImportAddressTableRva;

        [FieldOffset(0x0010)]
        internal readonly int ImportNameTableRva;
    }
}
