using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Crass.PackageCore
{
    public interface IPackageContentCollection : IReadOnlyCollection<IPackageContent>,IEnumerable<IPackageContent>, IEnumerable
    {
        IPackage Package { get; }
    }
}
