using Doze.Ini;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Doze.Nt.Server.External.Settings
{
    public class ExternalSettingsObject : DozeObject
    {
        private List<ISettingsObjectPlaceholder> PlaceholderObjects { get; set; }

        public ExternalSettingsObject()
        {
            if (!Directory.Exists("settings"))
                Directory.CreateDirectory("settings");

            PlaceholderObjects = LoadConfiguration();
        }

        public ExternalSettingsObject(string tag) : base(tag)
        {
            if (!Directory.Exists("settings"))
                Directory.CreateDirectory("settings");

            PlaceholderObjects = LoadConfiguration();
        }

        public void Load()
        {
            foreach (var cfg in PlaceholderObjects)
            {
                cfg.Load();
            }
        }

        public Placeholder GetNativePlaceholder(string name)
            => GetObjectPlaceholder(name)?.GetNativeIni();

        public ISettingsObjectPlaceholder GetObjectPlaceholder(string name)
            => PlaceholderObjects.FirstOrDefault((x) => string.Equals(x.GetName(), name, StringComparison.CurrentCultureIgnoreCase));

        public Placeholder Open(string path, bool forCreating = false)
        {
            if (!File.Exists(path))
            {
                return forCreating ? new Placeholder() : null;
            }

            var ini = new Placeholder();
            ini.Load(path);

            return ini;
        }

        public Placeholder Create()
            => new Placeholder();

        public T Get<T>(Placeholder file, string section, string variable)
        {
            if (file == null)
            {
                return default;
            }

            if (!file.ContainsSection(section))
                return default;

            var readedSection = file[section];
            return readedSection.ContainsKey(variable) ? readedSection[variable].Get<T>() : default;
        }

        private static List<ISettingsObjectPlaceholder> LoadConfiguration()
        {
            return Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(m => m.GetInterfaces().Contains(typeof(ISettingsObjectPlaceholder)))
                .Select(m => m.GetConstructor(Type.EmptyTypes).Invoke(null) as ISettingsObjectPlaceholder)
                .ToList();
        }
    }
}
