using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
    /// <summary>
    /// Класс фигура.
    /// </summary>
    public abstract class Shape 
    {
        public int X { get; set; }

        public int Y { get; set; }

        /// <summary>
        /// Метод для нахождения длин сторон.
        /// </summary>
        public abstract double GetSidesLength();

        /// <summary>
        /// Метод для нахождения площади фигуры.
        /// </summary>
        public abstract double GetArea();

        public Shape(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
