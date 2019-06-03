using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands
{
    public class BackCommand : ICommand
    {
        public CommandTypes CommandType { get; set; }

        private int _distance;
        /// <summary>
        /// Valid value 20-500
        /// </summary>
        /// <param name="distance"></param>
        public BackCommand(int distance)
        {
            if (distance < 20 || distance > 500)
            {
                throw new Exception("distance value out of range");
            }
            _distance = distance;
        }
        public string GenerateCommandString()
        {
            return $"back {_distance}";
        }
    }
}
