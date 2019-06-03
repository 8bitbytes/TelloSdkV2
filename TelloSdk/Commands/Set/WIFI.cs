using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands.Set
{
    public class WIFI : ICommand
    {
        public CommandTypes CommandType { get; set; }

        private string _ssid;
        private string _password;
        public WIFI(string ssid, string password)
        {
            _ssid = ssid;
            _password = password;
        }
        public string GenerateCommandString()
        {
            return $"wifi {_ssid} {_password}";
        }
    }
}
