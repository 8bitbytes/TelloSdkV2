using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands
{
    public class SetVideoStreamCommand : ICommand
    {
        public enum States
        {
            On,
            Off
        }

        public SetVideoStreamCommand()
        {
            CommandType = CommandTypes.Command;
        }
        public States VideoStreamState { get; set; }
        public CommandTypes CommandType { get; set;}

        public string GenerateCommandString()
        {
            return VideoStreamState == States.Off ? "streamoff" : "streamon";
        }
    }
}
