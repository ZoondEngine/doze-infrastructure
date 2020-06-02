using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Plugins.Contracts
{
    public interface IDozePlugin
    {
        void Call(string hook, params object[] args);
        object CallReturnable(string hook, params object[] args);

        public string GetName();
        public Version GetVersion();
        public string GetDescription();
    }
}
