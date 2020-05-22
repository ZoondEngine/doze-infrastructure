using Network.Packets;

namespace Doze.Ethernet.Packets
{
    public abstract class DozeNetworkRequest : RequestPacket
    {
        public abstract bool IsValid();

        //Implemented
        public T To<T>() where T : DozeNetworkRequest
        {
            return (T)this;
        }
    }
}
