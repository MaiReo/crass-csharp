using System;
using System.Collections.Generic;
using System.Text;

namespace Crass.PackageCore
{
    public interface IPackageResource
    {
        byte[] RawData { get; set; }
        byte[] ActualData { get; set; }
    }
}
