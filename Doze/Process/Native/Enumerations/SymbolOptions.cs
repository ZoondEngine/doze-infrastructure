using System;

namespace Doze.Process.Native.Enumerations
{
    [Flags]
    internal enum SymbolOptions
    {
        UndecorateName = 0x0002,
        DeferredLoads  = 0x0004
    }
}
