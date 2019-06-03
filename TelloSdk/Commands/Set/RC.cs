using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands.Set
{
    public class RC : ICommand
    {
        public CommandTypes CommandType { get; set; }

        private int _leftRight;
        private int _forwardBackward;
        private int _upDown;
        private int _yaw;

        public RC(int leftRight,int forwardBackward,int upDown,int yaw)
        {
            _leftRight = guardValue(leftRight, "leftRight");
            _forwardBackward = guardValue(forwardBackward, "forwardBackward");
            _upDown = guardValue(upDown, "upDown");
            _yaw = guardValue(yaw, "yaw");
        }
        public string GenerateCommandString()
        {
            return $"rc {_leftRight} {_forwardBackward} {_upDown} {_yaw}";
        }

        public int guardValue(int val, string parameter)
        {
            if(val >= -100 && val <= 100)
            {
                return val;
            }
            throw new ArgumentException($"Invalid value {val} for parameter {parameter}");
        }
    }
}
