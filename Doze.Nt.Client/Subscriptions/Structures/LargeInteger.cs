using System.Runtime.InteropServices;

namespace Doze.Nt.Client.Subscriptions.Structures
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct LargeInteger
    {
        [FieldOffset(0)] 
        public ulong QuadPart;

        [FieldOffset(0)] 
        public uint LowPart;

        [FieldOffset(4)] 
        public int HighPart;

        public static LargeInteger FromFileTime(FileTime ft)
        {
            return new LargeInteger
            {
                LowPart = (uint)ft.DateTimeLow,
                HighPart = ft.DateTimeHigh
            };
        }

        public static bool operator ==(LargeInteger li1, LargeInteger li2)
        {
            return (li1.QuadPart == li2.QuadPart) 
                 & (li1.LowPart == li2.LowPart) 
                 & (li1.HighPart == li2.HighPart);
        }
        public static bool operator !=(LargeInteger li1, LargeInteger li2)
            => !(li1 == li2);

        public static LargeInteger Zero = new LargeInteger() { HighPart = 0, LowPart = 0, QuadPart = 0 };
    }
}
