using Crass.PackageCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crass.PluginCore
{
    public interface IPlugin
    {
        PluginDirection Direction { get; }

        string SupportedExtensionName { get; }

        bool IsMatch(IPackage package);

        bool IndexPackageRequired { get; }

        IPackageContentList ExtractContent(IPackage package);
    }
}
