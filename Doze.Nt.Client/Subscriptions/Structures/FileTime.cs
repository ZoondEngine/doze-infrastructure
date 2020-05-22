using System.Runtime.InteropServices;

namespace Doze.Nt.Client.Subscriptions.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct FileTime
	{
		public int DateTimeLow;
		public int DateTimeHigh;

		public static FileTime Zero = new FileTime() { DateTimeLow = 0, DateTimeHigh = 0 };
	}
}
