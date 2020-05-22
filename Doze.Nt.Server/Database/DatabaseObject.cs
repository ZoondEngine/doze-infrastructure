using Doze.Nt.Server.Database.Components;
using Doze.Nt.Server.Database.Settings;
using Doze.Nt.Server.External.Settings;
using Doze.Nt.Server.Log;

namespace Doze.Nt.Server.Database
{
    public class DatabaseObject : DozeObject
    {
        private BaseLog Log { get; set; }
        private DatabaseSettingsPlaceholder Settings { get; set; }

        public void Init()
        {
            Log = FindObjectOfType<BaseLog>();

            var externalSettingsObject = FindObjectOfType<ExternalSettingsObject>();
            if (externalSettingsObject == null)
            {
                Log.WriteLine($"Can't run server because external settings object not available now!", LogLevel.Critical);
                return;
            }

            Settings = externalSettingsObject.GetObjectPlaceholder("external-settings:database").As<DatabaseSettingsPlaceholder>();
            if (Settings == null)
            {
                Log.WriteLine($"Can't initialize server variables because not available database settings placeholder", LogLevel.Critical);
                return;
            }

            AddComponent<DatabaseVisualUpdaterComponent>();
            AddComponent<DatabaseContextsCacheComponent>();
            AddComponent<DatabaseUpdateStatusComponent>();
        }

        public DatabaseContext CreateContext()
            => GetComponent<DatabaseContextsCacheComponent>().CreateContext(Settings);

        public void MarkAsRemovable(DatabaseContext context)
            => GetComponent<DatabaseContextsCacheComponent>().MarkAsRemovable(context.GetStatisticIdentifier());

        public DatabaseContextsCacheComponent GetContextsCache()
            => GetComponent<DatabaseContextsCacheComponent>();

        public DatabaseSettingsPlaceholder GetSettings()
            => Settings;
        public BaseLog GetLog()
            => Log;
    }
}
