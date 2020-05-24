using Doze.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Concurrent;
using System.Data.Common;
using System.Linq;

namespace Doze.Nt.Server.Database.Components
{
    public class DatabaseUpdateStatusComponent : DozeComponent
    {
        private DatabaseObject Parent { get; set; }
        private DatabaseContext Context { get; set; }
        private DatabaseFacade Database { get; set; }
        private DbConnection Connection { get; set; }
        private DatabaseVisualUpdaterComponent Updater { get; set; }

        private bool IsValid { get; set; }
        private bool IsInitializedControls { get; set; }

        private ConcurrentDictionary<string, string> ControlsDataPairs { get; set; }

        public override void Awake()
        {
            IsValid = false;

            Parent = ParentObject.ReinterpretObject<DatabaseObject>();
            if (Parent != null)
            {
                Context = Parent.CreateContext();
                if (Context != null)
                {
                    Database = Context.Database;
                    if (Database != null)
                    {
                        Connection = Database.GetDbConnection();

                        Updater = Parent.GetComponent<DatabaseVisualUpdaterComponent>();

                        ControlsDataPairs = new ConcurrentDictionary<string, string>()
                        {
                            ["ProviderInfoLabel"] = "",
                            ["ContextInfoLabel"] = "",
                            ["DatabaseInfoLabel"] = "",
                            ["VersionInfoLabel"] = "",
                        };

                        IsInitializedControls = false;
                        IsValid = Updater != null;
                    }
                }
            }
        }

        public void AddUpdatableControls()
        {
            if(IsValid)
            {
                if (!IsInitializedControls)
                {
                    Updater.AddUpdatabableControl(new UpdatableControl("ProviderInfoLabel", (control) =>
                    {
                        control.Text = ControlsDataPairs["ProviderInfoLabel"];
                    }));
                    Updater.AddUpdatabableControl(new UpdatableControl("ContextInfoLabel", (control) =>
                    {
                        control.Text = ControlsDataPairs["ContextInfoLabel"];
                    }));
                    Updater.AddUpdatabableControl(new UpdatableControl("DatabaseInfoLabel", (control) =>
                    {
                        control.Text = ControlsDataPairs["DatabaseInfoLabel"];
                    }));
                    Updater.AddUpdatabableControl(new UpdatableControl("VersionInfoLabel", (control) =>
                    {
                        control.Text = ControlsDataPairs["VersionInfoLabel"];
                    }));

                    IsInitializedControls = true;
                }
            }
        }

        public override void Update()
        {
            AddUpdatableControls();

            string provider = "Provider: ";
            string context = "Context: ";
            string database = "Database: ";
            string version = "";

            if (IsValid)
            {
                try
                {
                    provider += Database.ProviderName.Split('.').Last();
                    database += Connection.Database;
                    context += Context.ContextId;
                    version += Connection.ServerVersion + $" ({Connection.State.ToString().ToLower()})";
                }
                catch
                {
                    IsValid = false;
                    version = "Version: unknown (disbounded)";
                }
            }
            else
            {
                provider += "not valid";
                database += "not found (ctx: -1)";
                context += "damaged";
                version = "Version: unknown (disbounded)";
            }

            ControlsDataPairs["ProviderInfoLabel"] = provider;
            ControlsDataPairs["ContextInfoLabel"] = context;
            ControlsDataPairs["DatabaseInfoLabel"] = database;
            ControlsDataPairs["VersionInfoLabel"] = version;
        }

        public override void BeforeDestroy()
        {
            Context.Dispose();
        }
    }
}
