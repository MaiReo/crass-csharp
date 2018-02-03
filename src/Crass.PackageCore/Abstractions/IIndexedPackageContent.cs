using System;
using System.Collections.Generic;
using System.Text;

namespace Crass.PackageCore
{
    public interface IIndexedPackageContent : IPackageContent
    {
        int Index { get; }
    }
}
