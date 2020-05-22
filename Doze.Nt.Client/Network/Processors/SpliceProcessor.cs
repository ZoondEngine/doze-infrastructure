using Doze.Nt.Windows;
using Jareem.Network.Systems.Tcp.Observeable.Providers.TcpConnection;
using Jareem.Support.Implements.Observer.Base;
using System;

namespace Doze.Nt.Client.Network.Processors
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
            var conn = value.As<TcpConnection>();
            if (!conn.IsConnected)
            {
                var windowManager = DozeObject.FindObjectOfType<WindowsObject>();
                if(windowManager != null)
                {
                    windowManager.SetState(WindowVisualState.Loading);
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
