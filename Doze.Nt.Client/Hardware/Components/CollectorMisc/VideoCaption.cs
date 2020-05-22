using Doze.Nt.Client.Hardware.Components.CollectorMisc.Archetype;

namespace Doze.Nt.Client.Hardware.Components.CollectorMisc
{
    public class VideoCaption : BaseCaption
    {
        public VideoCaption()
            : base(new System.Management.ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController"))
        { }

        public string GetRam()
            => Get<string>("AdapterRAM");

        public string GetVideoProcessor()
            => Get<string>("VideoProcessor");
    }
}
