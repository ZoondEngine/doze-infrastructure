using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Nt.Client.Core.Errors.Reports
{
    public class BaseReport
    {
        public BaseDozeException CalledException { get; private set; }
        public List<System.Diagnostics.Process> ProcessesList { get; private set; }

        public BaseReport(BaseDozeException ex)
        {
            CalledException = ex;
            ProcessesList = System.Diagnostics.Process.GetProcesses().ToList();
        }

        public async Task<string> ToTextFormatAsync(bool inheritedModules = true)
            => await Task.Run(() => ToTextFormat(inheritedModules));

        public string ToTextFormat(bool inheritedModules = false)
        {
            string text = $"Exception occured: {CalledException.GetType().FullName}" + Environment.NewLine;
            text += $"Code: 0x{CalledException.Code:X8}" + Environment.NewLine;
            text += $"Message: {CalledException.Message}" + Environment.NewLine;
            text += $"Full: {CalledException}" + Environment.NewLine;
            text += $"Processes list: " + Environment.NewLine;
            text += "-- PROCESSES START --" + Environment.NewLine;
            int errors = 0;
            int allErrors = 0;

            for (int i = 0; i < ProcessesList.Count; i++)
            {
                try
                {
                    var process = ProcessesList[i];
                    text += $"{i}. {process.ProcessName}( PID: {process.Id} ) [ 0x{process.MainModule.BaseAddress.ToInt64():X16} -> 0x{(process.MainModule.BaseAddress.ToInt64() + process.VirtualMemorySize64):X16} ]" + Environment.NewLine;

                    if (errors > 0)
                    {
                        text += $"Can't get '{errors}' processes before that - local_id:{i}" + Environment.NewLine;
                        errors = 0;
                    }

                    if (inheritedModules)
                    {
                        text += $" ----- PROCESS: {process.ProcessName} MODULES START ----- " + Environment.NewLine;

                        for (int j = 0; j < process.Modules.Count; j++)
                        {
                            var module = process.Modules[j];
                            text += $"Module: {j}. {module.ModuleName}( Parent: {process.ProcessName} ) [ 0x{module.BaseAddress.ToInt64():X16} -> 0x{module.BaseAddress.ToInt64() + (long)module.ModuleMemorySize:X16} ]" + Environment.NewLine;
                        }

                        text += $" ----- PROCESS: {process.ProcessName} MODULES STOP ----- " + Environment.NewLine;
                    }
                    else
                    {
                        text += $" - {process.ProcessName} modules count: {process.Modules.Count}" + Environment.NewLine;
                    }
                }
                catch
                {
                    errors++;
                    allErrors++;
                }
            }

            text += "-- PROCESSES STOP --" + Environment.NewLine;
            text += $"Dump ends with '{allErrors}' errors";

            return text;
        }
    }
}
