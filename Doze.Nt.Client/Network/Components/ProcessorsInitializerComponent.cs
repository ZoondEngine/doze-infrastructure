using Doze.Components;
using Doze.Nt.Client.Network.Processors;
using Jareem.Network.Systems.Tcp.Client;
using Jareem.Network.Systems.Tcp.Observeable.Providers;
using Jareem.Support.Implements.Observer.Base;
using System;
using System.Collections.Generic;

namespace Doze.Nt.Client.Network.Components
{
    public class ProcessorsInitializerComponent : DozeComponent
    {
        private NetworkClientObject Parent;
        private bool Initialized;

        private List<Action<TcpTunnel>> _modules = new List<Action<TcpTunnel>>()
        {
            (service) => service.Subscribe<TcpConnectionProvider, BaseData>(new SpliceProcessor()),
        };

        public override void Awake()
        {
            Parent = ReinterpretObject<NetworkClientObject>(ParentObject);
            Initialized = false;
        }

        public override void Update()
        {
            if(!Initialized)
            {
                if (Parent != null)
                {
                    var service = Parent.GetService();
                    if (service != null)
                    {
                        foreach (var module in _modules)
                        {
                            module(service);
                        }

                        Initialized = true;
                    }
                }
            }
        }
    }
}
