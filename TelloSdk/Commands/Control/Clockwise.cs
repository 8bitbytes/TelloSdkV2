using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands.Control
{
    public class Clockwise : ICommand
    {
        public CommandTypes CommandType { get; set; }

        private int _distance;
        /// <summary>
        /// Valid value 20-500
        /// </summary>
        /// <param name="distance"></param>
        public Clockwise(int distance)
        {
            if (!Validator.Validate(distance, 3601, 2))
            {
                throw new Exception("distance value out of range");
            }
            _distance = distance;
        }
        public string GenerateCommandString()
        {
            return $"cw {_distance}";
        }
    }
}
