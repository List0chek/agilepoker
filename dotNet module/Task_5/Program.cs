using System;
using System.Collections;
using System.Reflection;

namespace Task_5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stringValue1 = new StringValue(null);
            var stringValue2 = new StringValue("AAA");

            Console.WriteLine(stringValue1.Equals(stringValue2));
            Console.WriteLine(new StringValue("AAA").Equals(new StringValue("AAA")));

            Console.WriteLine(stringValue1 == stringValue2);
            Console.WriteLine(new StringValue("AAA") == (new StringValue("AAA")));
            
            Console.WriteLine();
            var twoComplexes = new ArrayList() { new Complex() { Re = 3, Im = 5 }, new Complex() { Re = 2, Im = 2 }, new Complex() };
            twoComplexes.Sort();
            foreach (Complex complex in twoComplexes)
            {
                Console.WriteLine("Re = " + complex.Re + ", Im = " + complex.Im);
            }
        }
    }
}
