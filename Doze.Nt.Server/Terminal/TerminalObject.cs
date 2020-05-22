using Doze.Nt.Server.Log;
using Doze.Nt.Server.Terminal.Interface;
using Doze.Nt.Server.Visual;
using Doze.Nt.Server.Visual.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Doze.Nt.Server.Terminal
{
    public enum CommandExecutingResult
    {
        Invalid = -1,
        Success = 0,
        CommandNotFound = 1,
        IncorrectSyntax = 2,
        EmptyInput = 3,
    }

    public class TerminalObject : DozeObject
    {
        private List<ITerminalCommand> Commands { get; set; }

        public TerminalObject()
        {
            Commands = LoadCommands();
        }

        public TerminalObject(string tag) : base(tag)
        {
            Commands = LoadCommands();
        }

        public async Task<TerminalResult> Process(string line)
        {
            CommandExecutingResult result = CommandExecutingResult.Invalid;
            string response = "";

            if (string.IsNullOrEmpty(line))
            {
                response = "Command can not be empty!";
                result = CommandExecutingResult.EmptyInput;
            }

            foreach (var command in GetCommands().Where(command => command.IsExecutable(line)))
            {
                var runResult = await Task.Run(() => command.Run(line));
                if (!runResult)
                {
                    response = command.GetMessage();
                    result = CommandExecutingResult.IncorrectSyntax;

                    break;
                }

                response = command.GetMessage();
                result = CommandExecutingResult.Success;

                break;
            }

            if (result == CommandExecutingResult.Invalid)
            {

                response = $"Command: '{line}' not found!";
                result = CommandExecutingResult.CommandNotFound;
            }

            return new TerminalResult(result, response);
        }

        public List<ITerminalCommand> GetCommands()
            => Commands;

        private List<ITerminalCommand> LoadCommands()
        {
            List<ITerminalCommand> result = new List<ITerminalCommand>();

            var executingAssemble = Assembly.GetExecutingAssembly();
            var commands = executingAssemble.GetTypes().Where((x) => x.GetInterfaces().Contains(typeof(ITerminalCommand)));
            var enumerable = commands as Type[] ?? commands.ToArray();
            if (enumerable.Any())
            {
                result = enumerable.Select((x) => x.GetConstructor(Type.EmptyTypes)?.Invoke(null) as ITerminalCommand)
                    .ToList();
            }

            //var log = GetObjectByType<BaseLog>();
            //log.WriteLine($"Terminal library loaded '' commands", LogLevel.Info);
            //log.WriteLine($"Press '.help' for getting more information", LogLevel.Info);

            return result;
        }
    }
}
