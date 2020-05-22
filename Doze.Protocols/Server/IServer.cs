using Doze.Protocols.Metadata;
using Doze.Protocols.Packetize;
using Doze.Protocols.Processors;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Doze.Protocols.Server
{
    public interface IServer
    {
        ServerListeningResult Listen(IPAddress address, int port);
        void Shutdown();
        void Broadcast(BaseNetworkable data);
        void RegisterProcessor(IProcessorLogic logic);
        void Send(BaseNetworkable data, NetworkConnection connection);
        Task<BaseNetworkableResponse> SendAsync(BaseNetworkable data, NetworkConnection connection);
        bool IsAlive();
        Dictionary<Guid, NetworkConnection> GetConnections();
    }
}
