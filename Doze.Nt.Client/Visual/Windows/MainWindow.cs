using Doze.Nt.Client.Core;
using Doze.Nt.Client.Visual.Controls;
using Doze.Nt.Client.Visual.Windows.MainWindowHelpers;
using Doze.Nt.Windows.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doze.Nt.Client
{
    public partial class MainWindow : Form, IManagedWindow
    {
        private MainWindowHelperObject MainWindowHelper { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            MainWindowHelper = DozeObject.Create<MainWindowHelperObject>();
            MainWindowHelper.RefWindow(this);
        }

        private void DatabaseStatusButton_Click(object sender, EventArgs e)
        {
            MainWindowHelper.ClearLeftsideSubview();

            DatabaseStatusButton.Checked = true;
            ContentPanel.Controls.Add(new ProductsComponent());
        }

        private void ServerStatusButton_Click(object sender, EventArgs e)
        {
            MainWindowHelper.ClearLeftsideSubview();

            ServerStatusButton.Checked = true;
        }

        public void OnVisible()
        {
            //throw new NotImplementedException();
        }

        public void OnHide()
        {
            //throw new NotImplementedException();
        }

        public void OnLoading()
        {
            //throw new NotImplementedException();
        }

        public void OnExit()
        {
            //throw new NotImplementedException();
        }

        Form IManagedWindow.Parent()
        {
            return this;
        }
    }
}
