using System;

namespace Doze.Protocols.Server
{
    public enum ServerListeningResult
    {
        UnreacheableAddress,
        AlreadyListening,
        Ok
    }

    [Flags]
    public enum ServerListeningMode
    {
        None = 0,
        Tcp  = 1,
        Udp  = 2,
        Secure = 4,
        TcpSecure = Tcp | Secure,
        UdpSecure = Udp | Secure,
        MultiTransport = Tcp | Udp,
        MultiTransportSecure = MultiTransport | Secure
    }
}
