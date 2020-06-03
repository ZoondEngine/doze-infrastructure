using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Nt.Client.LoginContextData
{
    public class User
    {
        public long Identifier { get; set; }
        public string Hardware { get; set; }
        public string EMail { get; set; }

        public User(long id, string hardware, string email)
        {
            Identifier = id;
            Hardware = hardware;
            EMail = email;
        }

        public bool IsValid()
        {
            return Identifier != 0 & Hardware != null & EMail != null;
        }
    }
}
