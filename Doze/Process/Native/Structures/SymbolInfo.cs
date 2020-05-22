using System.Runtime.InteropServices;

namespace Doze.Process.Native.Structures
{
    [StructLayout(LayoutKind.Explicit, Size = 88)]
    internal struct SymbolInfo
    {
        [FieldOffset(0x0000)]
        internal int SizeOfStruct;

        [FieldOffset(0x0038)]
        internal long Address;

        [FieldOffset(0x0050)]
        internal int MaxNameLen;
    }
}
