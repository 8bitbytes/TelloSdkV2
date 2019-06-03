using System;
using System.Net;
using System.Collections.Generic;
using TelloSdk.Commands;
using TelloSdk.Commands.Control;
using TelloSdk.Commands.Read;
using TelloSdk.Commands.Set;
using TelloSdk.Servers;
using System.ComponentModel;
namespace TelloSdk
{
    public class TelloManager
    {
        /*private TelloVideoServer _videoServer;
        private TelloCommandServer _commandServer;
        private TelloStateServer _stateServer;*/

        private IStreamingServer _videoServer;
        private IServer _commandServer;
        private IStreamingServer _stateServer;
        private IPAddress _ipaddress;

        private BackgroundWorker _bgStateServer;
        private BackgroundWorker _bgVideoServer;

        public delegate void VideoStreamUpdateHandler(object sender, byte[] videoData);
        public event VideoStreamUpdateHandler OnVideoStreamUpdate;

        public delegate void StateServerUpdateHandler(object sender, byte[] stateData);
        public event StateServerUpdateHandler OnStateServerUpdate;

        public string Host => _ipaddress.ToString();

        public TelloManager(string droneIPAddress,IStreamingServer videoServer,IStreamingServer stateServer,IServer commandServer)
        {
            _ipaddress = IPAddress.Parse(droneIPAddress);
            _videoServer = videoServer;
            _stateServer = stateServer;
            _commandServer = commandServer;

            initServers(droneIPAddress);
            _bgStateServer = new BackgroundWorker();
            _bgVideoServer = new BackgroundWorker();

            _bgStateServer.DoWork += StateServer_DoWork;
            _bgVideoServer.DoWork += VideoServer_DoWork;

            startStreamServers();
        }

        private void VideoServer_DoWork(object sender, DoWorkEventArgs e)
        {
            _videoServer.StartStreaming();
        }

        private void StateServer_DoWork(object sender, DoWorkEventArgs e)
        {
            _stateServer.StartStreaming();
        }

        private void initServers(string droneIPAddress)
        {
            var ipAddress = IPAddress.Parse(droneIPAddress);

            /*_commandServer = new TelloCommandServer(ipAddress);
            _stateServer = new TelloStateServer(ipAddress);
            _videoServer = new TelloVideoServer(ipAddress);*/
            //_commandServer = new TelloMockCommandServer();
            //_stateServer = new TelloMockStateServer();
            //_videoServer = new TelloMockVideoServer();
            _videoServer.OnStreamUpdate += VideoServer_OnVideoStreamUpdate;
            _stateServer.OnStreamUpdate += StateServer_OnStateServerUpdate;
        }

        private void startStreamServers()
        {
            _bgStateServer.RunWorkerAsync();
            _bgVideoServer.RunWorkerAsync();
        }

        private void StateServer_OnStateServerUpdate(object sender, byte[] stateData)
        {
            OnStateServerUpdate?.Invoke(this, stateData);
        }

        private void VideoServer_OnVideoStreamUpdate(object sender, byte[] videoData)
        {

            OnVideoStreamUpdate?.Invoke(this, videoData);
        }


        public string SendCommand(ICommand command)
        {
           return  _commandServer.SendMessage(command);
        }

        /// <summary>
        /// Will enable the video stream. Make sure to subscribe to the update event to get latest video frame
        /// </summary>
        public void StartVideoStream()
        {
            var cmd = new SetVideoStream();
            cmd.VideoStreamState = SetVideoStream.States.On;
            var resp = SendCommand(cmd);

            if(resp != "ok")
            {
                throw new Exception("Unable to start video stream");
            }
        }

        public void StopVideoStream()
        {
            var cmd = new SetVideoStream();
            cmd.VideoStreamState = SetVideoStream.States.Off;
            var resp = SendCommand(cmd);

            if (resp != "ok")
            {
                throw new Exception("Unable to stop video stream");
            }
        }


    }
}
