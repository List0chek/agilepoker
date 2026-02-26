using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Task_5
{
    public class Complex : IComparable
    {
        public int Re { get; set; }

        public int Im { get; set; }

        public Complex(int re = 0, int im = 0)
        {
            this.Re = re;
            this.Im = im;
        }

        /// <summary>
        /// Свойство нахождения модуля.
        /// </summary> 
        public double Module 
        {
            get
            {
                return Math.Sqrt(Math.Pow(this.Re, 2) + Math.Pow(this.Im, 2));
            }
        }

        /// <summary>
        /// Метод сравнения. Если значение объекта меньше значения передаваемого сравниваемого объекта, то возвращается отрицательное значение, если больше – положительное. В случае равенства возвращается нуль. 
        /// </summary> 
        public int CompareTo(Complex other)
        {
           return Math.Sign(this.Module - other.Module);
        }

        public int CompareTo(object obj)
        {
            if (obj is Complex complex)
            {
                return this.CompareTo(complex);
            }
            throw new ArgumentException("Object is not a complex number");
        }
    }
}
