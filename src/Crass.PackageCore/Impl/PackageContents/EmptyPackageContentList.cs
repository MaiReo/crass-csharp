using System.Collections;
using System.Collections.Generic;

namespace Crass.PackageCore
{
    internal sealed class EmptyPackageContentList : IPackageContentList
    {
        private EmptyPackageContentList() { }
        static EmptyPackageContentList() => Default = new EmptyPackageContentList();

        public IPackageContent this[IPackageContentIndex index] => PackageContent.Empty;

        public IPackageContent this[int index] => PackageContent.Empty;

        public IPackage Package => Crass.PackageCore.Package.Empty;

        public int Count => Empty;

        public const int Empty = 0;

        public IEnumerator<IPackageContent> GetEnumerator() => PackageContentEnumerator.Empty;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        public static IPackageContentList Default;
    }
}