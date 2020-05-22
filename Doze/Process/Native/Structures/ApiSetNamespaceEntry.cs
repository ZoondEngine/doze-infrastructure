using System.Runtime.InteropServices;

namespace Doze.Process.Native.Structures
{
    [StructLayout(LayoutKind.Explicit, Size = 24)]
    internal readonly struct ApiSetNamespaceEntry
    {
        [FieldOffset(0x0004)]
        internal readonly int NameOffset;

        [FieldOffset(0x0008)]
        internal readonly int NameLength;

        [FieldOffset(0x0010)]
        internal readonly int ValueOffset;
    }
}
