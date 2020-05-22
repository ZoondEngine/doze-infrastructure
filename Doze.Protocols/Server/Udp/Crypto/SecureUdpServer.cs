using Doze.Protocols.Metadata;
using Doze.Protocols.Packetize;
using Doze.Protocols.Processors;
using Doze.Protocols.Proto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Protocols.Server.Udp.Crypto
{
    public class SecureUdpServer : IServer
    {
        public SecureUdpServer(IProtoProvider protocol)
        {

        }

        public void Broadcast(BaseNetworkable data)
        {
            throw new NotImplementedException();
        }

        public Dictionary<Guid, NetworkConnection> GetConnections()
        {
            throw new NotImplementedException();
        }

        public bool IsAlive()
        {
            throw new NotImplementedException();
        }

        public ServerListeningResult Listen(IPAddress address, int port)
        {
            throw new NotImplementedException();
        }

        public void RegisterProcessor(IProcessorLogic logic)
        {
            throw new NotImplementedException();
        }

        public void Send(BaseNetworkable data, NetworkConnection connection)
        {
            throw new NotImplementedException();
        }

        public Task<BaseNetworkableResponse> SendAsync(BaseNetworkable data, NetworkConnection connection)
        {
            throw new NotImplementedException();
        }

        public void Shutdown()
        {
            throw new NotImplementedException();
        }
    }
}
