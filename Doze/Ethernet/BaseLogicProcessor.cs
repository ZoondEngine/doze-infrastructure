using Doze.Ethernet.Packets;
using Network;
using Network.Packets;

namespace Doze.Ethernet
{
    public abstract class BaseLogicProcessor
    {
        protected string LastError { get; set; }
        public string GetLastError()
            => LastError;

        public abstract bool OnReceived(Packet obj, Connection connection);

        public abstract bool IsNecessary(Packet packet);
    }
}
