using System;

namespace _05.DecryptingMessage
{
    class DecryptingMessage
    {
        static void Main(string[] args)
        {
            byte descriptionKey = byte.Parse(Console.ReadLine());
            byte charactersCount = byte.Parse(Console.ReadLine());
            string message = "";

            while (charactersCount > 0)
            {
                message += (char)(Console.ReadLine()[0] + descriptionKey);

                charactersCount--;
            }
            Console.WriteLine(message);
        }
    }
}
