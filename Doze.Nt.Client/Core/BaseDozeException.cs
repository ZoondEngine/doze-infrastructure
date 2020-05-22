using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Nt.Client.Core
{
    public class BaseDozeException : Exception
    {
        public uint Code { get; private set; }

        public BaseDozeException(uint code, string message) : base(message)
        {
            Code = code;
        }

        public override string ToString()
            => $"Code: 0x{Code:X8}" + Environment.NewLine + base.ToString();
    }
}
