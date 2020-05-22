using Doze.Components;
using Doze.Nt.Client.Hardware.Components.CollectorMisc;
using Doze.Nt.Client.Hardware.Components.CollectorMisc.Archetype;
using System.Collections.Generic;
using System.Linq;

namespace Doze.Nt.Client.Hardware.Components
{
    public class HardwareCollectorComponent : DozeComponent
    {
        private List<BaseCaption> ImplementedCaptions;

        public override void Awake()
        {
            ImplementedCaptions = new List<BaseCaption>
            {
                new NetworkCaption(),
                new OperationalSystemCaption(),
                new ProcessorCaption(),
                new VideoCaption(),
                new VolumeCaption()
            };
        }

        public T GetCaption<T>() where T : BaseCaption
        {
            if(ImplementedCaptions.Count > 0)
            {
                try
                {
                    return (T)ImplementedCaptions.FirstOrDefault((x) => x.GetType() == typeof(T));
                }
                catch
                {
                    return default;
                }
            }

            return default;
        }

        public string GenerateIdentifier()
        {
            return GetCaption<NetworkCaption>().GetMacAddress().Trim()
                + "__" + GetCaption<VolumeCaption>().GetSerialNumber().Trim()
                + "__" + GetCaption<VideoCaption>().GetVideoProcessor().Trim()
                + "__" + GetCaption<ProcessorCaption>().GetProcessorId().Trim();
        }
    }
}
