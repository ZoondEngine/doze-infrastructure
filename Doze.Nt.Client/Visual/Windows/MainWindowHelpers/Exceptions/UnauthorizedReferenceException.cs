using Doze.Nt.Client.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Nt.Client.Visual.Windows.MainWindowHelpers.Exceptions
{
    public class UnauthorizedReferenceException : BaseDozeException
    {
        public UnauthorizedReferenceException(uint code, string message) 
            : base(code, message)
        { }
    }
}
