using Network.Packets;
using System;

namespace Doze.Ethernet.Packets.Income
{
    public class IncomeResponse : ResponsePacket
    {
        public Guid AcceptedGuid { get; set; }
        public bool IsBanned { get; set; }

        public IncomeResponse(Guid guid, bool isBanned, IncomeRequest request) 
            : base(request)
        {
            AcceptedGuid = guid;
            IsBanned = isBanned;
        }
    }
}
