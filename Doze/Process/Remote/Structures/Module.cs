using Doze.Process.PortableExecutable;
using System;
using System.IO;

namespace Doze.Process.Remote.Structures
{
    internal sealed class Module
    {
        internal IntPtr BaseAddress { get; }

        internal string Name { get; }

        internal Lazy<PeImage> PeImage { get; }

        internal Module(IntPtr baseAddress, string name, string filePath)
        {
            BaseAddress = baseAddress;

            Name = name;

            PeImage = new Lazy<PeImage>(() => new PeImage(File.ReadAllBytes(filePath)));
        }
    }
}
