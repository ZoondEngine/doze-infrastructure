using Network;
using Network.Enums;
using Network.RSA;

namespace Doze.Ethernet
{
    public delegate void ServerConnectionDelegate(Connection conn, ConnectionType type);

    public class SecureServer : EthernetObject
    {
        private SecureServerConnectionContainer ServerContainer { get; set; }

        private event ServerConnectionDelegate OnEntiredConnection;
        private string Address { get; set; }
        private int Port { get; set; }
        private int KeySize { get; set; }

        public SecureServer()
        { }

        public SecureServer(string tag)
            : base(tag)
        { }

        public void Build(string address, int port, int keySize = 2048)
        {
            if (ServerContainer == null)
            {
                Address = address;
                Port = port;
                KeySize = keySize;

                ServerContainer = (SecureServerConnectionContainer)ConnectionFactory.CreateSecureServerConnectionContainer(address, port, keySize, false);

                ServerContainer.AllowBluetoothConnections = false;
                ServerContainer.AllowUDPConnections = false;
                ServerContainer.ConnectionEstablished += OnConnectionStablished;
            }
        }

        public void Listen()
        {
            if(!ServerContainer.IsTCPOnline)
            {
                ServerContainer.Start();
            }
        }

        public void Stop()
        {
            if(ServerContainer.IsTCPOnline)
            {
                try
                {
                    ServerContainer.StopTCPListener();
                }
                catch
                {
                    ServerContainer = null;
                    Build(Address, Port, KeySize);
                }
            }
        }

        public void Subscribe(ServerConnectionDelegate onConnectionHandler)
            => OnEntiredConnection += onConnectionHandler;

        private void OnConnectionStablished(Connection connection, ConnectionType type)
            => OnEntiredConnection?.Invoke(connection, type);

        public SecureServerConnectionContainer GetServerContainer()
            => ServerContainer;
    }
}
