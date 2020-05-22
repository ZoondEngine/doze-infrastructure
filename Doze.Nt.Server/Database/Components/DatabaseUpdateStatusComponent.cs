using Doze.Components;
using Doze.Nt.Server.Visual.Controls;
using Doze.Nt.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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

        private bool IsValid { get; set; }

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
                        IsValid = true;
                    }
                }
            }
        }

        public override void Update()
        {
            if ((CurrentTickTime - PreviousTickTime).Seconds > 2)
            {
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

                var visualObject = FindObjectOfType<WindowsObject>();
                visualObject.ExecuteCode<DatabaseStatusContent>("control-general:database_status", (database_content) =>
                {
                    database_content.ProviderInfoLabel.Text = provider;
                    database_content.ContextInfoLabel.Text = context;
                    database_content.DatabaseInfoLabel.Text = database;
                    database_content.VersionInfoLabel.Text = version;
                });

                AssumeHealth();
            }
        }

        private void AssumeHealth()
        {
            string health = "Health: ";
            if(!IsValid)
            {
                health += "0%";
            }
            else
            {
                health += "100%";
            }

            var visualObject = FindObjectOfType<WindowsObject>();
            visualObject.ExecuteCode<DatabaseStatusContent>("control-general:database_status", (database_content) =>
            {
                //database_content.SyncContextsInfoLabel.Text = health;
            });
        }

        public override void BeforeDestroy()
        {
            Context.Dispose();
        }
    }
}
