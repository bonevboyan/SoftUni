using System;
using System.Linq;

namespace _01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();
            string line = Console.ReadLine();
            while (line != "Done")
            {
                string[] tokens = line.Split();
                string command = tokens[0];
                if(command == "TakeOdd")
                {
                    string newPass = string.Empty;
                    for (int i = 1; i < pass.Length; i += 2)
                    {
                        newPass += pass[i];
                    }
                    pass = newPass;
                    Console.WriteLine(pass);
                }
                else if (command == "Cut")
                {
                    int index = int.Parse(tokens[1]);
                    int length = int.Parse(tokens[2]);
                    pass = pass.Remove(index, length);
                    Console.WriteLine(pass);

                }
                else if (command == "Substitute")
                {
                    string substing = tokens[1];
                    string substitute = tokens[2];
                    if (pass.Contains(substing))
                    {
                        pass = pass.Replace(substing, substitute);
                        Console.WriteLine(pass);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
                line = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {pass}");
        }
    }
}
