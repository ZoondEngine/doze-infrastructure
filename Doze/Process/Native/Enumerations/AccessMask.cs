using System;

namespace Doze.Process.Native.Enumerations
{
    [Flags]
    internal enum AccessMask
    {
        SpecificRightsAll = 0x00FFFF,
        StandardRightsAll = 0x1F0000
    }
}
