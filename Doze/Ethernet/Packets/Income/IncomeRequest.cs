using Network.Packets;

namespace Doze.Ethernet.Packets.Income
{
    public class IncomeRequest : RequestPacket
    {
        public string Hardware { get; set; }

        public IncomeRequest(string hardware)
        {
            Hardware = hardware;
        }
    }
}
