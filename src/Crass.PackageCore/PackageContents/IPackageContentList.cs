using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Crass.PackageCore
{
    public interface IPackageContentList : IPackageContentCollection, IReadOnlyList<IPackageContent>, IEnumerable<IPackageContent>, IEnumerable
    {
        IPackageContent this[IPackageContentIndex index] { get; }
    }
}
