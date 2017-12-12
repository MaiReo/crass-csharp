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
            var crage = new Crage();
            try
            {
                crage.Packages = PackageHost.Current.BuildPackageFromCmdArgs(args);
                crage.OutputDirBase = args.OutputDir;
                crage.PackageContents = crage.Packages.ToDictionary(pkg => pkg, pkg => PluginHost.Current.Plugins
                                    .Where(p => p.Direction == PluginCore.PluginDirection.Extract && p.SupportedExtensionName == pkg.ExtensionName)
                                    .Where(p => (!p.IndexPackageRequired) || (p.IndexPackageRequired && pkg.Index != null))
                                    .FirstOrDefault(p => p.IsMatch(pkg)))
                                    .Where(x => x.Value != null)
                                    .Select(x => x.Value.ExtractContent(x.Key))
                                    .ToList();
            }
            catch (Exception ex)
            {
                if (!args.Quiet)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return crage;
        }


    }
}
