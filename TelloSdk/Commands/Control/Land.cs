using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands.Control
{
    public class Land : ICommand
    {
        public CommandTypes CommandType { get; set; }
        public string GenerateCommandString()
        {
            return "land";
        }
    }
}
