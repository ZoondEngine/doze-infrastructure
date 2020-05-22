using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Protocols.Packetize
{
    public abstract class BaseNetworkableRequest : BaseNetworkable
    {
        public BaseNetworkableRequest(int id) 
            : base(id)
        { }
    }
}
