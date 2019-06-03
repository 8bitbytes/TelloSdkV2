using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Servers
{
    public class TelloMockStateServer : IStreamingServer
    {
        private bool _streaming = false;

        //public delegate void StateServerUpdateHandler(object sender, byte[] stateData);
        public event StreamUpdateHandler OnStreamUpdate;

        public List<string> _actions = new List<string>
        {
            "Acceleration",
            "Attitude",
            "Barometer",
            "Battery",
            "Height",
            "Speed",
            "Temp"
        };
        public void StartStreaming()
        {
            _streaming = true;

            while (_streaming)
            {
                OnStreamUpdate(this, getMockValue());
                System.Threading.Thread.Sleep(2000);
            }
        }

        public void StopStreaming()
        {
            _streaming = false;
        }

        private byte[] getMockValue()
        {
            var rnd = new Random(DateTime.Now.Millisecond + DateTime.Now.Minute);
            var action = _actions[rnd.Next(_actions.Count - 1)];
            var val = rnd.Next(100);
            return Encoding.ASCII.GetBytes($"{action}:{val}");
        }
    }
}
