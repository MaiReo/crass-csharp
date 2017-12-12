using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Crass.PackageCore
{
    public abstract class PackageContentList : IPackageContentList
    {
        public abstract IPackage Package { get; }
        protected abstract IPackageIndex PackageIndex { get; }

        public virtual IPackageContent this[int index] => ContentAt(index);
        public virtual int Count => PackageIndex.Count;

        public IPackageContent this[IPackageContentIndex index] => ContentAt(index);

        public virtual IEnumerator<IPackageContent> GetEnumerator() => new PackageContentEnumerator(this, PackageIndex.GetEnumerator());
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        protected virtual IPackageContent ContentAt(int index)
        {
            var contentIndex = PackageIndex[index];
            var data = Package
                .Pio
                .Seek(contentIndex.Offset, System.IO.SeekOrigin.Begin)
                .ReadBytes(contentIndex.Length);
            return new IndexedPackageContent()
            {
                Data = data,
                Name = contentIndex.Name,
                Package = Package,
                Index = index
            };

        }

        protected virtual IPackageContent ContentAt(IPackageContentIndex contentIndex)
        {
            return new LazyPackageContent(() => Package
                .Pio
                .Seek(contentIndex.Offset, System.IO.SeekOrigin.Begin)
                .ReadBytes(contentIndex.Length))
            {
                Name = contentIndex.Name,
                Package = Package
            };

        }


        public static  IPackageContentList Empty => EmptyPackageContentList.Default;

    }
}
