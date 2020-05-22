using System.Runtime.InteropServices;

namespace Doze.Process.Native.Structures
{
    [StructLayout(LayoutKind.Explicit, Size = 28)]
    internal readonly struct ApiSetNamespace
    {
        [FieldOffset(0x000C)]
        internal readonly int Count;
                       
        [FieldOffset(0x0010)]
        internal readonly int EntryOffset;
    }
}
