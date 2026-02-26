using System;
using System.Globalization;


namespace Task_4
{
    public class DateAndRealNumbersFormatter
    {
        /// <summary>
        /// Примеры форматирования дат.
        /// </summary>
        public static void GetExampleOfDateFormatting()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine("D: " + now.ToString("D"));
            Console.WriteLine("d: " + now.ToString("d"));
            Console.WriteLine("F: " + now.ToString("F"));
            Console.WriteLine("f: {0:f}", now);
            Console.WriteLine("G: {0:G}", now);
            Console.WriteLine("g: {0:g}", now);
            Console.WriteLine("M: {0:M}", now);
            Console.WriteLine("O: {0:O}", now);
            Console.WriteLine("o: {0:o}", now);
            Console.WriteLine("R: {0:R}", now);
            Console.WriteLine("s: {0:s}", now);
            Console.WriteLine("T: {0:T}", now);
            Console.WriteLine("t: {0:t}", now);
            Console.WriteLine("U: {0:U}", now);
            Console.WriteLine("u: {0:u}", now);
            Console.WriteLine("Y: {0:Y}", now);
            Console.WriteLine(now.ToString("MM/dd/yyyy"));
            Console.WriteLine(now.ToString("dddd, dd MMMM yyyy"));
            Console.WriteLine(now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            Console.WriteLine(now.ToString("MM/dd/yyyy HH:mm"));
            Console.WriteLine(now.ToString("MM/dd/yyyy HH:mm:ss"));
            Console.WriteLine(now.ToString("MMMM dd"));
            Console.WriteLine();
            Console.WriteLine(now.ToString("hh:mm:ss"));
            Console.WriteLine(now.ToString("dd.MM.yyyy"));
            Console.WriteLine();
        }

        /// <summary>
        /// Примеры форматирования веществ. чисел.
        /// </summary>
        public static void GetExampleOfRealNumberFormatting()
        {
            double value = 1921680165.6789465489494849;

            Console.WriteLine(value.ToString("E", CultureInfo.InvariantCulture));
            Console.WriteLine(value.ToString("F3", CultureInfo.InvariantCulture));
            Console.WriteLine(value.ToString("F0", CultureInfo.InvariantCulture));

            Console.WriteLine(value.ToString("000-000-000-000"));
            Console.WriteLine(string.Format("{0:[##-##-##]}", value));

            Console.WriteLine(value.ToString(@" ##0 dollars and \0\0 cents "));
            Console.WriteLine(string.Format(@"{0:\#\#\# ##0 dollars and \0\0 cents \#\#\#}", value));
        }
    }
}
