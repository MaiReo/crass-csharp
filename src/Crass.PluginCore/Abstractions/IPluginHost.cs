using System;
using System.Collections.Generic;
using System.Text;

namespace Crass.PluginCore
{
    public interface IPluginHost
    {
        IEnumerable<IPlugin> Plugins { get; }

        
    }
}
