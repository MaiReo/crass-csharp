using System;
using System.Reflection;

namespace Crass.PluginCore
{
    public static class PluginCoreExtensions
    {
        public static IPluginMetadata GetMetadata(this IPlugin plugin)
        {
            return plugin?.GetType()?.GetCustomAttribute<PluginMetadataAttribute>();
        }
    }
}
