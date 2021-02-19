using System;
using System.Linq;

namespace _02.Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            ListyIterator<string> list = new ListyIterator<string>(command
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(o => o != "Create"));
            command = Console.ReadLine();
            while (command != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "Print":
                        list.Print();
                        break;
                    case "PrintAll":
                        Console.WriteLine(string.Join(' ', list));
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "END":
                        return;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
