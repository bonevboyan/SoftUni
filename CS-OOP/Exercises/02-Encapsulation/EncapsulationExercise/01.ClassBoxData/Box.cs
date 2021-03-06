using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
        public double Length
        {
            get => length;

            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Length cannot be zero or negative.");
                    Environment.Exit(0);
                }

                length = value;
            }
        }

        public double Width
        {
            get => width;

            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Width cannot be zero or negative.");
                    Environment.Exit(0);
                }

                width = value;
            }
        }

        public double Height
        {
            get => height;

            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Height cannot be zero or negative.");
                    Environment.Exit(0);
                }

                height = value;
            }
        }
        public double GetLateralSurfaceArea() => 2 * (Length * Height) + 2 * (Width * Height);

        public double GetVolume() => Height * Length * Width;

        public double GetSurfaceArea() => 2 * (Length * Height) + 2 * (Width * Height) + 2 * (Length * Width);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {GetSurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {GetLateralSurfaceArea():F2}");
            sb.Append($"Volume - {GetVolume():F2}");

            return sb.ToString();
        }
    }
}
