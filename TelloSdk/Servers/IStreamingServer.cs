using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Servers
{
    public delegate void StreamUpdateHandler(object sender, byte[] videoData);
    public interface IStreamingServer
    {
        event StreamUpdateHandler OnStreamUpdate;
        void StartStreaming();
        void StopStreaming();
    }
}
