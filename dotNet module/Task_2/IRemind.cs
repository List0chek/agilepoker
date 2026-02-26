using System;

namespace Task_2
{
    /// <summary>
    /// Интерфейс IRemind. 
    /// </summary>
    public interface IRemind
    {
        /// <summary>
        /// Свойство RemindDate.
        /// </summary>
        public DateTime RemindDate { get; set; }
    }
}
