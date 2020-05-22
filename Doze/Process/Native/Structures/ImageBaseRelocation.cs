using System.Runtime.InteropServices;

namespace Doze.Process.Native.Structures
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    internal readonly struct ImageBaseRelocation
    {
        [FieldOffset(0x0000)]
        internal readonly int VirtualAddress;

        [FieldOffset(0x0004)]
        internal readonly int SizeOfBlock;
    }
}
