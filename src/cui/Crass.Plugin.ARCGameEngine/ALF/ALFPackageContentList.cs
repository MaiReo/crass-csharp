using Crass.PackageCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crass.Plugin.ARCGameEngine
{
    public class ALFPackageContentList : PackageContentList
    {
        public ALFPackageContentList(IPackage package, IPackageIndex index)
        {
            this.Package = package;
            this.PackageIndex = index;
        }
        public override IPackage Package { get; }

        protected override IPackageIndex PackageIndex { get; }
    }
}
