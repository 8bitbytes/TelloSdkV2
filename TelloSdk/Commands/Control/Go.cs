using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands.Control
{
    public class Go : ICommand
    {
        public CommandTypes CommandType { get; set; }

        private string _commandText;

        private int _x;
        private int _y;
        private int _z;
        private int _speed;

        /// <summary>
        /// go to coordinates at x speed
        /// </summary>
        /// <param name="x">20 - 500</param>
        /// <param name="y">20 - 500</param>
        /// <param name="z">20 - 500</param>
        /// <param name="speed">10 - 100</param>
        public Go(int x, int y, int z, int speed)
        {
            _x = guardCoordRange(x);
            _y = guardCoordRange(y);
            _z = guardCoordRange(z);

            _speed = guardSpeed(speed);

            //TODO: add helpers for these validators they are used everywhere. limits can vary. 
        }
        public string GenerateCommandString()
        {
            return $"go {_x} {_y} {_z} {_speed}";
        }

        private int guardCoordRange(int val)
        {
            if (val >= 20 && val <= 500)
            {
                return val;
            }
            throw new ArgumentOutOfRangeException($"coordinate value of {val} is out of range");
        }

        private int guardSpeed(int val)
        {
            if (val >= 10 && val <= 100)
            {
                return val;
            }
            throw new ArgumentOutOfRangeException($"speed value of {val} is out of range");
        }
    }
}
