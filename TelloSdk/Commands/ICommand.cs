using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands
{
    public enum CommandTypes
    {
        Command,
        Read,
        Set
    }

    public interface ICommand
    {
        CommandTypes CommandType { get; set; }
        string GenerateCommandString();
    }
}
