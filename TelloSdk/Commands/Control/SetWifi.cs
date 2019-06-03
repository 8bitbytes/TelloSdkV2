using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands.Control
{
    public class SetWifi : ICommand
    {
        public CommandTypes CommandType { get; set; }

        private string _wifiSSID;
        private string _wifiPassword;

        public SetWifi(string ssid,string password)
        {
            _wifiSSID = ssid;
            _wifiPassword = password;
        }

        public string GenerateCommandString()
        {
            return $"wifi {_wifiSSID} {_wifiPassword}";
        }

    }
}
