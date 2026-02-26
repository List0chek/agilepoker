using System;

namespace Task_9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var date = new DateTime(2007, 12, 4);
            Console.WriteLine("Date: {0}", date);
            Console.WriteLine();


            foreach (var line in LogSorter.GetRecordsSorted("ClientConnectionLogs.log", date))
            {
                Console.WriteLine(line);
            }
        }
    }
}
