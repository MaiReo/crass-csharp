using System;
using System.Collections.Generic;
using System.Text;

namespace Crass.PackageCore
{
    public sealed class LazyPackageContent : PackageContent
    {
        private Lazy<byte[]> _lazy_data;
        public LazyPackageContent(Func<byte[]> dataFactory)
        {
            _lazy_data = new Lazy<byte[]>(dataFactory, false);
        }
        public override byte[] Data { get => disposedValue ? throw new InvalidOperationException() : _lazy_data.Value; }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _lazy_data = null;
                GC.Collect();
            }

        }
    }
}
