using Crass.PackageCore;
using Crass.PluginCore;
using System;
using System.Collections.Generic;
using System.Composition;
using System.IO;
using System.Linq;

namespace Crass.Plugin.ARCGameEngine
{
    [PluginMetadata("ARC Software Laboratory", "ARCGameEngine", ".ALF .BIN .AGF",
        "0.9.8", "痴漢公賊", "2009-5-22 23:30",
        default(string), AcuiAttributeLevel.ACUI_ATTRIBUTE_LEVEL_DEVELOP)]
    [Export(typeof(ICuiPlugin))]
    public class ALFCuiPlugin : ICuiPlugin
    {
        public PluginDirection Direction { get; }

        public string SupportedExtensionName => ".ALF";

        public bool IndexPackageRequired => true;

        public IPackageContentList ExtractContent(IPackage package)
        {
            if (!IsMatchALF(package)) return PackageContentList.Empty;
            if (!TryExtractIndex(package, out var index)) return PackageContentList.Empty;
            return new ALFPackageContentList(package, index);
        }

        public bool IsMatch(IPackage package)
        {
            return IsMatchALF(package);
        }

        private bool IsMatchALF(IPackage package)
        {
            if (package.Index == null)
            {
                return false;
            }

            package.Index.Pio.Seek(0, SeekOrigin.Begin);

            var magic = new string(package.Index.Pio.ReadBytes(4).Select(b => (char)(b)).ToArray());

            if (magic.IsNotIn("S3IC", "S3IN", "S4IC", "S4IN"))
            {
                return false;
            }
            var version = new string(package.Index.Pio.ReadBytes(4).Select(b => (char)(b)).ToArray());

            const string check = "000 ";
            int i;
            for (i = 0; i < check.Length; i++) if (version[i] < check[i]) break;
            if (i != 4)
            {
                return false;
            }

            return true;

        }

        private bool TryExtractIndex(IPackage package, out IPackageIndex packageIndex)
        {
            packageIndex = null;
            if (package.Index == null)
            {
                return false;
            }
            packageIndex = IndexExtractor.ExtractIndex(package);
            return packageIndex != null;
        }
    }
}
