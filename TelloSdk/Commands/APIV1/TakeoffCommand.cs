﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands
{
    public class TakeoffCommand : ICommand
    {
        public CommandTypes CommandType { get; set; }

        public string GenerateCommandString()
        {
            return "takeoff";
        }

    }
}
