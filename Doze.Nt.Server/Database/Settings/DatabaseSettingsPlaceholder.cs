using Doze.Ini;
using Doze.Nt.Server.External.Settings;
using System.IO;

namespace Doze.Nt.Server.Database.Settings
{
    public class DatabaseSettingsPlaceholder : ISettingsObjectPlaceholder
    {
        private string FilePath { get; set; }
        private Placeholder PlaceholderObject { get; set; }
        private ExternalSettingsObject ParentSettings { get; set; }

        public T As<T>() where T : ISettingsObjectPlaceholder
            => (T)(ISettingsObjectPlaceholder)this;

        public void Default()
        {
            var path = Path.Combine("settings", "database.env");
            var ini_file = ParentSettings.Create();

            ini_file["connection"]["host"] = "localhost";
            ini_file["connection"]["user"] = "root";
            ini_file["connection"]["password"] = "123";
            ini_file["connection"]["database"] = "doze_debug";
            ini_file["statistics"]["enable"] = true;
            ini_file["statistics"]["max_tables_limiter"] = 50;
            ini_file["statistics"]["max_queries_limiter"] = 100;
            ini_file["statistics"]["max_accesses_limiter"] = 10;
            ini_file["statistics"]["max_users_limiter"] = 1000;
            ini_file["statistics"]["max_errors_limiter"] = 100;

            ini_file.Save(path);
        }

        public string GetName()
            => "external-settings:database";

        public Placeholder GetNativeIni()
            => PlaceholderObject;

        public string GetPath()
            => FilePath;

        public void Load()
        {
            ParentSettings = DozeObject.FindObjectOfType<ExternalSettingsObject>();
            FilePath = Path.Combine("settings", "database.env");
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
