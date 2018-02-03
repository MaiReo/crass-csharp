using Crass.PackageCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Crass.Crage
{
    internal class DefaultPackageHost : PackageHost, IPackageHost
    {
        public override IEnumerable<IPackage> BuildPackageFromCmdArgs(CrageCmdArgs cmdArgs)
        {
            var list = Enumerable.Empty<IPackage>();
            IPackage index = default(IPackage);
            if (!string.IsNullOrWhiteSpace(cmdArgs.PackageIndex))
            {
                index = new Package(cmdArgs.PackageIndex);
            }
            if (!string.IsNullOrWhiteSpace(cmdArgs.PackagePath))
            {
                var package = new Package(cmdArgs.PackagePath, index);
                list = Enumerable.Repeat(package, 1);
            }
            else if (!string.IsNullOrWhiteSpace(cmdArgs.PackageDir))
            {
                list = Directory.EnumerateFiles(cmdArgs.PackageDir, "*.*",
                    SearchOption.AllDirectories)
                    .Select(path => new Package(path, index));
            }
            return list;
        }
    }
}