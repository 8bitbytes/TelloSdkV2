using System;
using System.Collections.Generic;
using System.Text;
using TelloSdk.Commands;
namespace TelloSdk.Servers
{
    public interface IServer
    {
        string SendMessage(ICommand command);
    }
}
