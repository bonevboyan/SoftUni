using System;

namespace _02.CommonElements
{
    class CommonElements
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split(" ");
            string[] secondArray = Console.ReadLine().Split(" ");
            foreach (string i in
             secondArray)
            {
                foreach (string j in
                    firstArray)
                {
                    if (i.Equals(j))
                    {
                        Console.Write(i + " ");
                    }
                }
            }
        }
    }
}
