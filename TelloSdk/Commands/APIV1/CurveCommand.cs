using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk.Commands
{
    public class CurveCommand : ICommand
    {
        public CommandTypes CommandType { get; set; }

        private int _x1;
        private int _x2;
        private int _y1;
        private int _y2;
        private int _z1;
        private int _z2;
        public CurveCommand(int x1, int x2, int y1, int y2,int z1, int z2)
        {
            _x1 = x1;
            _x2 = x2;
            _y1 = y1;
            _y2 = y2;
            _z1 = z1;
            _z2 = z2;
        }
        public string GenerateCommandString()
        {
            throw new NotImplementedException();
        }
    }
}
