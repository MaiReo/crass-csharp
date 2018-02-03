using Crass.PackageCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Crass.Crage
{
    public class Crage
    {
        public Crage()
        {
            Packages = Enumerable.Empty<IPackage>();
            PackageContents = Enumerable.Empty<IPackageContentList>();
            OutputDirBase = Path.Combine(Directory.GetCurrentDirectory(), "output_files");
        }

        public IEnumerable<IPackage> Packages { get; private set; }
        private string _outputDirBase;

        public string OutputDirBase
        {
            get => _outputDirBase;
            private set => _outputDirBase = string.IsNullOrWhiteSpace(value) ? _outputDirBase : value;
        }
        public IEnumerable<IPackageContentList> PackageContents { get; private set; }

        public static Crage Process(CrageCmdArgs args)
        {
            var crage = new Crage
            {
                Packages = PackageHost.Current.BuildPackageFromCmdArgs(args),
                OutputDirBase = args.OutputDir
            };
            crage.PackageContents = from package in crage.Packages
                                    let matchedPlugin = (from plugin in PluginHost.Current.Plugins
                                                         where plugin.Direction == PluginCore.PluginDirection.Extract
                                                         && (!plugin.IndexPackageRequired) || (plugin.IndexPackageRequired && package.Index != null)
                                                         select plugin
                                    ).FirstOrDefault(p => p.IsMatch(package))
                                    where matchedPlugin != null
                                    select matchedPlugin.ExtractContent(package);

            return crage;
        }


    }
}
