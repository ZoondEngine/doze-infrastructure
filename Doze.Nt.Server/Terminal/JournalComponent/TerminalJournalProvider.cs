using Doze.Journal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Nt.Server.Terminal.JournalComponent
{
    public class TerminalJournalProvider : IJournalProvider
    {
        public void ImmediateWrite(object what, JournalingLevel level)
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Write(object what, JournalingLevel level)
        {
            throw new NotImplementedException();
        }
    }
}
