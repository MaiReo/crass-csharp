using Crass.PackageCore;
using System.Collections.Generic;

namespace Crass.Crage
{
    public interface IPackageHost
    {
        IEnumerable<IPackage> BuildPackageFromCmdArgs(CrageCmdArgs cmdArgs);
    }
}