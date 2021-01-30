using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> carsQueue = new Queue<string>();

            int counter = 0;

            while (true)
            {
                string command = Console.ReadLine();

                int greenLights = greenLight;
                int freeWindows = freeWindow;

                if (command == "END")
                {
                    Console.WriteLine($"Everyone is safe.\n{counter} total cars passed the crossroads.");
                    return;
                }
                else if (command == "green")
                {
                    while (greenLights > 0 && carsQueue.Count != 0)
                    {

                        string firstInQueue = carsQueue.Dequeue();
                        greenLights -= firstInQueue.Count();
                        if (greenLights >= 0)
                        {
                            counter++;
                        }
                        else
                        {
                            freeWindows += greenLights;
                            if (freeWindows < 0)
                            {
                                Console.WriteLine($"A crash happened!\n{firstInQueue} was hit at {firstInQueue[firstInQueue.Length + freeWindows]}.");
                                return;
                            }
                            counter++;
                        }
                    }
                }
                else
                {
                    carsQueue.Enqueue(command);
                }
            }
        }
    }
}
