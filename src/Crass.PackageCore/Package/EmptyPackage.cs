using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Crass.PackageCore
{
    internal sealed class EmptyPackage : IPackage
    {
        public IPackage Index { get; set; }

        public string Name => string.Empty;

        public string FullPath => string.Empty;

        public string Path => string.Empty;

        public string ExtensionName => string.Empty;


        public IPackage Parent => null;

        public IPackageResource PkgRes => null;

        static EmptyPackage()
        {
            Default = new EmptyPackage();
        }
        public static readonly IPackage Default;

        public void Dispose()
        {
        }

        public IPackage Seek(long offset, SeekOrigin origin)
        => this;

        public byte[] ReadBytes(int count)
            => new byte[0];

        public long GetLength()
        => 0;
    }
}
