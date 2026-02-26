using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
    /// <summary>
    /// Класс круг.
    /// </summary>
    public class Round : Circle
    {
        public Round(int x, int y, double r) : base(x, y, r) { }       

        public override double GetArea()
        {            
            return Math.PI * R * R;
        }
    }
}
