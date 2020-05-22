using System;

namespace Doze.Process.Remote.Structures
{
    internal sealed class PebData
    {
        internal IntPtr ApiSetMap { get; }

        internal IntPtr Loader { get; }

        internal PebData(IntPtr apiSetMap, IntPtr loader)
        {
            ApiSetMap = apiSetMap;
            Loader = loader;
        }
    }
}
