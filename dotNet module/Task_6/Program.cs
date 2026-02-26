using System;

namespace Task_6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = "ClientConnectionLog.log";

            var dateStart = new DateTime(2007, 12, 4, 10, 31, 14);
            Console.WriteLine("DateStart: {0}", dateStart);

            var dateEnd = new DateTime(2007, 12, 6, 14, 18, 36);
            Console.WriteLine("DateEnd:   {0}", dateEnd);
            Console.WriteLine();

            Console.WriteLine("Количество записей: {0}", LogParser.GetRecordsQuantity(path, dateStart, dateEnd));
            Console.WriteLine();

            LogParser logParser = new LogParser();
            Console.WriteLine("Преобразование экземпляра класса в строку: {0}", logParser.ToString());
        }
    }
}
