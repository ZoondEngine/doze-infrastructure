using System.Runtime.InteropServices;

namespace Doze.Process.Native.Structures
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    internal struct UnicodeString32
    {
        [FieldOffset(0x0000)]
        internal short Length;

        [FieldOffset(0x0002)]
        internal short MaximumLength;

        [FieldOffset(0x0004)]
        internal int Buffer;
    }

    [StructLayout(LayoutKind.Explicit, Size = 16)]
    internal struct UnicodeString64
    {
        [FieldOffset(0x0000)]
        internal short Length;

        [FieldOffset(0x0002)]
        internal short MaximumLength;

        [FieldOffset(0x0008)]
        internal long Buffer;
    }
}
