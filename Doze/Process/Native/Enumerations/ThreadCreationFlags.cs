using System;

namespace Doze.Process.Native.Enumerations
{
    [Flags]
    internal enum ThreadCreationFlags
    {
        SkipThreadAttach = 0x0002,
        HideFromDebugger = 0x0004
    }
}
