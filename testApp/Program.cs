using System;
using TelloSdk;
using TelloSdk.Servers;
using TelloSdk.Commands.Control;
using TelloSdk.Commands.Set;
using TelloSdk.Commands.Read;
namespace testApp
{
    class Program
    {
        static int imageCount = 0;
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");
            var manager = new TelloManager("192.168.1.1",new TelloMockVideoServer(),new TelloMockStateServer(),new TelloMockCommandServer());
            manager.OnVideoStreamUpdate += Manager_OnVideoStreamUpdate;//only required if you care to see the video
            manager.OnStateServerUpdate += Manager_OnStateServerUpdate;
            manager.SendCommand(new Command());
            manager.SendCommand(new Takeoff());

            var continueRun = true;

            while (continueRun)
            {
                if(Console.ReadLine() == "exit")
                {
                    continueRun = false;
                }
            }
        }

        private static void Manager_OnStateServerUpdate(object sender, byte[] stateData)
        {
            Console.WriteLine($"state server data {System.Text.Encoding.ASCII.GetString(stateData, 0, stateData.Length - 1)}");
        }

        private static void Manager_OnVideoStreamUpdate(object sender, byte[] videoData)
        {
            imageCount++;

            Console.WriteLine("updated video stream");

            System.IO.File.WriteAllBytes($"{DateTime.Now.Minute}_{imageCount}.jpg",videoData);
        }
    }
}
