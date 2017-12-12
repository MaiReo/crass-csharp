using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Crass.Crage
{
    public static class CrageExtensions
    {
        public static Crage PrintContent(this Crage crage)
        {
            if (crage?.PackageContents == null) return crage;

            foreach (var contentList in crage.PackageContents)
                foreach (var content in contentList)
                {
                    LogHelper.Verbose($"{content.Package.Name}:{content.Name}");
                    LogHelper.Verbose(Environment.NewLine);
                }
            return crage;
        }
        public static Crage SaveContent(this Crage crage, CrageCmdArgs cmdArgs)
        {
            if (crage == null) return crage;
            crage.OutputDirBase.EnsureDirectoryIsCreated();

            foreach (var contentList in crage.PackageContents)
                using (contentList.Package)
                {
                    LogHelper.InfoLine($"Package:{contentList.Package.Name},Content Count:{contentList.Count}");

                    for (var i = 0; i < contentList.Count; i++)
                        using (var content = contentList[i])
                        {
                            LogHelper.Info($"Saving: {i + 1}/{contentList.Count}");

                            var packageNameWithoutExt = Path.GetFileNameWithoutExtension(content.Package.Path);
                            var targetDir = Path.Combine(crage.OutputDirBase, packageNameWithoutExt);
                            targetDir.EnsureDirectoryIsCreated();
                            var targetPath = Path.Combine(targetDir, content.Name);
                            File.WriteAllBytes(targetPath, content.Data);

                            LogHelper.Verbose($" : {content.Package.Name}->{content.Name} > {targetPath}");
                            LogHelper.InfoLine();
                        }
                }
            return crage;
        }
    }
}
