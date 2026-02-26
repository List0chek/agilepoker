using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;

namespace Task_10
{
    /// <summary>
    /// Класс Program.        
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Метод Main. Точка входа в программу.        
        /// </summary>
        /// <param name="args">Аргументы метода Main.</param>
        public static void Main(string[] args)
        {
            var list = new List<int>();
            var resultList = new ConcurrentBag<int>();
            for (int i = 0; i < 1000000; i++)
            {
                list.Add(i);
            }

            Predicate<int> predicate;
            var fastSearcher = new FastSearcher(list, predicate = delegate(int x) { return x > 0; }, maxQuantityTasks: 10);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            resultList = fastSearcher.DoComputation();
            stopwatch.Stop();
            Console.WriteLine("Время выполнения: {0}", stopwatch.Elapsed);
        }
    }
}
