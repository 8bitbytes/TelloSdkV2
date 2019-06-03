using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands.Control
{
    public class Flip : ICommand
    {
        public enum FlipDirections
        {
            Forward,
            Back,
            Left,
            Right
        }
        public CommandTypes CommandType { get; set; }
        public FlipDirections Direction { get; set; }

        public Flip(FlipDirections direction)
        {
            Direction = direction;
        }
        public string GenerateCommandString()
        {
            return $"cw {Direction.ToString()[0].ToString().ToLowerInvariant()}";//<- ugly right :)
        }
    }
}
