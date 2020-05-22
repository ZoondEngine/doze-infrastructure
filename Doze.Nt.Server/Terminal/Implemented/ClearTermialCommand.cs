using Doze.Nt.Server.Terminal.Interface;
using Doze.Nt.Server.Visual.Controls;
using Doze.Nt.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Nt.Server.Terminal.Implemented
{
    public class ClearTermialCommand : ITerminalCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public string Message { get; set; }

        public ClearTermialCommand()
        {
            Name = ".clear";
            Description = "Clearing terminal";
            Level = 0;
        }

        public string GetHelp()
            => ".clear";

        public string GetMessage()
        {
            if (Message == "")
                return "console cleared";

            var clone = (string)Message.Clone();
            Message = "";

            return clone;
        }

        public bool IsExecutable(string line)
            => line.ToLower() == ".clear";

        public bool Run(string line)
        {
            if (line.ToLower() != ".clear")
                return false;

            var windowManager = DozeObject.FindObjectOfType<WindowsObject>();
            if(windowManager != null)
            {
                windowManager.ExecuteCode<ConsoleContent>("control-general:console_status", (console) =>
                {
                    console.ConsoleTextBox.Clear();
                });

                Message = "";
                return true;
            }
            else
            {
                Message = "Window manager not available for getting console object";
                return false;
            }
        }
    }
}
