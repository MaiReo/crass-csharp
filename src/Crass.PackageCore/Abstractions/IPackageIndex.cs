using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Crass.PackageCore
{
    public interface IPackageIndex : IReadOnlyList<IPackageContentIndex>, IReadOnlyCollection<IPackageContentIndex>, IEnumerable<IPackageContentIndex>, IEnumerable
    {
    }
}
