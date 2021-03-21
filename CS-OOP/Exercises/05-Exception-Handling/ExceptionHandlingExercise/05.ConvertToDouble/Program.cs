using System;

namespace _05.ConvertToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double num = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
