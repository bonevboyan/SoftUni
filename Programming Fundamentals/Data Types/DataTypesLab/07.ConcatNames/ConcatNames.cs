using System;

namespace _07.ConcatNames
{
    class ConcatNames
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string delimiter = Console.ReadLine();
            string result = firstName + delimiter + lastName;
            Console.WriteLine(result);
        }
    }
}
