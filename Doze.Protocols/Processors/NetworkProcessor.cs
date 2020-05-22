using Doze.Protocols.Metadata;
using Doze.Protocols.Packetize;
using System.Collections.Generic;

namespace Doze.Protocols.Processors
{
    public class NetworkProcessor
    {
        private List<IProcessorLogic> m_LogicProcessors { get; set; }

        public NetworkProcessor()
        {
            m_LogicProcessors = new List<IProcessorLogic>();
        }

        public void Register<T>(T logic) where T : IProcessorLogic
            => m_LogicProcessors.Add(logic);

        public void ClearProcessors()
            => m_LogicProcessors.Clear();
        
        public ProcessResult Do(BaseNetworkable input, NetworkConnection connection)
        {
            foreach(var logic in m_LogicProcessors)
            {
                if(logic.IsSatisfy(input))
                {
                    return logic.Process(input, connection);
                }
            }

            return new ProcessResult(ProcessorResult.ProcessorNotFound, "Needed logic processor not found");
        }
    }
}
