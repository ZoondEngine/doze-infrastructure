namespace Doze.Protocols.Packetize
{
    public class DisconnectResponse : BaseNetworkableResponse
    {
        public DisconnectReason Reason { get; set; }

        public DisconnectResponse(DisconnectReason reason)
            : base(128)
        {
            Reason = reason;
        }

        public override bool IsValid()
            => true;
    }
}
