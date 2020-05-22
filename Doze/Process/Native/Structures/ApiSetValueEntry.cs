using System.Runtime.InteropServices;

namespace Doze.Process.Native.Structures
{
    [StructLayout(LayoutKind.Explicit, Size = 20)]
    internal readonly struct ApiSetValueEntry
    {
        [FieldOffset(0x000C)]
        internal readonly int ValueOffset;

        [FieldOffset(0x0010)]
        internal readonly int ValueCount;
    }
}
