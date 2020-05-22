using Doze.Ini;
using Doze.Nt.Server.External.Settings;
using System.IO;

namespace Doze.Nt.Server.Network.Settings
{
    public class NetworkSettingsPlaceholder : ISettingsObjectPlaceholder
    {
        private string FilePath { get; set; }
        private Placeholder PlaceholderObject { get; set; }
        private ExternalSettingsObject ParentSettings { get; set; }

        public T As<T>() where T : ISettingsObjectPlaceholder
            => (T)(ISettingsObjectPlaceholder)this;

        public void Default()
        {
            var path = Path.Combine("settings", "network.env");
            var ini_file = ParentSettings.Create();

            ini_file["host"]["address"] = "127.0.0.1";
            ini_file["host"]["port"] = 27862;
            ini_file["security"]["enable"] = true;
            ini_file["security"]["protocol"] = "json";
            ini_file["security"]["max_connections"] = 50;

            ini_file.Save(path);
        }

        public string GetName()
            => "external-settings:network";

        public Placeholder GetNativeIni()
            => PlaceholderObject;

        public string GetPath()
            => FilePath;

        public void Load()
        {
            ParentSettings = DozeObject.FindObjectOfType<ExternalSettingsObject>();
            FilePath = Path.Combine("settings", "network.env");
            if (!File.Exists(GetPath()))
            {
                Default();
            }

            PlaceholderObject = ParentSettings.Open(GetPath());
        }

        public T Read<T>(string key, string section = "General")
            => ParentSettings.Get<T>(GetNativeIni(), section, key);
    }
}
