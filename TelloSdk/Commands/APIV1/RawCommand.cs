using System;
using System.Collections.Generic;
using System.Text;
using TelloSdk.Commands;
namespace TelloSdk.Commands
{
    public class RawCommand : ICommand
    {
        public CommandTypes CommandType { get; set; }

        private string _commandText;
        public string GenerateCommandString()
        {
            return _commandText;
        }

        public RawCommand(string command,CommandTypes type)
        {
            CommandType = type;
            _commandText = command;
        }
    }
}
