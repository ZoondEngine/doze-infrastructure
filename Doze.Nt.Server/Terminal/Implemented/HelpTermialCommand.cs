using Doze.Nt.Server.Terminal.Interface;
using System;

namespace Doze.Nt.Server.Terminal.Implemented
{
    public class HelpTermialCommand : ITerminalCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public string Message { get; set; }

        public HelpTermialCommand()
        {
            Name = ".help";
            Description = "Getting help about all commands";
            Level = 0;
        }

        public string GetHelp()
            => ".help";

        public string GetMessage()
        {
            if (Message == "") 
                return "nothing";

            var clone = (string)Message.Clone();
            Message = "";

            return clone;
        }

        public bool IsExecutable(string line)
            => line.ToLower() == ".help";

        public bool Run(string line)
        {
            if (line.ToLower() != ".help") 
                return false;

            var allCommands = DozeObject.FindObjectOfType<TerminalObject>().GetCommands();
            foreach (var command in allCommands)
            {
                Message += $"Command: {command.Name}. Description: {command.Description}. Syntax: {command.GetHelp()}" + Environment.NewLine;
            }

            return true;
        }
    }
}
