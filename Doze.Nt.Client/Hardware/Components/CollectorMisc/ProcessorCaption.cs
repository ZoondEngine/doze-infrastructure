using Doze.Nt.Client.Hardware.Components.CollectorMisc.Archetype;

namespace Doze.Nt.Client.Hardware.Components.CollectorMisc
{
    public class ProcessorCaption : BaseCaption
    {
        public ProcessorCaption()
            : base(new System.Management.ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor"))
        { }

        public string GetProcessorId()
            => Get<string>("ProcessorId");

        public string GetProcessorName()
            => Get<string>("Name");
    }
}
