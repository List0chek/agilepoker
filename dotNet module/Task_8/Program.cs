using System;
using System.Collections.Generic;
using System.IO;

namespace Task_8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(MaxFromThree.GetMaxFromThreeElements(12, 14, 16));
            Console.WriteLine(MaxFromThree.GetMaxFromThreeElements(12.3, 16.3, 14.3));
            Console.WriteLine();

            var list = new List<string>() { "Task_2", "Task_3", "Task_4", "Task_5", "Task_6", "Task_7", "Task_8" };
            foreach (string str in list)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();

            var valuePairsExample = new Dictionary<string, DateTime>();
            valuePairsExample.Add("Вчера", DateTime.Now.AddDays(-1));
            valuePairsExample.Add("Сегодня", DateTime.Now);
            valuePairsExample.Add("Завтра", DateTime.Now.AddDays(1));
            foreach (KeyValuePair<string, DateTime> keyValuePair in valuePairsExample)
            {
                Console.WriteLine("{0} в {1}", keyValuePair.Key, keyValuePair.Value);
            }
            Console.WriteLine();


            using (var textFileBruteForce = new TextFileReader("1000nows.txt"))
            {
                foreach (var item in textFileBruteForce)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
