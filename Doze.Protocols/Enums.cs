using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Protocols
{
    public enum DisconnectReason
    {
        ServerClosed,
        ClientClosed,
        LimitReached
    }

    public enum ProcessorResult
    {
        ProcessorNotFound,
        Error,
        Ok
    }
}
