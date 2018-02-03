using System;
using System.Collections.Generic;
using System.Text;

namespace Crass.PackageCore
{
    public class IndexedPackageContent : PackageContent, IIndexedPackageContent
    {
        public int Index { get; set; }
    }
}
