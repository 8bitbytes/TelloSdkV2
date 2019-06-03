using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands
{
    public class EmergencyCommand : ICommand
    {
        public CommandTypes CommandType { get; set; }

        private string _commandText;
        public string GenerateCommandString()
        {
            return "emergency";
        }
    }
}