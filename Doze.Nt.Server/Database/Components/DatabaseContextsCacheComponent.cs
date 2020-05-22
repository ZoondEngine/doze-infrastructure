using Doze.Components;
using Doze.Nt.Server.Database.Settings;
using System;
using System.Collections.Concurrent;

namespace Doze.Nt.Server.Database.Components
{
    public class DatabaseContextsCacheComponent : DozeComponent
    {
        private ConcurrentDictionary<int, DatabaseContext> SynchronizedContexts { get; set; }
        private ConcurrentStack<int> RemovableIdentifiers { get; set; }

        public override void Awake()
        {
            SynchronizedContexts = new ConcurrentDictionary<int, DatabaseContext>();
            RemovableIdentifiers = new ConcurrentStack<int>();

            var visualUpdater = ParentObject.GetComponent<DatabaseVisualUpdaterComponent>();
            if(visualUpdater != null)
            {
                visualUpdater.AddUpdatabableControl(new UpdatableControl("SyncContextsInfoLabel", (control) =>
                {
                    control.Text = $"Synchronized contexts: {SynchronizedContexts.Count}";
                }));
            }
        }

        public override void Update()
        {
            if(RemovableIdentifiers.Count > 0)
            {
                foreach(var id in RemovableIdentifiers)
                {
                    SynchronizedContexts.TryRemove(id, out var context);
                }

                RemovableIdentifiers.Clear();
            }
        }

        public DatabaseContext CreateContext(DatabaseSettingsPlaceholder settings)
        {
            int id = SynchronizedContexts.Count;

            if (SynchronizedContexts.TryAdd(id, new DatabaseContext(id, settings)))
            {
                if(SynchronizedContexts.TryGetValue(id, out var val))
                {
                    return val;
                }

                throw new Exception($"Invalid work with concurrent cache!");
            }
            else
            {
                if(SynchronizedContexts.ContainsKey(id))
                {
                    if (SynchronizedContexts.TryGetValue(id, out var val))
                    {
                        return val;
                    }

                    throw new Exception($"Invalid work with concurrent cache!");
                }

                throw new Exception($"Unknown error with database contexts caching");
            }
        }

        public void MarkAsRemovable(int id)
            => RemovableIdentifiers.Push(id);
    }
}
