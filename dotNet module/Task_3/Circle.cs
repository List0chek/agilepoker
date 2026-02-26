using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
    /// <summary>
    /// Класс окружность.
    /// </summary>
    public class Circle : Shape
    {    
        public double R { get; set; }        

        public override double GetSidesLength()
        {
            return 2 * Math.PI * R;
        }

        /// <summary>
        /// Метод для нахождения площади. Возвращает ноль, т.к. окружность не имеет площади. 
        /// </summary>
        public override double GetArea()
        {         
            return 0.0;
        }

        public Circle(int x, int y, double r) : base(x, y)
        {
            this.R = r;
        }
    }
}
