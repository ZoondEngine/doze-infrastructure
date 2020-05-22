using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Doze.Nt.Windows.Interface;

namespace Doze.Nt.Server.Visual.Controls
{
    public partial class ServerStatusContent : UserControl, IManagedWindow
    {
        private Form ParentControl { get; set; }

        public ServerStatusContent(Form parent)
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
            //throw new NotImplementedException();
        }

        public void OnVisible()
        {
            //throw new NotImplementedException();
        }

        Form IManagedWindow.Parent()
            => ParentControl;

        private void ServerStatusContent_Load(object sender, EventArgs e)
        {

        }
    }
}
