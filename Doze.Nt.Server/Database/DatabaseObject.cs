using Doze.Journal;
using Doze.Nt.Server.Database.Components;
using Doze.Nt.Server.Database.Settings;
using Doze.Nt.Server.External.Settings;
using Doze.Nt.Server.Terminal.JournalComponent;

namespace Doze.Nt.Server.Database
{
    public class DatabaseObject : DozeObject
    {
        private JournalObject Log { get; set; }
        private DatabaseSettingsPlaceholder Settings { get; set; }

        public void Init()
        {
            Log = FindObjectOfType<JournalObject>();

            var externalSettingsObject = FindObjectOfType<ExternalSettingsObject>();
            if (externalSettingsObject == null)
            {
                Log.ImmediateWriteToProvider<TerminalJournalProvider>("Can't run server because external settings object not available now!", Journal.Contracts.JournalingLevel.Critical);
                return;
            }

            Settings = externalSettingsObject.GetObjectPlaceholder("external-settings:database").As<DatabaseSettingsPlaceholder>();
            if (Settings == null)
            {
                Log.ImmediateWriteToProvider<TerminalJournalProvider>($"Can't initialize server variables because not available database settings placeholder", Journal.Contracts.JournalingLevel.Critical);
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
        public JournalObject GetLog()
            => Log;
    }
}
