using System.IO;

namespace Doze.Protocols.Metadata
{
    public interface INetworkConnectionOperator
    {
        bool IsConnected();
        void Send(byte[] data);
        Stream GetStream();
        void Disconnect();
    }
}
