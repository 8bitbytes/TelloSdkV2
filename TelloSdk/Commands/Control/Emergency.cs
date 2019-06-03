using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands.Control
{
    public class Emergency : ICommand
    {
        public CommandTypes CommandType { get; set; }
        public string GenerateCommandString()
        {
            return "emergency";
        }
    }
}
