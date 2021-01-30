using System;

namespace _06.ForeignLanguages
{
    class ForeignLanguages
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            switch (country)
            {
                case "USA":
                case "England":
                    Console.WriteLine("English");
                    break;
                case "Argentina":
                case "Spain":
                case "Mexico":
                    Console.WriteLine("Spanish");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}
