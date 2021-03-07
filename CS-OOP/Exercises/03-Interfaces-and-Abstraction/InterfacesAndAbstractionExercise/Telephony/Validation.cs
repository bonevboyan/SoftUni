using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public static class Validation
    {
        public static void ThrowIfNumberIsInvalid(string number)
        {
            if (!number.All(char.IsDigit))
            {
                throw new InvalidOperationException("Invalid number!");
            }
        }
    }
}
