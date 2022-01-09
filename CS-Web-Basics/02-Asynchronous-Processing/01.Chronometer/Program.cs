using System;

namespace _01.Chronometer
{
    class Program
    {
        static void Main(string[] args)
        {
            Chronometer c = new Chronometer();

            bool isRunning = true;

            while (isRunning)
            {
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "start":
                        c.Start();
                        break;
                    case "stop":
                        c.Stop();
                        break;
                    case "lap":
                        Console.WriteLine(c.Lap());
                        break;
                    case "laps":
                        Console.WriteLine("Laps:\n" + (c.Laps.Count == 0 ? "no laps":  string.Join("\n", c.Laps)));
                        break;
                    case "time":
                        Console.WriteLine(c.GetTime);
                        break;
                    case "reset":
                        c.Reset();
                        break;
                    case "exit":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}
