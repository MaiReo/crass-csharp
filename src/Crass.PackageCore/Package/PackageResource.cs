using System;
using System.Collections.Generic;
using System.Text;

namespace Crass.PackageCore
{
    public class PackageResource: IPackageResource
    {
        public byte[] RawData { get; set; }
        public byte[] ActualData { get; set; }
    }
}
