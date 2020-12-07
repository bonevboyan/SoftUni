﻿using System;

namespace _11.VolumeOfPyramid
{
    class VolumeOfPyramid
    {
        static void Main(string[] args)
        {
            Console.Write("Length: ");
            double length = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            double height = double.Parse(Console.ReadLine());
            double volume = (length * width * height ) / 3;
            Console.Write($"Pyramid Volume: {volume:f2}");
        }
    }
}
