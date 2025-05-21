using System;

namespace CSHW2._18_19.Models
{
    [Serializable]
    public class Circle : Figure
    {
        public double Radius { get; set; }

        public Circle(double radius) : base("Круг")
        {
            if (radius <= 0)
                throw new ArgumentException("Радиус круга должен быть положительным.");
            
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Радиус: {Radius}";
        }
    }
}