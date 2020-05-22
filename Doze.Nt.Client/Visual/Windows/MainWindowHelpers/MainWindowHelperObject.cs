using Doze.Nt.Client.Core;
using Doze.Nt.Client.Core.Errors;
using Doze.Nt.Client.Core.Errors.Reports;
using Doze.Nt.Client.Visual.Windows.MainWindowHelpers.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Nt.Client.Visual.Windows.MainWindowHelpers
{
    public class MainWindowHelperObject : DozeClientManagedObject
    {
        private MainWindow MainWindowInstance { get; set; }

        public void RefWindow(MainWindow window)
        {
            if (MainWindowInstance == null)
            {
                MainWindowInstance = window;
            }
            else
            {
                if (DozeClientApplication.IsForceModeEnabled())
                {
                    MainWindowInstance = window;
                }
                else
                {
                    if (DozeClientApplication.IsReportsEnabled())
                    {
                        var coreError = FindObjectOfType<CoreErrorObject>();
                        if (coreError != null)
                        {
                            coreError.ReportServer(new BaseReport(new UnauthorizedReferenceException(0xDEADBEEF, "Trying to dereference already initialized window!")));
                        }
                        else
                        {
                            //TODO: save cache data to binary format and fo away for next start
                            //when appluication has been started again collect cached information and send
                            //them on server
                            coreError.SecureReportableError(new BaseReport(new UnauthorizedReferenceException(0xDEADBEEF, "Trying to dereference already initialized window!")));
                        }
                    }
                }
            }
        }

        public void ClearLeftsideSubview()
        {
            MainWindowInstance.DatabaseStatusButton.Checked = false;
            MainWindowInstance.ServerStatusButton.Checked = false;
        }
    }
}
