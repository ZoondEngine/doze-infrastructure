﻿using System.Runtime.InteropServices;

namespace Doze.Process.Native.Structures
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    internal struct ListEntry32
    {
        [FieldOffset(0x0000)]
        internal int Flink;

        [FieldOffset(0x0004)]
        internal int Blink;
    }

    [StructLayout(LayoutKind.Explicit, Size = 16)]
    internal struct ListEntry64
    {
        [FieldOffset(0x0000)]
        internal long Flink;

        [FieldOffset(0x0008)]
        internal long Blink;
    }
}
