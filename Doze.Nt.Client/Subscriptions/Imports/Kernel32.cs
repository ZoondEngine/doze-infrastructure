using Doze.Nt.Client.Subscriptions.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Nt.Client.Subscriptions.Imports
{
    public static class Kernel32Imports
    {
        [DllImport("kernel32", SetLastError = true)]
        public static extern bool QueryPerformanceCounter(out LargeInteger performance_counter);
    }
}
