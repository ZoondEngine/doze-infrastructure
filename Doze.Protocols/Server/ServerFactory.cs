using Doze.Protocols.Proto;
using Doze.Protocols.Server.Tcp.Crypto;
using Doze.Protocols.Server.Tcp.Normal;
using Doze.Protocols.Server.Udp.Crypto;
using Doze.Protocols.Server.Udp.Normal;
using System;

namespace Doze.Protocols.Server
{
    public static class ServerFactory
    {
        public static IServer CreateServer(ServerListeningMode mode, IProtoProvider protocol)
        {
            if ((mode & ServerListeningMode.MultiTransport) == ServerListeningMode.MultiTransport)
            {
                throw new ArgumentException($"For creating multitransport usage 'CreateServersPool'!");
            }

            if ((mode & ServerListeningMode.Tcp) == ServerListeningMode.Tcp)
            {
                if ((mode & ServerListeningMode.TcpSecure) == ServerListeningMode.TcpSecure)
                {
                    return new SecureTcpServer(protocol);
                }

                return new TcpServer(protocol);
            }

            if ((mode & ServerListeningMode.Udp) == ServerListeningMode.Udp)
            {
                if ((mode & ServerListeningMode.UdpSecure) == ServerListeningMode.UdpSecure)
                {
                    return new SecureUdpServer(protocol);
                }

                return new UdpServer(protocol);
            }

            throw new ArgumentException($"Invalid server mode for factory!");
        }

        public static ServersPool CreateServersPool(ServerListeningMode mode, IProtoProvider protocol)
        {
            if((mode & ServerListeningMode.MultiTransport) == ServerListeningMode.MultiTransport)
            {
                if((mode & ServerListeningMode.MultiTransportSecure) == ServerListeningMode.MultiTransportSecure)
                {
                    return new ServersPool(new SecureTcpServer(protocol), new SecureUdpServer(protocol));
                }

                return new ServersPool(new TcpServer(protocol), new UdpServer(protocol));
            }

            if((mode & ServerListeningMode.Tcp) == ServerListeningMode.Tcp)
            {
                if((mode & ServerListeningMode.TcpSecure) == ServerListeningMode.TcpSecure)
                {
                    return new ServersPool(new SecureTcpServer(protocol));
                }

                return new ServersPool(new TcpServer(protocol));
            }

            if ((mode & ServerListeningMode.Udp) == ServerListeningMode.Udp)
            {
                if ((mode & ServerListeningMode.UdpSecure) == ServerListeningMode.UdpSecure)
                {
                    return new ServersPool(new SecureUdpServer(protocol));
                }

                return new ServersPool(new UdpServer(protocol));
            }

            throw new ArgumentException($"Invalid server mode for factory!");
        }
    }
}
