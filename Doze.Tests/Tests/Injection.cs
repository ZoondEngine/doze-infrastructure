using Doze.Process;
using Doze.Tests.Tests.InjectionDetail;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Doze.Tests.Tests
{
    public class Injection : IDozeTest
    {
        private DateTime GetTestSubscriptionTimeWithOffset(DateTime expirationDate)
        {
            var epoch = new DateTime(1601, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var tspan = (expirationDate - DateTime.Now);
            Console.WriteLine($"[INJECTION] >> TimeSpan: {tspan.TotalSeconds}s {tspan.Ticks}ticks");
            var span = new DateTime(tspan.Ticks);
            var epoch_new = epoch.AddTicks(tspan.Ticks);

            Console.WriteLine($"[INJECTION] >> Subtracted epoch with {tspan.TotalSeconds}seconds = '{epoch_new}'");

            return epoch_new;
        }

        public unsafe bool Execute()
        {
            var largeInteger = LargeInteger.FromDateTime(GetTestSubscriptionTimeWithOffset(DateTime.Now.AddDays(2)));
            if(largeInteger != LargeInteger.Zero)
            {
                Console.WriteLine($"[INJECTION] >> Calculated large integer -- low '{largeInteger.LowPart}', high '{largeInteger.HighPart}'");
                var mmap = DozeObject.Create<ManualMapperObject>();
                if (File.Exists("loader.dll"))
                {
                    mmap.Assign(System.Diagnostics.Process.GetCurrentProcess(), "loader.dll");

                    var allocated = Marshal.AllocHGlobal(Unsafe.SizeOf<LargeInteger>());
                    Unsafe.Write(allocated.ToPointer(), largeInteger);

                    mmap.MapLibrary(allocated);
                    Console.WriteLine($"[INJECTION] >> Library mapped: 0x{mmap.DllBaseAddress:X16}");

                    return true;
                }
                else
                {
                    Console.WriteLine("[INJECTION] >> loader.dll not found!");
                }
            }

            return false;
        }
    }
}
