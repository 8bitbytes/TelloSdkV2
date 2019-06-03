using System.Net;
using System.Net.Sockets;

namespace TelloSdk.Servers
{
   public class TelloVideoServer: IStreamingServer
    {
        private UdpClient _client;
        private IPAddress _ipaddress;
        private  IPEndPoint _endpoint;
        private IPEndPoint _remoteIpEndPoint;
        private bool _streaming = false;
        public string Host => _ipaddress.ToString();
        public TelloVideoServer(IPAddress ipaddress)
        {
            _client = new UdpClient();
            _ipaddress = ipaddress;
            _endpoint = new IPEndPoint(_ipaddress,11111);
            _remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
        }

        public event StreamUpdateHandler OnStreamUpdate;

        public void StartStreaming()
        {
            _client.Connect(_endpoint);
            _streaming = true;

            while (_streaming)
            {
                var data = _client.Receive(ref _remoteIpEndPoint);
                if(data != null)
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

        /*public Stream GetVideoStream()
        {
           
            _client.Connect(_endpoint);
            _client.Client.ReceiveTimeout = 2500;
            var receiveBytes = _client.Receive(ref _remoteIpEndPoint);
            _serverReponse = Encoding.ASCII.GetString(receiveBytes);

            if (action.Type == actions.Action.ActionTypes.Read)
            {
                return _serverReponse == "FAIL" ? SdkWrapper.SdkReponses.FAIL
                                                : SdkWrapper.SdkReponses.OK;
            }
            if (action.Type == actions.Action.ActionTypes.CommandMode && _serverReponse == "OK")
            {
                _commandMode = true;
            }
            return _serverReponse == "OK" ? SdkWrapper.SdkReponses.OK
                                          : SdkWrapper.SdkReponses.FAIL;
        }*/

        public void Close()
        {
            _streaming = false;
            _client.Close();
            _client.Dispose();
        }

    }
}
