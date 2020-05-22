using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Doze.Nt.Server.Network;
using System.Threading;
using Doze.Nt.Server.Visual.Controls.Network;
using Doze.Nt.Windows.Interface;
using Doze.Nt.Windows;

namespace Doze.Nt.Server.Visual.Controls
{
    public partial class NetworkStatusContent : UserControl, IManagedWindow
    {
        private Form ParentControl { get; set; }
        private bool Initialized { get; set; }
        private NetworkObject Network { get; set; }

        public NetworkStatusContent(Form parent)
        {
            InitializeComponent();

            ParentControl = parent;
        }

        public void OnExit()
        {
            //throw new NotImplementedException();
        }

        public void OnHide()
        {
            //throw new NotImplementedException();
        }

        public void OnLoading()
        {
            MaxConnectionsInfoLabel.Text = "loading...";
            HidePanel.Visible = true;
            MaxConnectionsInfoProgress.Value = 0;

            RunServerButton.Enabled = false;
            ShutdownServerButton.Enabled = false;
            RestartServerButton.Enabled = false;
            NetworkWorkIndicator.Visible = true;
            ServerSettingsInfoButton.Enabled = false;
        }

        public void OnVisible()
        {
            if(!Initialized)
            {
                Network = DozeObject.FindObjectOfType<NetworkObject>();
                Initialized = true;
            }

            var service = Network.GetService();
            if (service == null || !service.IsRunned())
            {
                MaxConnectionsInfoLabel.Text = "not listen";
                MaxConnectionsInfoProgress.Value = 0;

                RunServerButton.Enabled = true;
                ShutdownServerButton.Enabled = false;
                RestartServerButton.Enabled = false;
                ServerSettingsInfoButton.Enabled = false;
                NetworkWorkIndicator.Visible = false;
            }
            else
            {
                var maxConnections = Network.MaxConnections;
                var connections = service.GetConnections();
                var currentConnections = connections.Count;

                MaxConnectionsInfoProgress.Maximum = maxConnections;
                MaxConnectionsInfoLabel.Text = $"{currentConnections} / {maxConnections}";
                MaxConnectionsInfoProgress.Value = currentConnections;

                RunServerButton.Enabled = !service.IsRunned();
                ShutdownServerButton.Enabled = service.IsRunned();
                RestartServerButton.Enabled = service.IsRunned();
                ServerSettingsInfoButton.Enabled = true;
                NetworkWorkIndicator.Visible = false;

                DllConnectionsCombo.Items.Clear();
                LoaderConnectionsCombo.Items.Clear();
                SuiteConnectionsCombo.Items.Clear();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        Form IManagedWindow.Parent()
            => ParentControl;

        private async void RunServerButton_Click(object sender, EventArgs e)
        {
            var visualObjectManager = DozeObject.FindObjectOfType<WindowsObject>();
            visualObjectManager.SetState("control-general:network_status", WindowVisualState.Loading);
            await Task.Run(() => Network.Start());
            visualObjectManager.SetState("control-general:network_status", WindowVisualState.Visible);
        }

        private async void RestartServerButton_Click(object sender, EventArgs e)
        {
            var visualObjectManager = DozeObject.FindObjectOfType<WindowsObject>();
            visualObjectManager.SetState("control-general:network_status", WindowVisualState.Loading);
            await Task.Run(() => Network.Restart());
            visualObjectManager.SetState("control-general:network_status", WindowVisualState.Visible);
        }

        private async void ShutdownServerButton_Click(object sender, EventArgs e)
        {
            var visualObjectManager = DozeObject.FindObjectOfType<WindowsObject>();
            visualObjectManager.SetState("control-general:network_status", WindowVisualState.Loading);
            await Task.Run(() => Network.Shutdown());
            visualObjectManager.SetState("control-general:network_status", WindowVisualState.Visible);
        }

        private void ServerSettingsInfoButton_Click(object sender, EventArgs e)
        {
            new ServerSettingsInformationWindow().ShowDialog(this);
        }
    }
}
