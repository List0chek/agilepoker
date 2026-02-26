using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task_10
{
    /// <summary>
    /// Класс FastSearcher. Реализует метод поиска в коллекции значений, соответствующих заданному условию.        
    /// </summary>
    public class FastSearcher
    {
        /// <summary>
        /// Максимальное кол-во параллельных задач.        
        /// </summary>
        private int maxQuantityTasks;

        /// <summary>
        /// Минимальное кол-во значений обрабатываемых в одной задаче.        
        /// </summary>
        private int minQuantityValues;

        /// <summary>
        /// Коллекция, в которой происходит поиск по заданному условию.        
        /// </summary>
        private List<int> collection;

        /// <summary>
        /// Делегат condition. С помощью него передается условие поиска по коллекции.        
        /// </summary>
        private Predicate<int> condition;

        /// <summary>
        /// Чтобы задать maxQuantityTasks и при этом оставить стандартное значение minQuantityValues, нужно воспользоваться именованными параметрами.  
        /// Стандартные значения: maxQuantityTasks = -1, minQuantityValues = 700000. 
        /// Стандартное значение minQuantityValues было выбрано в результате проведенных тестов. При значениях меньше 700000 однопоток работает быстрее.
        /// </summary>
        /// <param name="collection">Коллекция, в которой происходит поиск по заданному условию.</param>
        /// <param name="condition">Делегат через который передается условие поиска по коллекции.</param>
        /// <param name="minQuantityValues">Минимальное кол-во значений обрабатываемых в одной задаче.</param>
        /// <param name="maxQuantityTasks">Максимальное кол-во параллельных задач.</param> 
        public FastSearcher(List<int> collection, Predicate<int> condition, int minQuantityValues = 700000, int maxQuantityTasks = -1)
        {
            this.condition = condition;
            this.maxQuantityTasks = maxQuantityTasks;
            this.minQuantityValues = minQuantityValues;
            this.collection = collection;
        }

        /// <summary>
        /// Метод выполняет поиск в коллекции значений согласно заданному условию. Условие передается с помощью делегата.
        /// Кол-во задач формируется в зависимости от заданного кол-ва значений обрабатываемых в одной задаче.
        /// Если количество задач задано в конструкторе, то метод создаст кол-во потоков на основе введенного значения.
        /// </summary>
        /// <returns>Возвращает коллекцию значений найденных согласно условию.</returns>
        public ConcurrentBag<int> DoComputation()
        {
            var result = new ConcurrentBag<int>();
            double diff = (double)this.collection.Count / this.minQuantityValues;

            if (diff <= 1 && this.maxQuantityTasks == -1)
            {
                this.maxQuantityTasks = 1;
            }
            else if (diff > 1 && this.maxQuantityTasks == -1)
            {
                this.maxQuantityTasks = Convert.ToInt32(Math.Round(diff, MidpointRounding.ToPositiveInfinity));
            }

            Parallel.ForEach(
                this.collection,
                new ParallelOptions { MaxDegreeOfParallelism = this.maxQuantityTasks },
                item =>
                {
                    if (this.condition(item))
                    {
                        result.Add(item);
                    }
                });
            return result;
        }
    }
}
