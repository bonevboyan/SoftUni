using System;

namespace _05.Login
{
    class Login
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string password = string.Empty;

            for (int i = userName.Length - 1; i >= 0; i--)
            {
                char symbol = userName[i];
                password += symbol;
            }

            for (int i = 0; i < 4; i++)
            {
                string currentPassword = Console.ReadLine();

                if (currentPassword == password)
                {
                    Console.WriteLine($"User {userName} logged in.");
                    break;
                }
                else if (password != currentPassword && i >= 0 && i < 3)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
                else if (password != currentPassword && i == 3)
                {
                    Console.WriteLine($"User {userName} blocked!");
                }
            }
        }
    }
}
