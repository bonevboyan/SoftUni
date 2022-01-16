using BasicWebServer.Server.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicWebServer.Server.HTTP
{
    public class Header
    {
        public Header(string name, string value)
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));

            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}
