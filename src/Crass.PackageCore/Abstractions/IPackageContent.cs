using System;
using System.Collections.Generic;
using System.Text;

namespace Crass.PackageCore
{
    public interface IPackageContent:IDisposable
    {
        IPackage Package { get; }
        string Name { get; }
        byte[] Data { get; }
        
    }
}
