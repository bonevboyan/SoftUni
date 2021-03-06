using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get { return this.radius; }
            set { this.radius = value; }
        }

        public override double CalculateArea()
        {
            return Radius * Radius * Math.PI;
        }

        public override double CalculatePerimeter()
        {

            return Radius * 2 * Math.PI;
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}