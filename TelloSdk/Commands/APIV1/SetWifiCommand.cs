using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands
{
    public class SetWifiCommand : ICommand
    {
        public CommandTypes CommandType { get; set; }

        private string _wifiSSID;
        private string _wifiPassword;

        public SetWifiCommand(string ssid,string password)
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
