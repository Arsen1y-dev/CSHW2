using System;

namespace CSHW2._18_19.Models
{
    [Serializable]
    public class Rectangle : Figure
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height) : base("Прямоугольник")
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Ширина и высота прямоугольника должны быть положительными.");
            
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (Width + Height);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Ширина: {Width}, Высота: {Height}";
        }
    }
}