using Doze.Nt.Server.Log;
using Doze.Nt.Server.Visual.Controls;
using Doze.Nt.Windows;
using Doze.Nt.Windows.Interface;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Doze.Nt.Server
{
    public partial class WindowGeneralForm : Form, IManagedWindow
    {
        private bool IsVisibleProc { get; set; }
        private bool IsWindowDragging = false;
        private Point StartPoint;

        public WindowGeneralForm()
        {
            InitializeComponent();
            IsVisibleProc = false;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            //Program.AppContext.GetVisualManager().ExecuteExitEvent();
        }

        private void NetworkStatusButton_Click(object sender, EventArgs e)
        {
            ClearSub();

            ContentPanel.Controls.Add(Program.AppContext.GetVisualManager().CacheOrGetOriginalObject(new NetworkStatusContent(this), "control-general:network_status"));
            NetworkStatusButton.Checked = true;
        }

        private void ClearSub()
        {
            NetworkStatusButton.Checked = false;
            DatabaseStatusButton.Checked = false;
            ServerStatusButton.Checked = false;
            ConsoleContentButton.Checked = false;

            ContentPanel.Controls.Clear();
        }

        private void DatabaseStatusButton_Click(object sender, EventArgs e)
        {
            ClearSub();

            ContentPanel.Controls.Add(Program.AppContext.GetVisualManager().CacheOrGetOriginalObject(new DatabaseStatusContent(this), "control-general:database_status"));
            DatabaseStatusButton.Checked = true;
        }

        private void ServerStatusButton_Click(object sender, EventArgs e)
        {
            ClearSub();

            ContentPanel.Controls.Add(Program.AppContext.GetVisualManager().CacheOrGetOriginalObject(new ServerStatusContent(this), "control-general:server_status"));
            ServerStatusButton.Checked = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ClearSub();

            ContentPanel.Controls.Add(Program.AppContext.GetVisualManager().CacheOrGetOriginalObject(new ConsoleContent(this), "control-general:console_status"));
            ConsoleContentButton.Checked = true;
        }

        public void OnVisible()
        {
            if(!IsVisibleProc)
            {
                guna2Button1_Click(null, null);
                ApplicationName_Header.Text = Program.AppContext.GetName();
                VersionLabel_Header.Text = $"v{Program.AppContext.GetVersion()}";

                var log = Program.AppContext.GetLog();
                log.WriteLine($"Welcome to the '{Program.AppContext.GetName().ToLower()}'", LogLevel.Debug);
                log.WriteLine($"Current version 'v{Program.AppContext.GetVersion()}'", LogLevel.Debug);

                IsVisibleProc = true;
            }
        }

        public void OnHide()
        {
            if (IsVisibleProc)
                IsVisibleProc = false;

            //throw new NotImplementedException();
        }

        public void OnLoading()
        {
            Program.AppContext.GetVisualManager().SetState("window-general:form", WindowVisualState.Visible);
            //throw new NotImplementedException();
        }

        public void OnExit()
        {
            //throw new NotImplementedException();
        }

        Form IManagedWindow.Parent()
            => this;

        private void WindowGeneralForm_MouseDown(object sender, MouseEventArgs e)
        {
            IsWindowDragging = true;
            StartPoint = new Point(e.X, e.Y);
        }

        private void WindowGeneralForm_MouseUp(object sender, MouseEventArgs e)
        {
            IsWindowDragging = false;
        }

        private void WindowGeneralForm_MouseMove(object sender, MouseEventArgs e)
        {
            if(IsWindowDragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - StartPoint.X, p.Y - StartPoint.Y);
            }
        }

        public void SetServerIndicator(bool enabled = false)
        {
            if(enabled)
            {
                ServerIndicator.FillColor = Color.FromArgb(0, 192, 0);
            }
            else
            {
                ServerIndicator.FillColor = Color.FromArgb(192, 0, 0);
            }
        }
    }
}
