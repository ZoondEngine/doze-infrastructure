using Doze.Nt.Client.Hardware.Components.CollectorMisc.Archetype;
using System;

namespace Doze.Nt.Client.Hardware.Components.CollectorMisc
{
    public class OperationalSystemCaption : BaseCaption
    {
        public OperationalSystemCaption()
            : base(new System.Management.ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OperatingSystem"))
        { }

		public string GetFreePhysicalMemory()
			=> Get<string>("FreePhysicalMemory");

		public string GetMark()
			=> Convert.ToInt32(GetFreePhysicalMemory()) > 7000000 ? "Suitable" : "Non suitable";

		public string GetName()
			=> Get<string>("Name");

		public string GetSerialNumber()
			=> Get<string>("SerialNumber");

		public string GetUser()
			=> Get<string>("RegisteredUser");

		public string GetVersion()
			=> Get<string>("Version");
	}
}
