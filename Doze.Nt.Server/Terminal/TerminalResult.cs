using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Nt.Server.Terminal
{
    public class TerminalResult
    {
        public CommandExecutingResult ExecutingResult { get; private set; }
        public string Response { get; private set; }

        public TerminalResult(CommandExecutingResult result, string response)
        {
            ExecutingResult = result;
            Response = response;
        }
    }
}
