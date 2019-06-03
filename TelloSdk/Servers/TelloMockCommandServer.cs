using System;
using System.Collections.Generic;
using System.Text;
using TelloSdk.Commands;

namespace TelloSdk.Servers
{
    public class TelloMockCommandServer : IServer
    {
        public string SendMessage(ICommand command)
        {
            var cmd = command as Commands.Control.Command;
            Console.WriteLine(command.GenerateCommandString());
            return "OK";
        }
    }
}
