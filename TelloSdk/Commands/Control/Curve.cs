using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands.Control
{
    public class Curve : ICommand
    {
        public CommandTypes CommandType { get; set; }

        private int _x1;
        private int _x2;
        private int _y1;
        private int _y2;
        private int _z1;
        private int _z2;
        private int _speed;
        public Curve(int x1, int x2, int y1, int y2, int z1, int z2,int speed)
        {
            _x1 = guardCoordRange(x1);
            _x2 = guardCoordRange(x2);
            _y1 = guardCoordRange(y1);
            _y2 = guardCoordRange(y2);
            _z1 = guardCoordRange(z1);
            _z2 = guardCoordRange(z2);
            _speed = guardSpeed(speed);

            if (!validateArc())
            {
                throw new Exception("Invalid arc calculation. Arc is out of range.");
            }
        }
        public string GenerateCommandString()
        {
            return $"curve {_x1} {_y1} {_z1} {_x2} {_y2} {_z2} {_speed}";
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
            if(val >= 10 && val <= 60)
            {
                return val;
            }
            throw new ArgumentOutOfRangeException($"speed value of {val} is out of range");
        }

        private bool validateArc()
        {
            int width = _x1 + _x2;
            int height = _y1 + _y2;
            double radius = (height / 2) + Math.Pow(width, 2) / (8 * height);
            return radius >= 0.5 && radius <= 10;
        }
    }
}
