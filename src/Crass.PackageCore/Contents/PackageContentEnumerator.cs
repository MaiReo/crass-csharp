using System.Collections;
using System.Collections.Generic;

namespace Crass.PackageCore
{
    public class PackageContentEnumerator : IEnumerator<IPackageContent>
    {
        private readonly IPackageContentList _packageContentList;
        private readonly IEnumerator<IPackageContentIndex> _packageContentEnumerator;

        public PackageContentEnumerator(IPackageContentList packageContentList, IEnumerator<IPackageContentIndex> packageContentEnumerator)
        {
            this._packageContentList = packageContentList;
            this._packageContentEnumerator = packageContentEnumerator;
        }

        public IPackageContent Current => _packageContentList[_packageContentEnumerator.Current];

        object IEnumerator.Current => Current;

        public bool MoveNext() => _packageContentEnumerator.MoveNext();

        public void Reset() => _packageContentEnumerator.Reset();

        public void Dispose() => _packageContentEnumerator.Dispose();

        public static IEnumerator<IPackageContent> Empty => EmptyPackageContentEnumerator.Default;
    }
}
