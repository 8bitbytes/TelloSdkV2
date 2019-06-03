using System.Text;
using System.Net;
using System.Net.Sockets;
using TelloSdk.Commands;

namespace TelloSdk.Servers
{
    public class TelloStateServer : IStreamingServer
    {
        private UdpClient _client;
        private IPAddress _ipaddress;
        private IPEndPoint _endpoint;
        private IPEndPoint _remoteIpEndPoint;
        private bool _streaming = false;

        public TelloStateServer(IPAddress ipaddress)
        {
            _client = new UdpClient();
            _ipaddress = ipaddress;
            _endpoint = new IPEndPoint(_ipaddress, 8890);
            _remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
        }

        //public delegate void StreamUpdateHandler(object sender, byte[] stateData);
        public event StreamUpdateHandler OnStreamUpdate;
        public void StartStreaming()
        {
            _client.Connect(_endpoint);
            _streaming = true;

            while (_streaming)
            {
                var data = _client.Receive(ref _remoteIpEndPoint);
                if (data != null)
                {
                    OnStreamUpdate(this, data);
                }

            }
        }
        public void StopStreaming()
        {
            _streaming = false;
            _client.Close();
        }
        public void Close()
        {
            _client.Close();
            _client.Dispose();
        }
    }
}
