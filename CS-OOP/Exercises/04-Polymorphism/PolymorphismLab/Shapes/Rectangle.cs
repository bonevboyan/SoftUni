using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Width
        {
            get { return this.width; }
            set { this.width = value; }
        }
        public double Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        public override double CalculateArea()
        {
            return Height * Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Height + 2 * Width;
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
