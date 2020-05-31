using Doze.Nt.Windows;
using System;
using System.Windows.Forms;

namespace Doze.Nt.Server
{
    static class Program
    {
        public static ApplicationContext AppContext { get; private set; }

        [STAThread]
        static void Main()
        {
            try
            {
                AppContext = DozeObject.Create<ApplicationContext>();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var cachedForm = AppContext.GetVisualManager().CacheOrGetOriginalObject(new WindowGeneralForm(), "window-general:form");
                AppContext.GetVisualManager().SetState(WindowVisualState.Loading);

                Application.Run(cachedForm);
            }
            catch
            {
                MessageBox.Show("Catched critical error while application will be running.\n\nApplication would be closed.", "Critical error", MessageBoxButtons.OK);
            }
        }
    }
}
