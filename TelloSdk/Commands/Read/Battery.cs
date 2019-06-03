using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands.Read
{
    public class Battery : ICommand
    {
        public CommandTypes CommandType { get; set; }

        public string GenerateCommandString()
        {
            return "battery?";
        }
    }
}
