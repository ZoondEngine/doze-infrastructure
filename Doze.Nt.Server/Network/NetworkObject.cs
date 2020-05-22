﻿using Doze.Nt.Server.External.Settings;
using Doze.Nt.Server.Log;
using Doze.Nt.Server.Network.Components;
using Doze.Nt.Server.Network.Settings;
using Jareem.Network.Systems;
using Jareem.Network.Systems.Tcp.Server;
using System;

namespace Doze.Nt.Server.Network
{
    public class NetworkObject : DozeObject
    {
        public string Address { get; private set; }
        public int Port { get; private set; }
        public int MaxConnections { get; private set; }

        private TcpServer Service { get; set; }
        private NetworkSettingsPlaceholder Settings { get; set; }
        private BaseLog Log { get; set; }

        public NetworkObject() : base()
        {
            AddComponent<NetworkVisualControllerComponent>();
            AddComponent<ProcessorsInitializerComponent>();
        }

        public void Initialize()
        {
            Log = FindObjectOfType<BaseLog>();

            var externalSettingsObject = FindObjectOfType<ExternalSettingsObject>();
            if(externalSettingsObject == null)
            {
                Log.WriteLine($"Can't run server because external settings object not available now!", LogLevel.Critical);
                return;
            }

            Settings = externalSettingsObject.GetObjectPlaceholder("external-settings:network").As<NetworkSettingsPlaceholder>();
            if(Settings == null)
            {
                Log.WriteLine($"Can't initialize server variables because not available network settings placeholder", LogLevel.Critical);
                return;
            }

            Address = Settings.Read<string>("address", "host");
            Port = Settings.Read<int>("port", "host");
            MaxConnections = Settings.Read<int>("max_connections", "security");

            Service = ServerFactory.CreateTcpServer(Address, Port);
        }

        public void Start()
        {
            if (Service != null)
            {
                if (!Service.IsRunned())
                {
                    Service.Start(MaxConnections);
                    Log.WriteLine($"Network service initialized and started on '{Address}:{Port}' max connections: {MaxConnections}", LogLevel.Info);
                }
            }
        }

        public void Shutdown()
        {
            if(Service.IsRunned())
            {
                Service.Stop();
                Log.WriteLine($"Network service stopped", LogLevel.Info);
            }
        }

        public void Restart()
        {
            Shutdown();
            Start();
        }

        public TcpServer GetService()
            => Service;
        public NetworkSettingsPlaceholder GetSettings()
            => Settings;
        public BaseLog GetLog()
            => Log;
    }
}