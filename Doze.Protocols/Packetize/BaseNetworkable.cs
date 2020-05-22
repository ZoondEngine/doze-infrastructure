using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Protocols.Packetize
{
    public abstract class BaseNetworkable
    {
        public int Identifier { get; private set; }

        protected BaseNetworkable(int id)
        {
            Identifier = id;
        }

        public abstract bool IsValid();
    }
}
