using System;
using System.Collections.Generic;
using System.Text;

namespace TelloSdk
{
    public class Validator
    {
        public static bool Validate(int value, int upperVal, int lowerVal)
        {
            return value >= lowerVal && value <= upperVal;
        }
    }
}
