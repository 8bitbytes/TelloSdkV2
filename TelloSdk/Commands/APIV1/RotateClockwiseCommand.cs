﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands
{
    public class RotateClockwiseCommand : ICommand
    {
        public CommandTypes CommandType { get; set; }

        private int _distance;
        /// <summary>
        /// Valid value 20-500
        /// </summary>
        /// <param name="distance"></param>
        public RotateClockwiseCommand(int distance)
        {
            if(!Validator.Validate(distance,3601,2))
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
