using System;

namespace _01.AdvertisementMessage
{
    class AdvertisementMessage
    {
        static void Main(string[] args)
        {
            string[] phrases = { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            string[] events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] autors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int n = int.Parse(Console.ReadLine());
            Random rng = new Random();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{phrases[rng.Next(0, phrases.Length)]} {events[rng.Next(0, phrases.Length)]} {autors[rng.Next(0, phrases.Length)]} - {cities[rng.Next(0, phrases.Length)]}");
            }
        }
    }
    
}
