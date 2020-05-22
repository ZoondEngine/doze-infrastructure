using System.Runtime.InteropServices;

namespace Doze.Process.Native.Structures
{
    [StructLayout(LayoutKind.Explicit, Size = 40)]
    internal readonly struct ImageExportDirectory
    {
        [FieldOffset(0x0010)]
        internal readonly int Base;

        [FieldOffset(0x0018)]
        internal readonly int NumberOfNames;

        [FieldOffset(0x001C)]
        internal readonly int AddressOfFunctions;

        [FieldOffset(0x0020)]
        internal readonly int AddressOfNames;

        [FieldOffset(0x0024)]
        internal readonly int AddressOfNameOrdinals;
    }
}
