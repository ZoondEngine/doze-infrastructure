using System;

namespace Doze.Process.Native.Enumerations
{
    [Flags]
    internal enum ProtectionType
    {
        NoAccess         = 0x0001,
        ReadOnly         = 0x0002,
        ReadWrite        = 0x0004,
        Execute          = 0x0010,
        ExecuteRead      = 0x0020,
        ExecuteReadWrite = 0x0040,
        NoCache          = 0x0200
    }
}
