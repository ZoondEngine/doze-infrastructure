using System.Windows.Forms;
using Doze.Nt.Windows.Interface;

namespace Doze.Nt.Server.Visual.Controls
{
    public partial class DatabaseStatusContent : UserControl, IManagedWindow
    {
        private Form ParentControl { get; set; }

        public DatabaseStatusContent(Form parent)
        {
            InitializeComponent();

            ParentControl = parent;
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
            => ParentControl;

        private void HealthInfoLabel_Click(object sender, System.EventArgs e)
        {

        }

        private void DatabaseStatusContent_Load(object sender, System.EventArgs e)
        {

        }
    }
}
