using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        public Parking(int capacity)
        {
            Capacity = capacity;
            Cars = new List<Car>(capacity);
        }
        public List<Car> Cars { get; set; }
        public int Capacity { get; set; }
        public int Count => Cars.Count;
        public string AddCar(Car car)
        {
            if(Cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if(Cars.Count >= Capacity)
            {
                return "Parking is full!";
            }
            else
            {
                Cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }
        public string RemoveCar(string registrationNumber)
        {
            if (!Cars.Any(c => c.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Cars.Remove(Cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber));
                return $"Successfully removed {registrationNumber}";
            }
        }
        public Car GetCar(string registrationNumber)
        {
            return Cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var number in registrationNumbers)
            {
                if (Cars.Any(c => c.RegistrationNumber == number))
                {
                    Cars.Remove(Cars.FirstOrDefault(c => c.RegistrationNumber == number));
                }
            }
        }
    }
}
