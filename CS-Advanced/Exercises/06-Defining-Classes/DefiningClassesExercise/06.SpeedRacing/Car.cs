using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double DistanceTravelled { get; set; }
        public void Drive(double distance)
        {
            if (FuelConsumptionPerKilometer * distance <= FuelAmount)
            {
                FuelAmount -= FuelConsumptionPerKilometer * distance;
                DistanceTravelled += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}

