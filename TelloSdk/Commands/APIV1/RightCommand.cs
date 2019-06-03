using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands
{
    public class RightCommand : ICommand
    {
        public CommandTypes CommandType { get; set; }

        private int _distance;
        /// <summary>
        /// Valid value 20-500
        /// </summary>
        /// <param name="distance"></param>
        public RightCommand(int distance)
        {
            if (!Validator.Validate(distance,500,20))
            {
                throw new Exception("distance value out of range");
            }
            _distance = distance;
        }
        public string GenerateCommandString()
        {
            return $"right {_distance}";
        }
    }
}
