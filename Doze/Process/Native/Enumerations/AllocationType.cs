using System;

namespace Doze.Process.Native.Enumerations
{
    [Flags]
    internal enum AllocationType
    {
        Commit  = 0x1000,
        Reserve = 0x2000
    }
}
