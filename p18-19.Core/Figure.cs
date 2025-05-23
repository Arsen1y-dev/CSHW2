using System;

namespace p18_19.Core.Models
{
    [Serializable]
    public abstract class Figure : IComparable<Figure>
    {
        public string Name { get; protected set; } 
        
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
        
        public override string ToString()
        {
            return $"Фигура: {Name}, Площадь: {CalculateArea():F2}, Периметр: {CalculatePerimeter():F2}";
        }
        protected Figure(string name)
        {
            Name = name;
        }

        public int CompareTo(Figure other)
        {
            if (other == null) return 1;
            return CalculateArea().CompareTo(other.CalculateArea());
        }
    }
} 