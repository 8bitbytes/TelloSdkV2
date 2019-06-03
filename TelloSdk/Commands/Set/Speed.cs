using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands.Set
{
    public class Speed : ICommand
    {
        public CommandTypes CommandType { get; set; }

        private int _speed;
        public Speed(int speed)
        {
            _speed = guardSpeed(speed);
        }
        public string GenerateCommandString()
        {
            return $"speed {_speed}";
        }

        public int guardSpeed(int val)
        {
            if(val >= 10 && val <= 10)
            {
                return val;
            }
            throw new ArgumentOutOfRangeException($"{val} is not in range for parameter speed");
        }

    }
}
