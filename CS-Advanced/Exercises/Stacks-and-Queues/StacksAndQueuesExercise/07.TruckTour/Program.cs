using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class PetrolPump
    {
        public int liters { get; set; }
        public int distance { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<PetrolPump> elements = new Queue<PetrolPump>();
            for (int i = 0; i < n; i++)
            {
                int[] inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
                elements.Enqueue(new PetrolPump
                {
                    liters = inputs[0],
                    distance = inputs[1]
                })
            }

           
        }
    }
}
