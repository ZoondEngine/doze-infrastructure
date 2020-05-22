using Doze.Nt.Client.Hardware;
using Doze.Nt.Client.Network;
using Doze.Nt.Client.Subscriptions;
using Doze.Nt.Client.Subscriptions.Structures;
using Doze.Nt.Windows;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doze.Nt.Client
{
    /*
     public static LARGE_INTEGER GetSubscriptionTime(int day, int month, int year, int hour, int minute, int second)
		{
			SYSTEMTIME end = new SYSTEMTIME();
			end.wDay = Convert.ToUInt16(1 + day);
			end.wMonth = Convert.ToUInt16(1 + month);
			end.wYear = Convert.ToUInt16(1601 + year);
			end.wHour = Convert.ToUInt16(hour);
			end.wMinute = Convert.ToUInt16(minute);
			end.wSecond = Convert.ToUInt16(second);

			LARGE_INTEGER time_end;
			SystemTimeToFileTime(ref end, out time_end);

			LARGE_INTEGER time_counter;
			QueryPerformanceCounter(out time_counter);

			LARGE_INTEGER time = new LARGE_INTEGER();
			time.QuadPart = time_counter.QuadPart + time_end.QuadPart;

			return time;
		}
         */

    static class Program
    {
        [STAThread]
        static void Main()
        {
            DozeClientApplication.Run();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var wo = DozeObject.FindObjectOfType<WindowsObject>();
            var obj = wo.CacheOrGetOriginalObject(new Login(), "window-general:login");
            wo.SetState("window-general:login", WindowVisualState.Loading);

            Application.Run(obj);
        }

        private static LargeInteger GetExpirationTicks()
        {
            var subObject = DozeObject.FindObjectOfType<SubscriptionObject>();
            if (subObject != null)
            {
                var productId = /* ex. pubg lite */ 1;
                var testExpirationTime = /* ex. min valu as expiration time */DateTime.MinValue;
                var timeController = subObject.GetComponent<TimeControllerComponent>();
                if(timeController != null)
                {
                    timeController.AddExpiration(productId, testExpirationTime);

                    return LargeInteger.FromFileTime(timeController.ToFileTime(productId));
                }
            }

            return LargeInteger.Zero;
        }

        private unsafe static void MapLibrary()
        {
            var mapper = DozeObject.Create<Process.ManualMapperObject>();
            if(mapper != null)
            {
                var ticks = GetExpirationTicks();
                if (ticks != LargeInteger.Zero)
                {
                    mapper.Assign(System.Diagnostics.Process.GetCurrentProcess(), "C:\\Doze\\Tests\\Map\\test.dll");
                    var reservedShadowPointer = Marshal.AllocHGlobal(Marshal.SizeOf<LargeInteger>());
                    Unsafe.Write(reservedShadowPointer.ToPointer(), GetExpirationTicks());

                    //Map unmanaged library with 
                    mapper.MapLibrary(reservedShadowPointer);
                }
            }
        }
    }
}
