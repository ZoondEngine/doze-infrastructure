using Doze.Protocols.Metadata;
using Doze.Protocols.Packetize;
using Doze.Protocols.Processors;
using Doze.Protocols.Proto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Doze.Protocols.Server.Tcp.Normal
{
    public class DebugDelegates
    {

    }

    public class TcpServer : IServer
    {
        protected List<Task> m_ListeningTasks { get; set; }
        protected List<Task> m_ReceivingTasks { get; set; }
        protected NetworkProcessor m_CurrentProcessor { get; set; }
        protected IProtoProvider m_ProtocolProvider { get; set; }
        protected TcpListener m_Listener { get; set; }
        protected Dictionary<Guid, NetworkConnection> m_ActiveConnections { get; set; }

        public TcpServer(IProtoProvider protocol)
        {
            if (protocol == null)
                throw new ArgumentNullException();

            m_ProtocolProvider = protocol;
            m_ListeningTasks = new List<Task>();
            m_ReceivingTasks = new List<Task>();
            m_CurrentProcessor = new NetworkProcessor();
            m_ActiveConnections = new Dictionary<Guid, NetworkConnection>();

            RegisterProcessors();
        }

        protected virtual void RegisterProcessors()
        {
            
        }

        public virtual void RegisterProcessor(IProcessorLogic logic)
            => m_CurrentProcessor.Register(logic);

        public virtual void Broadcast(BaseNetworkable data)
            => m_ActiveConnections.Values.ToList().ForEach((x) => x.Send(Encoding.UTF8.GetBytes(m_ProtocolProvider.Serialize(data))));

        public virtual bool IsAlive()
        {
            if(m_Listener != null)
            {
                return m_Listener.Server != null;
            }

            return false;
        }

        public virtual ServerListeningResult Listen(IPAddress address, int port)
        {
            if(m_Listener == null)
            {
                m_Listener = new TcpListener(new IPEndPoint(address, port));
                m_Listener.Start();
                m_ListeningTasks.Add(Accepting());

                return ServerListeningResult.Ok;
            }

            return ServerListeningResult.AlreadyListening;
        }

        protected virtual async Task Accepting()
        {
            await Task.Run(() =>
            {
                while(true)
                {
                    try
                    {
                        TcpClient client = m_Listener.AcceptTcpClient();
                        var connection = new NetworkConnection(new TcpConnectionOperator(client));
                        if (m_ActiveConnections.ContainsValue(connection))
                        {
                            var duplicates = m_ActiveConnections
                            .Where((x) => x.Value == connection)
                            .ToList();

                            duplicates.ForEach((x) =>
                            {
                                Send(new DisconnectResponse(DisconnectReason.ClientClosed), x.Value);
                                m_ActiveConnections.Remove(x.Key);
                                x.Value.Disconnect();
                            });
                        }

                        m_ActiveConnections.Add(connection.GUID, connection);
                        Receiving(connection);
                    }
                    catch
                    {
                        break;
                    }
                }
            });
        }
        protected virtual void Receiving(NetworkConnection client)
        {
            new Thread(() =>
            {
                m_ReceivingTasks.Add(ReceivingTask(client));

            }).Start();
        }
        protected virtual async Task ReceivingTask(NetworkConnection client)
        {
            try
            {
                byte[] buffer = new byte[4096];
                MemoryStream ms = new MemoryStream();
                while (client.Operator.IsConnected())
                {
                    var networkStream = (NetworkStream)client.Stream;
                    int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                    ms.Write(buffer, 0, bytesRead);
                    if (!networkStream.DataAvailable)
                    {
                        string raw = Encoding.UTF8.GetString(ms.ToArray());
                        if (raw != null)
                        {
                            var result = m_CurrentProcessor.Do(m_ProtocolProvider.Deserialize<BaseNetworkable>(raw), client);
                            if(result.Result == ProcessorResult.Error)
                            {
                                throw new Exception(result.Message);
                            }
                        }

                        ms.Seek(0, SeekOrigin.Begin);
                        ms.SetLength(0);
                    }
                }

                m_ActiveConnections.Remove(client.GUID);

                Send(new DisconnectResponse(DisconnectReason.ClientClosed), client);
                client.Disconnect();
            }
            catch
            {
                Send(new DisconnectResponse(DisconnectReason.ClientClosed), client);

                m_ActiveConnections.Remove(client.GUID);
                client.Disconnect();
            }
        }

        public virtual void Shutdown()
        {
            if(IsAlive())
            {
                m_CurrentProcessor.ClearProcessors();

                m_ActiveConnections.Values.ToList().ForEach((x) =>
                {
                    Send(new DisconnectResponse(DisconnectReason.ServerClosed), x);
                    x.Disconnect();
                });
                m_ActiveConnections.Clear();

                m_ListeningTasks.Clear();
                m_ReceivingTasks.Clear();

                m_Listener.Stop();
                m_Listener = null;
            }
        }

        public void Send(BaseNetworkable data, NetworkConnection connection)
            => connection.Send(Encoding.UTF8.GetBytes(m_ProtocolProvider.Serialize(data)));

        public Task<BaseNetworkableResponse> SendAsync(BaseNetworkable data, NetworkConnection connection)
        {
            throw new NotImplementedException();
        }

        public Dictionary<Guid, NetworkConnection> GetConnections()
            => m_ActiveConnections;
    }
}
