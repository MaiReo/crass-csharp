using Crass.PackageCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crass.Crage
{
    public abstract class PackageHost: IPackageHost
    {
        static PackageHost()
        {
            Current = new DefaultPackageHost();
        }
        public static IPackageHost Current { get; private set; }

        public abstract IEnumerable<IPackage> BuildPackageFromCmdArgs(CrageCmdArgs cmdArgs);
    }
}
