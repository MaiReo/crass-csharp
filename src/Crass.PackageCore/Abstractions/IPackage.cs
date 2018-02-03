using System;
using System.IO;

namespace Crass.PackageCore
{
    public interface IPackage : IDisposable
    {
        IPackage Index { get; set; }

        string Name { get; }

        string FullPath { get; }

        string Path { get; }

        string ExtensionName { get; }

        IPackage Parent { get; }

        IPackageResource PkgRes { get; }

        IPackage Seek(long offset, SeekOrigin origin);

        byte[] ReadBytes(int count);

        long GetLength();
    }
}
