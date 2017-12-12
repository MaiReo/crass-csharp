using Crass.PluginCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
namespace Crass.Crage
{
    internal class PluginHost : IPluginHost
    {
        public IEnumerable<IPlugin> Plugins { get; private set; }

        private static IPluginHost New()
        {
            var pluginHost = new PluginHost();
            var pluginHosts = typeof(PluginHost).Assembly.DefinedTypes
                .Where(type => typeof(IPartialPluginHost).IsAssignableFrom(type))
                .Select(type => type.GetConstructor(Type.EmptyTypes)?.Invoke(new object[0]))
                .Where(x => x != null)
                .OfType<IPartialPluginHost>()
                .ToList();
            pluginHosts.ForEach(h => h.Initialize());
            pluginHost.Plugins = pluginHosts.SelectMany(ph => ph.Plugins);
            return pluginHost;
        }
        static PluginHost()
        {
            Current = New();
        }
        internal static IPluginHost Current { get; private set; }

    }
}
