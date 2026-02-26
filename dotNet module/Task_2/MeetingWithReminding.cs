using System;
using System.Timers;

namespace Task_2
{
    public class MeetingWithReminding : Meeting, IRemind
    {
        /// <summary>
        /// Константа TimerIntervalCheck. 
        /// </summary>
        private const int TimerIntervalCheck = 1000;

        /// <summary>
        /// Свойство RemindDate.
        /// </summary>
        public DateTime RemindDate { get; set; }

        /// <summary>
        /// timer - Экземпляр System.Timers.Timer.
        /// </summary>
        private Timer timer;        

        /// <summary>
        /// Объявление делегата, принимает строку.
        /// </summary>
        public delegate void RemindEventHandler(string msg);

        /// <summary>
        /// Объявление события Remind, которое представляет делегат RemindEventHandler.
        /// </summary>
        public event RemindEventHandler Remind;

        /// <summary>
        /// Конструктор MeetingWithReminding. 
        /// Принимает на вход дату начала и окончания встречи, а также дату напоминания о встрече. 
        /// Вычисляет время до напоминания. Запускает таймер. Каждую минуту таймер обращается к методу Timer_Tick.
        /// </summary>
        public MeetingWithReminding(DateTime dateStart, DateTime dateEnd, DateTime remindDate) : base(dateStart, dateEnd)
        {            
            this.RemindDate = remindDate;
            var timeBeforeMeeting = new TimeSpan();
            timeBeforeMeeting = remindDate - DateTime.Now;
            Console.WriteLine("Время до начала напоминания: {0}", timeBeforeMeeting);
            timer = new Timer();
            timer.Interval = TimerIntervalCheck;
            timer.Elapsed += Timer_Tick;
            timer.Start();
        }

        /// <summary>
        /// Метод Timer_Tick - обработчик события Elapsed.       
        /// Если время до напоминания <= 0, то запускает событие Remind (в Remind передается строка, т.к. делегат RemindEventHandler принимает параметр типа string), прекращает вызывать Elapsed. 
        /// Если время до напоминания > 0, то вычитает из времени до напоминания минуту.         
        /// </summary>
        public void Timer_Tick(object source, ElapsedEventArgs e)
        {            
            if (RemindDate <= DateTime.Now)
            {
                Console.WriteLine(RemindDate);                
                Remind?.Invoke("!!!!!!!!!!!!!!!!!!!");
                timer.Stop(); 
            }
            else if (RemindDate > DateTime.Now)
            {                
                Console.WriteLine(".");
            }            
        }
    }
}
