using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Nt.Server.Terminal.Interface
{
    public interface ITerminalCommand
    {
        string Name { get; set; }
        string Description { get; set; }
        int Level { get; set; }

        bool IsExecutable(string line);
        bool Run(string line);
        string GetMessage();
        string GetHelp();
    }
}
