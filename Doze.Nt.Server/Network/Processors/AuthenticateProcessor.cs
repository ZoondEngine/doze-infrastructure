using Doze.Nt.Server.Database;
using Doze.Nt.Server.Database.Accessors;
using Jareem.Network.Packets;
using Jareem.Network.Systems.Tcp.Observeable.Providers.TcpReceiving;
using Jareem.Support.Implements.Observer.Base;
using System;

namespace Doze.Nt.Server.Network.Processors
{
    public enum AuthenticateProcessorResponseCode
    {
        UserAccessorUnavailable = 364,

    }

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
                bool result = false;
                string message = "";

                var authenticateRequest = rec.PacketContent.Convert<AuthenticateRequest>();
                var db = DozeObject.FindObjectOfType<DatabaseObject>();
                using(var ctx = db.CreateContext())
                {
                    var userAccessor = ctx.GetAccesorOfType<UserAccessor>();
                    if(userAccessor != null)
                    {
                        var currentUserFromDb = userAccessor.SelectOne((x) => x.Email.ToLower() == authenticateRequest.Login.ToLower());
                        if(currentUserFromDb != null)
                        {
                            result = currentUserFromDb.PasswordHash == authenticateRequest.PasswordHash;
                            if(result)
                            {
                                if (currentUserFromDb.HardwareId != "")
                                {
                                    result = currentUserFromDb.HardwareId == authenticateRequest.Hardware;
                                }
                            }
                            else
                            {
                                result = false;
                                message = $"Invalid login or password";
                            }
                        }
                        else
                        {
                            result = false;
                            message = $"User '{authenticateRequest.Login}' not found in database. Please register";
                        }
                    }
                    else
                    {
                        result = false;
                        message = $"Server error: '{(int)AuthenticateProcessorResponseCode.UserAccessorUnavailable}'. Please report that error to operator";
                    }
                }

                network.GetService().Send(new AuthenticateResponse() { Result = result, Message = message }, rec.Connection);
            }
        }
    }
}
