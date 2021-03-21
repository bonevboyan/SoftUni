using System;
using System.Collections.Generic;
using System.Text;

namespace _06.ValidPerson
{
    class InvalidPersonNameException : ArgumentException
    {
        public InvalidPersonNameException(string msg)
            :base(msg)
        {

        }
    }
}
