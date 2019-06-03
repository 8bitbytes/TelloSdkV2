using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Servers
{
    public class TelloMockVideoServer : IStreamingServer
    {
        public event StreamUpdateHandler OnStreamUpdate;

        private bool _streaming = false;
        public void StartStreaming()
        {
            _streaming = true;

            while (_streaming)
            {
                foreach(var file in System.IO.Directory.GetFiles(@"C:\Users\phallock\Pictures\Wallpapers"))
                {
                    var byteArr = System.IO.File.ReadAllBytes(file);
                    OnStreamUpdate(this, byteArr);
                    System.Threading.Thread.Sleep(10000);

                }
            }
            
        }

        public void StopStreaming()
        {
            _streaming = false;
        }
    }
}
