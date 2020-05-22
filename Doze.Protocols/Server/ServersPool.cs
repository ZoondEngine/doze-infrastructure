using Doze.Protocols.Metadata;
using Doze.Protocols.Packetize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Doze.Protocols.Server
{
    public class ServersPool
    {
        private List<IServer> m_AvailableServers { get; set; }
        private List<Thread> m_ServersThreads { get; set; }

        public ServersPool(params IServer[] servers)
        {
            if (servers.Length <= 0)
                throw new InvalidOperationException($"Base server dont receive implemented providers!");

            m_AvailableServers = servers.ToList();
            m_ServersThreads = new List<Thread>();
        }

        public void Broadcast(BaseNetworkable networkable)
            => m_AvailableServers.ForEach((x) => x.Broadcast(networkable));

        public ServerListeningResult Start(IPAddress address, params int[] ports)
        {
            if (ports.Length != m_AvailableServers.Count)
                throw new Exception($"Input ports don't same count with available servers");

            for(int i = 0; i < ports.Length; i++)
            {
                var server = m_AvailableServers[i];
                try
                {
                    var thread = new Thread(() => server.Listen(address, ports[i]));
                    thread.Start();

                    m_ServersThreads.Add(thread);
                }
                catch
                {
                    return ServerListeningResult.UnreacheableAddress;
                }
            }

            return ServerListeningResult.Ok;
        }

        public void Send(BaseNetworkable data, NetworkConnection connection)
            => m_AvailableServers.ForEach((x) => x.Send(data, connection));

        [Obsolete("This method not implemented yet.", true)]
        public Task<BaseNetworkableResponse> SendAsync(BaseNetworkable data, NetworkConnection connection)
        {
            return null;
        }

        public void Stop()
            => m_AvailableServers.ForEach((x) => x.Shutdown());

        public bool IsAlive()
            => m_AvailableServers.TrueForAll((x) => x.IsAlive());
    }
}
