using Doze.Ethernet.Packets;
using Network;
using Network.Packets;
using System.Collections.Generic;

namespace Doze.Ethernet
{
    public class BaseLogicObject : EthernetObject
    {
        private List<BaseLogicProcessor> Processors { get; set; } = new List<BaseLogicProcessor>();

        public BaseLogicObject()
        { }

        public BaseLogicObject(string tag)
            : base(tag)
        { }

        public void RegisterProcessor(BaseLogicProcessor processor)
        {
            if (!Processors.Contains(processor))
                Processors.Add(processor);
        }

        public void RemoveProcessor(BaseLogicProcessor processor)
        {
            if (Processors.Contains(processor))
                Processors.Remove(processor);
        }

        public LogicResult OnDataReceived(RequestPacket packet, Connection connection)
        {
            if(packet is DozeNetworkRequest request)
            {
                foreach (var proc in Processors)
                {
                    if (proc.IsNecessary(request))
                    {
                        return new LogicResult(proc.OnReceived(request, connection), proc.GetLastError());
                    }
                }

                return new LogicResult(false, $"Processor not found for packet '{packet.GetType()}'");
            }

            return new LogicResult(false, "Incoming packet not a 'RequestPacket'. Denined!");
        }
    }
}
