using System;

namespace _05.MonthPrinter
{
    class MonthPrinter
    {
        static void Main(string[] args)
        {
            string[] month = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int monthNum = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine(month[monthNum - 1]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Error!");
            }
        }
    }
}