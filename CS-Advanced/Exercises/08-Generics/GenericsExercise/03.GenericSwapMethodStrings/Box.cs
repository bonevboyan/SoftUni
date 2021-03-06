﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _03.GenericSwapMethodStrings
{
    public class Box<T>
    {
        public T Value { get; set; }
        public string ToString()
        {
            return $"{typeof(T)}: {Value}";
        }
    }
}
