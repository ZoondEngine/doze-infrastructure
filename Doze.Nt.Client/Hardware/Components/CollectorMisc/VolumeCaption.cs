using Doze.Nt.Client.Hardware.Components.CollectorMisc.Archetype;

namespace Doze.Nt.Client.Hardware.Components.CollectorMisc
{
    public class VolumeCaption : BaseCaption
    {
        public VolumeCaption() 
            : base(new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive"))
        { }

        public string GetInterfaceType()
            => Get<string>("InterfaceType");

        public string GetManufacturer()
            => Get<string>("Manufacturer");

        public string GetModel()
            => Get<string>("Model");

        public string GetSerialNumber()
            => Get<string>("SerialNumber");
    }
}
