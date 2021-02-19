using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.ListyIterator
{
    class ListyIterator<T>
    {
        private int currentIndex;
        public ListyIterator(IEnumerable<T> list)
        {
            List = list.ToList();
            currentIndex = 0;
        }
        public List<T> List { get; set; }
        public bool Move()
        {
            if(HasNext())
            {
                currentIndex++;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool HasNext()
        {
            if (currentIndex < List.Count - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Print()
        {
            Console.WriteLine(List.Count == 0 ? "Invalid Operation!": $"{List[currentIndex]}");
        }
    }
}
