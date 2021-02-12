using System;

namespace _07.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split();
            Console.WriteLine(new Tuple<string,string> { item1 = command[0] + ' ' + command[1], item2 = command[2] }.ToString());
            command = Console.ReadLine().Split();
            Console.WriteLine(new Tuple<string, int> { item1 = command[0], item2 = int.Parse(command[1]) }.ToString());
            command = Console.ReadLine().Split();
            Console.WriteLine(new Tuple<int, double> { item1 = int.Parse(command[0]), item2 = double.Parse(command[1]) }.ToString());
        }
    }
}
