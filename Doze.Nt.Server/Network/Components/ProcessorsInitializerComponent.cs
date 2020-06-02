using Doze.Components;
using Doze.Nt.Server.Network.Processors;
using Jareem.Network.Systems.Tcp.Observeable.Providers;
using Jareem.Network.Systems.Tcp.Server;
using Jareem.Support.Implements.Observer.Base;
using System;
using System.Collections.Generic;

namespace Doze.Nt.Server.Network.Components
{
    public class ProcessorsInitializerComponent : DozeComponent
    {
        private NetworkObject Parent;
        private bool Initialized;

        private List<Action<TcpServer>> Processors = new List<Action<TcpServer>>()
        {
            (service) => service.Subscribe<TcpConnectionProvider, BaseData>(new SpliceProcessor()),
            (service) => service.Subscribe<TcpReceivingProvider, BaseData>(new AuthenticateProcessor()),
        };

        public override void Awake()
        {
            Parent = ReinterpretObject<NetworkObject>(ParentObject);
            Initialized = false;
        }

        public override void Update()
        {
            if(!Initialized)
            {
                if (Parent != null)
                {
                    var service = Parent.GetService();
                    if(service != null)
                    {
                        foreach (var module in Processors)
                        {
                            module(service);
                        }

                        Parent.GetLog().ImmediateWriteAll($"Registered '{Processors.Count}' network processors!", Journal.Contracts.JournalingLevel.Trace);
                        Initialized = true;
                    }
                }
            }
        }

        public int GetProcessorsCount()
            => Processors.Count;

        public void AddProcessor(Action<TcpServer> processor)
        {
            Processors.Add(processor);
            processor(Parent.GetService());
        }
    }
}
