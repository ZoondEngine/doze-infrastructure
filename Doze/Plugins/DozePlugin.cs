using Doze.Plugins.Contracts;
using System;
using System.Collections.Generic;

namespace Doze.Plugins
{
    public abstract class DozePlugin : IDozePlugin
    {
        private PluginsObject PluginManager { get; }

        public string PluginName { get; set; }
        public Version PluginVersion { get; private set; }
        public string PluginDescription { get; private set; }

        public DozePlugin(string name, Version version, string description)
        {
            PluginName = name;
            PluginVersion = version;
            PluginDescription = description;

            PluginManager = DozeObject.FindObjectOfType<PluginsObject>();
        }

        public abstract void OnInitialized();
        public abstract void OnStopped();
        public abstract void OnPluginReady();
        public abstract void OnPluginBeforeDestroy();

        public abstract int GetPluginHashCode();

        public void Call(string hook, params object[] args)
        {
            CallReturnable(hook, args);
        }

        public object CallReturnable(string hook, params object[] args)
        {
            List<Type> argsTypes = new List<Type>();
            foreach (var arg in args)
            {
                argsTypes.Add(arg.GetType());
            }

            var method = GetType().GetMethod(hook, argsTypes.ToArray());
            if (method != null)
            {
                return method.Invoke(this, args);
            }

            return default;
        }

        public string GetName()
            => PluginName;

        public Version GetVersion()
            => PluginVersion;

        public string GetDescription()
            => PluginDescription;
    }
}
