using System.Text;
using System.Net;
using System.Net.Sockets;
using TelloSdk.Commands;
using TelloSdk.Commands.Control;
using TelloSdk.Commands.Read;
using TelloSdk.Commands.Set;

namespace TelloSdk.Servers
{
    public class TelloCommandServer : IServer
    {
        private UdpClient _client;
        private IPAddress _ipaddress;
        private IPEndPoint _endpoint;
        private IPEndPoint _remoteIpEndPoint;
        private bool _commandMode = false;

        public TelloCommandServer(IPAddress ipaddress)
        {
            _client = new UdpClient();
            _ipaddress = ipaddress;
            _endpoint = new IPEndPoint(_ipaddress,8889);
            _remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
        }

        public string SendMessage(ICommand command)
        {
            if(command.CommandType != CommandTypes.Command)
            {
                return "Err";
            }

            var cmd = command as Command;
            if(!_commandMode && cmd == null)
            {
                var resp = enterCommandMode();
                if(resp == "error")
                {
                    throw new System.Exception("Unable to enter command mode");
                }
                _commandMode = true;
            }
            _client.Connect(_endpoint);
            var data = Encoding.ASCII.GetBytes(command.GenerateCommandString());
            _client.Send(data, data.Length);
            _client.Client.ReceiveTimeout = 2500;
            var receivedBytes = _client.Receive(ref _remoteIpEndPoint);

            return Encoding.ASCII.GetString(receivedBytes);

        }
    
        private string enterCommandMode()
        {
            var cmd = new Command();
            _client.Connect(_endpoint);
            var data = Encoding.ASCII.GetBytes(cmd.GenerateCommandString());
            _client.Send(data, data.Length);
            _client.Client.ReceiveTimeout = 2500;
            var receivedBytes = _client.Receive(ref _remoteIpEndPoint);

            return Encoding.ASCII.GetString(receivedBytes);
        }
        public void Close()
        {
            _client.Close();
            _client.Dispose();
        }
    }
}
