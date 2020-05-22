using Doze.Nt.Server.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doze.Nt.Server.Visual.Controls.Network
{
    public partial class ServerSettingsInformationWindow : Form
    {
        public bool IsWindowDragging { get; private set; }
        public Point StartPoint { get; private set; }

        public ServerSettingsInformationWindow()
        {
            InitializeComponent();
        }

        private void ServerSettingsInformationWindow_Load(object sender, EventArgs e)
        {
            var network = DozeObject.FindObjectOfType<NetworkObject>();
            if(network != null)
            {
                var settings = network.GetSettings();
                if(settings != null)
                {
                    AddressInfoLabel.Text = $"Address: {network.Address}";
                    PortInfoLabel.Text = $"Port: {network.Port}";

                    var enabledSecurity = settings.Read<bool>("enable", "security") ? "RSA (two factored)" : "None";

                    SecurityEnabledInfoLabel.Text = $"Crypto: {enabledSecurity}";
                    MaxConnectionsInfoLabel.Text = $"Max connections: {network.MaxConnections}";
                    KeySizeInfoLabel.Text = $"Protocol: {settings.Read<string>("protocol", "security")}";
                }
            }
        }

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            IsWindowDragging = true;
            StartPoint = new Point(e.X, e.Y);
        }

        private void guna2Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsWindowDragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - StartPoint.X, p.Y - StartPoint.Y);
            }
        }

        private void guna2Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            IsWindowDragging = false;
        }
    }
}
