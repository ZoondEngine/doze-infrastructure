using Doze.Protocols.Metadata;
using Doze.Protocols.Packetize;

namespace Doze.Protocols.Processors
{
    public interface IProcessorLogic
    {
        bool IsSatisfy(BaseNetworkable data);
        ProcessResult Process(BaseNetworkable data, NetworkConnection connection);
    }
}
