using Crass.PluginCore;
using System.Collections.Generic;

namespace Crass.Crage
{
    internal interface IPartialPluginHost : IPluginHost
    {
        void Initialize();
    }
}