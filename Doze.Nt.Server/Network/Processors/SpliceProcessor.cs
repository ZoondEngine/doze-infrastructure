using Doze.Nt.Server.Log;
using Jareem.Network.Systems.Tcp.Observeable.Providers.TcpConnection;
using Jareem.Support.Implements.Observer.Base;
using System;

namespace Doze.Nt.Server.Network.Processors
{
    public class SpliceProcessor : IObserver<BaseData>
    {
        public void OnCompleted()
        {
            
        }

        public void OnError(Exception error)
        {
            
        }

        public void OnNext(BaseData value)
        {
            var log = DozeObject.FindObjectOfType<NetworkObject>().GetLog();
            if (log != null)
            {
                var conn = value.As<TcpConnection>();
                if(conn.IsConnected)
                {
                    log.WriteLine($"Actor '{conn.Identifier}' connected", LogLevel.Info);
                }
                else
                {
                    log.WriteLine($"Actor '{conn.Identifier}' disconnected", LogLevel.Info);
                }
            }
        }
    }
}
