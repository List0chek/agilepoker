using System;
using System.Globalization;
using System.IO;

namespace Task_6
{
    public class LogParser
    {
        /// <summary>
        /// Метод для получения числа записей из лога за выбранный промежуток дат.
        /// </summary> 
        public static int GetRecordsQuantity(string path, DateTime dateStart, DateTime dateEnd)
        {
            string[] lines = File.ReadAllLines(path);
            int i = 0;
            DateTime dateTime;
            int dateLength = "dd.MM.yyyy\tHH:mm:ss".Length;
            foreach (string line in lines)
            {
                if (DateTime.TryParseExact(line.Substring(0, dateLength), "dd.MM.yyyy\tHH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                {
                    if ((dateTime >= dateStart) && (dateEnd >= dateTime))
                    {
                        i++;
                    }
                }
            }
            return i;
        }
    }
}
