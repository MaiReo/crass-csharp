using System.Collections;
using System.Collections.Generic;

namespace Crass.PackageCore
{
    internal sealed class EmptyPackageContentEnumerator : IEnumerator<IPackageContent>
    {
        private EmptyPackageContentEnumerator() { }

        public IPackageContent Current => PackageContent.Empty;

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext() => false;

        public void Reset()
        {

        }

        static EmptyPackageContentEnumerator() => Default = new EmptyPackageContentEnumerator();

        public static IEnumerator<IPackageContent> Default;
    }
}