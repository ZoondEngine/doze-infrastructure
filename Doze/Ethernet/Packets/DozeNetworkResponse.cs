using Network.Packets;

namespace Doze.Ethernet.Packets
{
    public abstract class DozeNetworkResponse : ResponsePacket
    {
        public DozeNetworkResponse(DozeNetworkRequest request)
            : base(request)
        { }

        public T To<T>() where T : DozeNetworkResponse
            => (T)this;

        public abstract bool IsValid();
    }
}
