using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, ISearchable
    {
        public string Call(string number)
        {
            Validation.ThrowIfNumberIsInvalid(number);
            return "Calling... " + number;
        }

        public string Search(string site)
        {
            if (site.Any(char.IsDigit))
            {
                throw new InvalidOperationException("Invalid URL!");
            }
            return "Browsing: " + site + "!";
        }
    }
}
