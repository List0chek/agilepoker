using System;

namespace Task_2
{
    /// <summary>
    /// Класс Meeting. Позволяет установить дату начала и дату окончания встречи, производит расчет длительности встречи. 
    /// </summary>
    public class Meeting
    {
        /// <summary>
        /// Время начала встречи.
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Время конца встречи.
        /// </summary>
        public DateTime DateEnd { get; set; }        

        /// <summary>
        /// Производит расчет длительности встречи. 
        /// </summary>
        public TimeSpan Duration
        {
            get 
            { 
                return this.DateEnd - this.DateStart; 
            }
        }

        /// <summary>
        /// Метод SetDates. Позволяет установить дату начала и окончания встречи.
        /// </summary>
        public Meeting(DateTime dateStart, DateTime dateEnd)
        {   
            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
        }
    }
}
