using Jareem.Network.Packets;
using Jareem.Network.Systems.Tcp.Observeable.Providers.TcpReceiving;
using Jareem.Support.Implements.Observer.Base;
using System;

namespace Doze.Nt.Server.Network.Processors
{
    public class AuthenticateProcessor : IObserver<BaseData>
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
            if (rec.PacketContent.Identifier == (int)Packets.AuthenticateRequest)
            {
                var authenticateRequest = rec.PacketContent.Convert<AuthenticateRequest>();
                var log = network.GetLog();
                if(log != null)
                {
                    log.WriteLine($"Authenticate request -- '{authenticateRequest.Login}' : '{authenticateRequest.PasswordHash}'. Locale: '{authenticateRequest.LocaleTwoLettersCode}' / Hardware: '{authenticateRequest.Hardware}'", Log.LogLevel.Info);
                }

                network.GetService().Send(new AuthenticateResponse() { Result = true, Message = "" }, rec.Connection);
            }
        }
    }
}
