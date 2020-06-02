using Doze.Nt.Server.Database;
using Jareem.Network.Packets;
using Jareem.Network.Systems.Tcp.Observeable.Providers.TcpReceiving;
using Jareem.Support.Implements.Observer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Nt.Server.Network.Processors
{
    public class ClientUpdateProcessor : IObserver<BaseData>
    {
        public void OnCompleted()
        { }

        public void OnError(Exception error)
        {

        }

        public void OnNext(BaseData value)
        {
            var network = DozeObject.FindObjectOfType<NetworkObject>();
            var rec = value.As<TcpNetworkData>();
            if (rec.PacketContent.Identifier == (int)Packets.GuardRequest)
            {
                var packet = rec.PacketContent.Convert<ClientUpdateRequest>();
                var db = DozeObject.FindObjectOfType<DatabaseObject>();
                if (db == null)
                {

                }
            }
        }
    }
}
