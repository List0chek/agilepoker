using System;

namespace Task_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Circle circle = new Circle(0, 0, 10);
            Shape round = new Round(0, 0, 10);
            var ring = new Ring(0, 0, 10, 5);
            var triangle = new Triangle(0, 0, 5, 3, 4);
            var rectangle = new Rectangle(0, 0, 5, 10);
            var square = new Square(0, 0, 5);
            

            Shape[] shapes = { circle, round, ring, triangle, rectangle, square };

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape.GetType());
                Console.WriteLine("Длина сторон фигуры: {0}", shape.GetSidesLength());                
                Console.WriteLine("Площадь фигуры: {0}", shape.GetArea());
                Console.WriteLine("-------------");
            }
        }
    }
}
