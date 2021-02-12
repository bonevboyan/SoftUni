using System;

namespace _08.Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split();
            string name = command[0] + ' ' + command[1];
            string cityName = command.Length == 4 ? command[3] : command[3] + ' ' + command[4];
            Console.WriteLine(new Threeuple<string, string ,string> { item1 = name, item2 = command[2], item3 = cityName }.ToString());


            command = Console.ReadLine().Split();
            bool isDrunk = command[2] == "drunk" ? true : false;
            Console.WriteLine(new Threeuple<string, int, bool> { item1 = command[0], item2 = int.Parse(command[1]), item3 = isDrunk }.ToString());

            command = Console.ReadLine().Split();
            Console.WriteLine(new Threeuple<string, double, string> { item1 = command[0], item2 = double.Parse(command[1]), item3 = command[2] }.ToString());
        }
    }
}
