using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelloApi.Models
{
    public class RCParams
    {
        public int LeftRight { get; set; }
        public int ForwardBack { get; set; }
        public int UpDown { get; set; }
        public int Yaw { get; set; }
    }
}
