using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands
{
    public class GoCommand : ICommand
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
        public GoCommand(int x, int y, int z, int speed)
        {
            if (!validCoord(x) || !validCoord(y) || !validCoord(z))
            {
                throw new Exception("Invalid coordinate");
            }

            //TODO: add helpers for these validators they are used everywhere. 

            if(!)
            if(speed <10  || speed > 100)
            {  
                throw new Exception("Invalid speed");
            }
            _x = x;
            _y = y;
            _x = z;
            _speed = speed;

        }
        public string GenerateCommandString()
        {
            return $"go {_x} {_y} {_z} {_speed}";
        }

        private bool validCoord(int value)
        {
            return value >= 20 && value <= 500;
        }
    }

}
