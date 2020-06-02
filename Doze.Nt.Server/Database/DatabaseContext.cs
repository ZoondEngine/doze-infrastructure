using Doze.Nt.Server.Database.Accessors;
using Doze.Nt.Server.Database.Models;
using Doze.Nt.Server.Database.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doze.Nt.Server.Database
{
    public class DatabaseContext : DbContext
    {
        private DbSet<User> Users { get; set; }
        private DbSet<UserSubscription> UsersSubscriptions { get; set; }
        private DbSet<Product> Products { get; set; }
        private DatabaseSettingsPlaceholder DatabaseSettings { get; set; }
        private int ConcurrentIdentifier { get; set; }
        private List<IDatabaseAccessor> SupportedAccesors { get; set; }

        public DatabaseContext(int identifier, DatabaseSettingsPlaceholder settings)
        {
            ConcurrentIdentifier = identifier;
            DatabaseSettings = settings;

            SupportedAccesors = new List<IDatabaseAccessor>()
            {
                new UserAccessor(Users, this),
                new UserSubscriptionsAccessor(UsersSubscriptions, this),
                new ProductAccessor(Products, this)
            };
        }

        public T GetAccesorOfType<T>() where T : IDatabaseAccessor
            => (T)SupportedAccesors.FirstOrDefault((x) => x.GetType() == typeof(T));
        public Tuple<int, int>[] GetInnerStatisticsSummary()
        {
            Tuple<int, int>[] response = new Tuple<int, int>[SupportedAccesors.Count];
            
            for(int i = 0; i < response.Length; i++)
            {
                var accessor = SupportedAccesors[i];
                response[i] = new Tuple<int, int>(accessor.GetAccessCount(), accessor.GetQueriesCount());
            }

            return response;
        }
        public async Task<Tuple<int, int>[]> GetInnerStatisticsSummaryAsync()
            => await Task.Run(() => GetInnerStatisticsSummary());

        ~DatabaseContext()
        {
            var db = DozeObject.FindObjectOfType<DatabaseObject>();
            if (db != null)
            {
                db.MarkAsRemovable(this);
            }
            else
            {
                throw new Exception($"Can't stat that context for removable and clearing the concurrent database statistic thread!");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = "";

            connectionString += $"server={DatabaseSettings.Read<string>("host", "connection")};";
            connectionString += $"UserId={DatabaseSettings.Read<string>("user", "connection")};";
            connectionString += $"Password={DatabaseSettings.Read<string>("password", "connection")};";
            connectionString += $"database={DatabaseSettings.Read<string>("database", "connection")};";

            options.UseMySql(connectionString);
        }

        public int GetStatisticIdentifier()
            => ConcurrentIdentifier;
    }
}
