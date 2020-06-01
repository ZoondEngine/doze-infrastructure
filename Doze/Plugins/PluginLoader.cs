using Doze.Plugins.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Doze.Plugins
{
    internal class PluginLoader
    {
        private static readonly int AccessPluginHashCode = 0x00480038;

        public List<IDozePlugin> Plugins { get; set; }
        public string PluginsDir { get; set; }
        public string PluginsExtension { get; set; }

        public PluginLoader(string dir, string extension)
        {
            PluginsDir = dir;
            PluginsExtension = extension;
            Plugins = new List<IDozePlugin>();
        }

        public bool Load(string plugin)
        {
            var assembly = Assembly.LoadFrom($"{PluginsDir}\\{plugin}.{PluginsExtension}");
            if(assembly != null)
            {
                var code = (int)assembly.GetType("LoaderAccessor").GetProperty("PluginHashCode").GetValue(null, null);
                if(code == AccessPluginHashCode)
                {
                    var plugins = assembly.GetTypes().Where((x) => x.GetInterfaces().Contains(typeof(IDozePlugin)))
                                .Select((x) => x.GetConstructor(Type.EmptyTypes)?.Invoke(null) as IDozePlugin)
                                .ToList();

                    foreach (var item in plugins)
                    {
                        Plugins.Add(item);
                        return true;
                    }
                }
            }

            return false;
        }

        public void LoadAll()
        {
            var files = Directory.GetFiles(PluginsDir, PluginsExtension);
            if(files.Length > 0)
            {
                foreach(var file in files)
                {
                    Load(ParsePluginName(file));
                }
            }
        }

        public DozePlugin GetPlugin(string name)
            => (DozePlugin)Plugins.FirstOrDefault((x) => x.GetName().ToLower() == name.ToLower());
        public T GetPlugin<T>(string name) where T : DozePlugin
            => (T)GetPlugin(name) ?? default;

        private string ParsePluginName(string path)
            => path.Split('\\').Last().Split('.')[0];
    }
}
