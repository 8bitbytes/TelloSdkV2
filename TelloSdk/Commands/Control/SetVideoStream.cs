using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands.Control
{
    public class SetVideoStream : ICommand
    {
        public enum States
        {
            On,
            Off
        }

        public SetVideoStream()
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
