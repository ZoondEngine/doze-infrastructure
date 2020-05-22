using System;
using System.IO;
using System.Net.Sockets;

namespace Doze.Protocols.Metadata
{
    public class NetworkConnection
    {
        public Guid GUID { get; private set; }
        public DateTime ConnectedFrom { get; private set; }
        public INetworkConnectionOperator Operator { get; private set; }
        public Stream Stream
        {
            get
            {
                return Operator.GetStream();
            }
        }

        public NetworkConnection(INetworkConnectionOperator @operator)
        {
            GUID = Guid.NewGuid();
            ConnectedFrom = DateTime.Now;
            Operator = @operator;
        }

        public void Send(byte[] data)
            => Operator.Send(data);

        public void Disconnect(bool free = true)
        {
            if (Operator.IsConnected())
            {
                Operator.Disconnect();
            }

            if (free)
            {
                GUID = Guid.Empty;
                ConnectedFrom = DateTime.MinValue;
                Operator = null;
            }
        }
    }
}
