using Doze.Process.Native.Enumerations;

namespace Doze.Process.PortableExecutable.Structures
{
    internal sealed class BaseRelocation
    {
        internal int Offset { get; }

        internal BaseRelocationType Type { get; }

        internal BaseRelocation(int offset, BaseRelocationType type)
        {
            Offset = offset;
            Type = type;
        }
    }
}
