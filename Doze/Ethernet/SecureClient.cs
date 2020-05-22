using Network;
using Network.Enums;
using Network.RSA;
using System;

namespace Doze.Ethernet
{
    public delegate void ConnectionEstablished(Connection conn, ConnectionType type);
    public delegate void ConnectionLost(Connection conn, ConnectionType type, CloseReason reason);

    public class SecureClient : EthernetObject
    {
        private event ConnectionEstablished OnConnected;
        private event ConnectionLost OnLost;

        private SecureClientConnectionContainer ClientContainer { get; set; }
        public string Address { get; private set; }
        public int Port { get; private set; }
        public int KeySize { get; private set; }

        public SecureClient() : base()
        { }

        public SecureClient(string tag) : base()
        { }

        public ConnectionResult Connect(string address, int port, int keySize, bool reconnect = true, int reconnectInterval = 1500)
        {
            if(ClientContainer == null)
            {
                Address = address;
                Port = port;
                KeySize = keySize;

                ClientContainer = (SecureClientConnectionContainer)ConnectionFactory.CreateSecureClientConnectionContainer(address, port, keySize);
                ClientContainer.AutoReconnect = reconnect;
                ClientContainer.ReconnectInterval = reconnectInterval;
                ClientContainer.ConnectionEstablished += OnConnectionEstablished;
                ClientContainer.ConnectionLost += OnConnectionLost;

                if (IsConnected())
                    return ConnectionResult.Connected;

                return ConnectionResult.Timeout;
            }

            return ConnectionResult.TCPConnectionNotAlive;
        }

        public void Subscribe<T>(T @delegate)
        {
            if(typeof(T) == typeof(ConnectionEstablished))
            {
                if(@delegate is ConnectionEstablished invoker)
                {
                    OnConnected += invoker;
                }
            }
            else if(typeof(T) == typeof(ConnectionLost))
            {
                if(@delegate is ConnectionLost invoker)
                {
                    OnLost += invoker;
                }
            }
            else
            {
                throw new Exception($"Unknown subscriber delegate! (Typeof: {typeof(T).FullName})");
            }
        }

        private void OnConnectionLost(Connection connection, ConnectionType type, CloseReason reason)
            => OnLost?.Invoke(connection, type, reason);

        private void OnConnectionEstablished(Connection connection, ConnectionType type)
            => OnConnected?.Invoke(connection, type);

        public void Disconnect(CloseReason reason = CloseReason.ClientClosed)
        {
            ClientContainer.Shutdown(reason);

            Address = "";
            Port = 0;
            KeySize = 0;

            ClientContainer.Dispose();
            ClientContainer = null;
        }

        public SecureClientConnectionContainer GetContainer()
            => ClientContainer;

        public bool IsConnected()
            => ClientContainer.IsAlive_TCP;
    }
}
