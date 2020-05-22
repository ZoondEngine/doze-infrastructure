using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Tests.Tests.InjectionDetail
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

        public static LargeInteger FromDateTime(DateTime dt)
        {
            try
            {
                var managedFileTime = dt.ToFileTime();

                return new LargeInteger
                {
                    LowPart = (uint)managedFileTime,
                    HighPart = (int)managedFileTime >> 32
                };
            }
            catch
            {
                return Zero;
            }
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
