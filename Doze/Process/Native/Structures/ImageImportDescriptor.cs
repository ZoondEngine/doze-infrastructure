using System.Runtime.InteropServices;

namespace Doze.Process.Native.Structures
{
    [StructLayout(LayoutKind.Explicit, Size = 20)]
    internal readonly struct ImageImportDescriptor
    {
        [FieldOffset(0x0000)]
        internal readonly int OriginalFirstThunk;

        [FieldOffset(0x000C)]
        internal readonly int Name;

        [FieldOffset(0x0010)]
        internal readonly int FirstThunk;
    }
}
