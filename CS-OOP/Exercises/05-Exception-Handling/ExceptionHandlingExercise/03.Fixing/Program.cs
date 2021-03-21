using System;

namespace _03.Fixing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weekdays = new string[5] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday" };
            try
            {
                for (int i = 0; i < weekdays.Length; i++)
                {
                    Console.WriteLine(weekdays[i].ToString());
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
