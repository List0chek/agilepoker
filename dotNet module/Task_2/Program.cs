using System;

namespace Task_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DateTime dateStart;
            DateTime dateEnd;
            DateTime remindDate;
            

            Console.WriteLine("Введите дату начала встречи");
            DateTime.TryParse("04.03.2021 11:00:00", out dateStart);
            Console.WriteLine(dateStart);

            Console.WriteLine("Введите дату окончания встречи");   
            DateTime.TryParse("04.03.2021 12:00:00", out dateEnd);
            Console.WriteLine(dateEnd);

            Console.WriteLine("Введите дату напоминания");
            remindDate = DateTime.Now.AddMinutes(1);
            Console.WriteLine(remindDate);


            MeetingWithReminding meetingWithReminding = new MeetingWithReminding(dateStart, dateEnd, remindDate);
            meetingWithReminding.Remind += DisplayMessage;

            MeetingWithoutEndTime everlastingMeeting = new MeetingWithoutEndTime(dateStart);
            Console.WriteLine(everlastingMeeting.Duration);

            var typeOfMeeting = new MeetingWithType(dateStart, dateEnd, MeetingWithType.MeetingType.BirthDay);
            Console.WriteLine(typeOfMeeting.Type);

            Console.ReadKey();            
        }

        /// <summary>
        /// Метод DisplayMessage - обработчик события Remind, принимает строку Remind?.Invoke("!!!!!!!!!!!!!!!!!!!").
        /// </summary>
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
