using System;
using System.Collections.Generic;
using System.Text;

namespace _05.GenericCountMethodString
{
    public class Box<T> : IComparable<T>
        where T : IComparable<T>
    {
        public T Value { get; set; }

        public int CompareTo(T value)
        {
            return Value.CompareTo(value);
        }

        public string ToString()
        {
            return $"{typeof(T)}: {Value}";
        }
    }
}
