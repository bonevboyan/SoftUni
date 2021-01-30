using System;

namespace _04.ReverseArrayOfStrings
{
    class ReverseArrayOfStrings
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split(" ");

            for (int i = 0; i < elements.Length / 2; i++)
            {

                String oldElement = elements[i];

                elements[i] = elements[elements.Length - 1 - i];

                elements[elements.Length - 1 - i] = oldElement;

            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
