using Doze.Nt.Client.Network.Components;
using Jareem.Network.Packets;
using Jareem.Network.Systems;
using Jareem.Network.Systems.Tcp.Client;
using Jareem.Network.Systems.Tcp.Observeable.Providers.TcpConnection;
using Jareem.Network.Systems.Tcp.Observeable.Providers.TcpReceiving;
using System.Threading.Tasks;

namespace Doze.Nt.Client.Network
{
    public class NetworkClientObject : DozeObject
    {
        private TcpTunnel Service { get; set; }

        public NetworkClientObject()
        {
            AddComponent<ProcessorsInitializerComponent>();
            Service = ClientFactory.CreateTcpClient("127.0.0.1", 27862);
        }

        public bool Connect()
        {
            try
            {
                if(Service != null)
                {
                    if (!Service.IsConnected())
                    {
                        Service.Connect();

                        return Service.IsConnected();
                    }
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        public void Disconnect()
            => Service.Disconnect();
        public bool IsConnected()
            => Service.IsConnected();
        public TcpConnection GetConnection()
            => Service.GetConnection();

        public async Task<TcpNetworkData> SendAsync(BaseNetworkable data)
            => await Task.Run(() => Service.SendAndWait(data));
        public async Task<T> SendAsync<T>(BaseNetworkable data, Packets awaitablePacketId) where T : BaseNetworkable
            => await Task.Run(() => Service.SendAsync<T>(data, (int)awaitablePacketId));

        public void Send(BaseNetworkable data)
            => Service.Send(data);

        public TcpTunnel GetService()
            => Service;
    }
}
