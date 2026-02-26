using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
    /// <summary>
    /// Класс квадрат.
    /// </summary>
    public class Square : Rectangle
    {        
        public double Side { get; set; }

        public override double GetSidesLength()
        {
            return Side * 4;
        }        

        public Square(int x, int y, double side) : base(x, y, side, side)
        {
            this.Side = side;            
        }
    }
}
