using System;

namespace _01.DataTypes
{
    class DataTypes
    {
        public static void PrintResult(int n)
        {
            Console.WriteLine(n * 2);
        }
        public static void PrintResult(double n)
        {
            Console.WriteLine($"{n * 1.5:f2}");
        }
        public static void PrintResult(string n)
        {
            Console.WriteLine($"${n}$");
        }
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            switch (type)
            {
                case "int":
                    int inputInt = int.Parse(Console.ReadLine());
                    PrintResult(inputInt);
                    break;

                case "real":
                    double inputDouble = double.Parse(Console.ReadLine());
                    PrintResult(inputDouble);
                    break;
                case "string":
                    string inputString = Console.ReadLine();
                    PrintResult(inputString);
                    break;
            }
        }
    }
}
