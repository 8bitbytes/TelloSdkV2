using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands.Control
{
    public class Down : ICommand
    {
        public CommandTypes CommandType { get; set; }

        private int _distance;
        /// <summary>
        /// Valid value 20-500
        /// </summary>
        /// <param name="distance"></param>
        public Down(int distance)
        {
            _distance = guardDistance(distance);
        }
        public string GenerateCommandString()
        {
            return $"down {_distance}";
        }

        private int guardDistance(int val)
        {
            if(val >= 20  && val <= 500)
            {
                return val;
            }

            throw new ArgumentOutOfRangeException($"{val} is out of range for parameter distance");
        }
    }
    
}
