using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Task_3
{
    /// <summary>
    /// Класс треугольник.
    /// </summary>
    public class Triangle : Shape
    {
        public double SideA { get; set; }

        public double SideB { get; set; }

        public double SideC { get; set; }

        public override double GetSidesLength()
        {
            return SideA + SideB + SideC;
        }

        /// <summary>
        /// Метод находит площадь с помощью формулы Герона.
        /// </summary>
        public override double GetArea()
        {
            double halfPerimeter = (SideA + SideB + SideC) * 0.5;            
            return Math.Sqrt(halfPerimeter * (halfPerimeter - SideA) * (halfPerimeter - SideB) * (halfPerimeter - SideC));            
        }

        public Triangle(int x, int y, double sideA, double sideB, double sideC) : base(x, y)
        {
            this.SideA = sideA;
            this.SideB = sideB;
            this.SideC = sideC;
        }
    }
}
