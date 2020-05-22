using Doze.Components;
using Doze.Nt.Client.Subscriptions.Extensions;
using Doze.Nt.Client.Subscriptions.Structures;
using System;
using System.Collections.Concurrent;

namespace Doze.Nt.Client.Subscriptions
{
    public class TimeControllerComponent : DozeComponent
    {
        private DateTime Now;
        private ConcurrentDictionary<int, DateTime> ExpirationStamps;

        public override void Awake()
        {
            Now = DateTime.Now;
            ExpirationStamps = new ConcurrentDictionary<int, DateTime>();
        }

        public bool AddExpiration(int productId, DateTime expiration)
            => ExpirationStamps.TryAdd(productId, expiration);

        public bool RemoveExpiration(int productId, out DateTime existedExpiration)
            => ExpirationStamps.TryRemove(productId, out existedExpiration);

        public FileTime ToFileTime(int productId)
        {
            if(ExpirationStamps.TryGetValue(productId, out var expirationDate))
            {
                var epoch = new DateTime(1601, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                var span = new DateTime((DateTime.Now - expirationDate).Ticks);

                epoch.Subtract(span);

                return epoch.DateTimeToFileTime();
            }

            return FileTime.Zero;
        }
    }
}
