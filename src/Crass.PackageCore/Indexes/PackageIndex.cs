using System;
using System.Collections.Generic;
using System.Text;

namespace Crass.PackageCore
{
    public sealed class PackageIndex : List<IPackageContentIndex>, IPackageIndex
    {
        static PackageIndex()=> Empty = new PackageIndex();

        public PackageIndex()
        {
        }

        public PackageIndex(IEnumerable<IPackageContentIndex> collection) : base(collection)
        {
        }

        public static readonly IPackageIndex Empty;
    }
}
