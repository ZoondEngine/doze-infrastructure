using Doze.Protocols.Metadata;
using System;
using System.IO;
using System.Net.Sockets;

namespace Doze.Protocols.Server.Tcp.Normal
{
    public class TcpConnectionOperator : INetworkConnectionOperator
    {
        private TcpClient m_Client { get; set; }

        public TcpConnectionOperator(TcpClient client)
        {
            m_Client = client;
        }

        public void Disconnect()
        {
            m_Client.Close();
            m_Client = null;
        }

        public Stream GetStream()
            => m_Client.GetStream();

        public bool IsConnected()
        {
            if(m_Client != null)
            {
                return m_Client.Connected;
            }

            return false;
        }

        public void Send(byte[] data)
            => GetStream().Write(data, 0, data.Length);
    }
}
