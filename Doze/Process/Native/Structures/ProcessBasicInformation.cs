using System.Runtime.InteropServices;

namespace Doze.Process.Native.Structures
{
    [StructLayout(LayoutKind.Explicit, Size = 48)]
    internal readonly struct ProcessBasicInformation64
    {
        [FieldOffset(0x0008)]
        internal readonly long PebBaseAddress;
    }
}
