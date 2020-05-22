using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Protocols.Packetize
{
    public abstract class BaseNetworkableResponse : BaseNetworkable
    {
        public BaseNetworkableResponse(int id)
            : base(id)
        { }
    }
}
