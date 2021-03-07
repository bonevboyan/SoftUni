using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (var number in numbers)
            {
                try
                {
                    string result = number.Length == 10 ? smartphone.Call(number) : stationaryPhone.Call(number);
                    Console.WriteLine(result);
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            foreach (var site in sites)
            {
                try
                {
                    string result = smartphone.Search(site);
                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
