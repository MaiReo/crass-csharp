using System;
using System.Collections.Generic;
using System.Text;
using System.Composition;
using System.IO;
using System.Linq;
using Crass.PluginCore;
using System.Composition.Hosting;
using System.Reflection;
using System.Runtime.Loader;

namespace Crass.Crage
{
    public class CuiPluginHost : IPluginHost, IPartialPluginHost
    {
        public CuiPluginHost()
        {
            Plugins = Enumerable.Empty<IPlugin>();
        }
        [ImportMany]
        public IEnumerable<IPlugin> Plugins { get; set; }

        public const string PluginDir = "cui";

        public void Initialize()
        {
            var asmFiles = Enumerable.Empty<string>();
            try
            {
                var baseDir = AppDomain.CurrentDomain.BaseDirectory;
                var asmDir = Path.Combine(baseDir, PluginDir);
                asmFiles = Directory.EnumerateFiles(asmDir, "*.dll", SearchOption.TopDirectoryOnly);
            }
            catch (DirectoryNotFoundException)
            {
                return;
            }
            var assemblies = new HashSet<Assembly>();
            foreach (var fullPath in asmFiles)
            {
                try
                {
                    assemblies.Add(Assembly.LoadFile(fullPath));
                }
                catch (FileLoadException)
                {
                }
                catch (FileNotFoundException)
                {
                }
                catch (BadImageFormatException)
                {
                }
            }
            var configuration = new ContainerConfiguration().WithAssemblies(assemblies);
            using (var container = configuration.CreateContainer())
            {
                Plugins = container.GetExports<ICuiPlugin>();
            }
        }
    }
}
