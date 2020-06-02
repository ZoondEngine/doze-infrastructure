using Doze.Journal;
using Doze.Nt.Server.Database;
using Doze.Nt.Server.External.Settings;
using Doze.Nt.Server.Network;
using Doze.Nt.Server.Terminal;
using Doze.Nt.Windows;
using System;
using System.Deployment.Application;
using System.Reflection;

namespace Doze.Nt.Server
{
    public class ApplicationContext : DozeObject
    {
        private WindowsObject VOM { get; set; }
        private JournalObject Journal { get; set; }
        private DatabaseObject Database { get; set; }
        private TerminalObject Terminal { get; set; }
        private ExternalSettingsObject ExternalSettings { get; set; }
        private Version CurrentApplicationVersion { get; set; }
        private NetworkObject Network { get; set; }
        private string ApplicationName { get; set; }

        public ApplicationContext()
        {
            //Must have for initialize, 
            //because this is global manager of all objects in that case
            DozeObjectManager.Instantiate();

            CurrentApplicationVersion = ApplicationDeployment.IsNetworkDeployed
                ? ApplicationDeployment.CurrentDeployment.CurrentVersion
                : Assembly.GetExecutingAssembly().GetName().Version;

            ApplicationName = "Doze Server";

            ExternalSettings = Create<ExternalSettingsObject>();
            ExternalSettings.Load();

            VOM = Create<WindowsObject>();
            Journal = Create<JournalObject>();
            Journal.Run(false);

            Terminal = Create<TerminalObject>();
            Database = Create<DatabaseObject>();
            Network = Create<NetworkObject>();

            Database.Init();
            Network.Initialize();
        }

        public override void Destroy()
            => DozeObjectManager.Stop();

        public void CloseApplication()
        {
            Destroy();
        }

        public Version GetVersion()
            => CurrentApplicationVersion;

        public string GetName()
            => ApplicationName;

        public WindowsObject GetVisualManager()
            => VOM;

        public JournalObject GetJournal()
            => Journal;

        public TerminalObject GetTerminal()
            => Terminal;

        public ExternalSettingsObject GetExternalSettings()
            => ExternalSettings;
    }
}
