using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.APIV1.Commands
{
    public enum CommandTypes
    {
       Command,
       State
    }
    public interface ICommand
    {
        CommandTypes CommandType { get; set; }
        string GenerateCommandString();
    }
}
