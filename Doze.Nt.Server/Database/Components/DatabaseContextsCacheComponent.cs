using Doze.Components;
using Doze.Nt.Server.Database.Settings;
using Guna.UI2.WinForms;
using System;
using System.Collections.Concurrent;

namespace Doze.Nt.Server.Database.Components
{
    public class DatabaseContextsCacheComponent : DozeComponent
    {
        private DatabaseObject Parent { get; set; }
        private DatabaseSettingsPlaceholder Settings { get { return Parent?.GetSettings(); } }
        private ConcurrentDictionary<int, DatabaseContext> SynchronizedContexts { get; set; }
        private ConcurrentStack<int> RemovableIdentifiers { get; set; }

        private int CurrentQueriesSummaryInfo = 0;
        private int CurrentAccessesSummaryInfo = 0;

        public override void Awake()
        {
            Parent = ReinterpretObject<DatabaseObject>(ParentObject);
            SynchronizedContexts = new ConcurrentDictionary<int, DatabaseContext>();
            RemovableIdentifiers = new ConcurrentStack<int>();

            var visualUpdater = ParentObject.GetComponent<DatabaseVisualUpdaterComponent>();
            if(visualUpdater != null)
            {
                visualUpdater.AddUpdatabableControl(new UpdatableControl("SyncContextsInfoLabel", (control) =>
                {
                    control.Text = $"Synchronized contexts: {SynchronizedContexts.Count}";
                }));

                visualUpdater.AddUpdatabableControl(new UpdatableControl("QueriesProgress", (control) =>
                {
                    if (control is Guna2ProgressBar progress)
                    {
                        progress.Maximum = Settings.Read<int>("max_queries_limiter", "statistics");
                        progress.Value = CurrentQueriesSummaryInfo;
                    }
                }));
                visualUpdater.AddUpdatabableControl(new UpdatableControl("QueriesCountLabel", (control) =>
                {
                    control.Text = $"{CurrentQueriesSummaryInfo} / {Settings.Read<int>("max_queries_limiter", "statistics")}";
                }));

                visualUpdater.AddUpdatabableControl(new UpdatableControl("AccessesProgress", (control) =>
                {
                    if (control is Guna2ProgressBar progress)
                    {
                        progress.Maximum = Settings.Read<int>("max_accesses_limiter", "statistics");
                        progress.Value = CurrentAccessesSummaryInfo;
                    }
                }));
                visualUpdater.AddUpdatabableControl(new UpdatableControl("AccessesCountLabel", (control) =>
                {
                    control.Text = $"{CurrentAccessesSummaryInfo} / {Settings.Read<int>("max_accesses_limiter", "statistics")}";
                }));
            }
        }

        public override void Update()
        {
            if(RemovableIdentifiers.Count > 0)
            {
                foreach(var id in RemovableIdentifiers)
                {
                    _ = SynchronizedContexts.TryRemove(id, out _);
                }

                RemovableIdentifiers.Clear();
            }

            UpdateStatistics();
        }

        private void UpdateStatistics()
        {
            CurrentQueriesSummaryInfo = 0;
            CurrentAccessesSummaryInfo = 0;

            foreach (var item in SynchronizedContexts)
            {
                var currentContextSummary = item.Value.GetInnerStatisticsSummary();
                foreach(var accessor in currentContextSummary)
                {
                    CurrentQueriesSummaryInfo += accessor.Item1;
                    CurrentAccessesSummaryInfo += accessor.Item2;
                }
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
