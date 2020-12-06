using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Commands
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split(" ").ToList();

            string line = Console.ReadLine();

            while (line != "end") 
            {
                string[] input = line.Split(" ");
                switch (input[0])
                {
                    case "reverse":
                        List<string> reverseList = list.GetRange(int.Parse(input[2]), int.Parse(input[4]));
                        list.RemoveRange(int.Parse(input[2]), int.Parse(input[4]));
                        reverseList.Reverse();
                        list.InsertRange(int.Parse(input[2]), reverseList);
                        break;
                    case "sort":
                        List<string> sortList = list.GetRange(int.Parse(input[2]), int.Parse(input[4]));
                        list.RemoveRange(int.Parse(input[2]), int.Parse(input[4]));
                        sortList.Sort();
                        list.InsertRange(int.Parse(input[2]), sortList);
                        break;
                    case "remove":
                        list.RemoveRange(0, int.Parse(input[1]));
                        break;
                }


                line = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
