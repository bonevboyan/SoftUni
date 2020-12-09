using System;

namespace _01.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string line = Console.ReadLine();
            while (line != "Generate")
            {
                string[] tokens = line.Split(">>>");
                switch (tokens[0])
                {
                    case "Contains":
                        if (key.Contains(tokens[1]))
                        {
                            Console.WriteLine(key + " contains " + tokens[1]);
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        switch (tokens[1])
                        {
                            case "Upper":
                                key = key.Substring(0, int.Parse(tokens[2])) + key.Substring(int.Parse(tokens[2]), int.Parse(tokens[3]) - int.Parse(tokens[2])).ToUpper() + key.Substring(int.Parse(tokens[3]), key.Length - int.Parse(tokens[3]));
                                Console.WriteLine(key);
                                break;
                            case "Lower":
                                key = key.Substring(0, int.Parse(tokens[2])) + key.Substring(int.Parse(tokens[2]), int.Parse(tokens[3]) - int.Parse(tokens[2])).ToLower() + key.Substring(int.Parse(tokens[3]), key.Length - int.Parse(tokens[3]));
                                Console.WriteLine(key);
                                break;
                        }
                        break;
                    case "Slice":
                        key = key.Substring(0, int.Parse(tokens[1])) + key.Substring(int.Parse(tokens[2]), key.Length - int.Parse(tokens[2]));
                        Console.WriteLine(key);
                        break;
                }
                line = Console.ReadLine();
            }
            Console.WriteLine("Your activation key is: " + key);
        }
    }
}
