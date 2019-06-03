using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands.Read
{
    public class Attitude : ICommand
    {
        public CommandTypes CommandType { get; set; }

        public string GenerateCommandString()
        {
            return "attitude?";
        }
    }
}
