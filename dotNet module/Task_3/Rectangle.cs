using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
    /// <summary>
    /// Класс прямоугольник. 
    /// </summary>
    public class Rectangle : Shape
    {
        public double Height { get; set; }

        public double Width { get; set; }        

        public override double GetSidesLength()
        {
            return (Height + Width) * 2;
        }

        public override double GetArea()
        {            
            return Height * Width;
        }

        public Rectangle(int x, int y, double height, double width) : base(x, y)
        {
            this.Height = height;
            this.Width = width;            
        }
    }
}
