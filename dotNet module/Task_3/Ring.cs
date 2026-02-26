using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
    /// <summary>
    /// Класс кольцо. 
    /// </summary>
    public class Ring : Circle
    {
        public double InnerR { get; set; }

        /// <summary>
        /// Конструктор класса Ring. Где r - внешний радиус, а innerR - внутренний радиус кольца.
        /// </summary>
        public Ring(int x, int y, double r, double innerR) : base(x, y, r)
        {
            this.InnerR = innerR;
        }

        /// <summary>
        /// Метод для нахождения длины внутренней окружности. 
        /// </summary>
        public double GetInnerCircumference()
        {
            return 2 * Math.PI * InnerR;
        }

        public override double GetArea()
        {            
            return Math.PI * (Math.Pow(R, 2) - Math.Pow(InnerR, 2));
        }
    }
}
