using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            while (command != "end")
            {
                if(command == "print")
                {
                    Console.WriteLine(string.Join(' ', nums));
                }
                else
                {
                    nums = nums.Select(getOperation(command)).ToArray();
                }
                command = Console.ReadLine();
            }
        }
        static Func<int, int> getOperation(string filter)
        {
            switch (filter)
            {
                case "add": return p => p + 1;
                case "multiply": return p => p * 2;
                case "subtract": return p => p - 1;
                default:
                    return null;
            }
        }
    }
}
