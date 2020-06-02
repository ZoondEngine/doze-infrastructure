using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Plugins
{
    public class PluginsObject : DozeObject
    {
        private PluginLoader Loader { get; }

        public PluginsObject()
            : base()
        {
            Loader = new PluginLoader("plugins", ".dll");
            Loader.LoadAll();
        }

        public bool Load(string plugin)
            => Loader.Load(plugin);

        public void Call(string plugin, string hook, params object[] args)
        {

        }
    }
}
