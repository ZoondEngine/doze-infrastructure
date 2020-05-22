using Network.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Ethernet.Packets.Tokenize
{
    public class TokenizeResponse : ResponsePacket
    {
        public string Identifier { get; set; }
        public string Authenticable { get; set; }

        public TokenizeResponse(TokenizeRequest req, string identifier, string auth)
            : base(req)
        {
            Identifier = identifier;
            Authenticable = auth;
        }
    }
}
