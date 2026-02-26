using System;

namespace Task_4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataSetUtils.GetExampleDataSet();

            ShowAccessCheckerExample();
            Console.WriteLine();

            DateAndRealNumbersFormatter.GetExampleOfDateFormatting();
            DateAndRealNumbersFormatter.GetExampleOfRealNumberFormatting();

            // Пример использования класса Logger.
            using (var logger = new Logger("1000nows.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    logger.WriteString(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                }
            }
            Console.WriteLine();

            StringConcatAnalyzer.StringConcatAnalyzeExmaple();
        }

        public static void ShowAccessCheckerExample()
        {
            AccessRightsChecker.ShowAccessRights(AccessRightsChecker.AccessRights.AccessDenied | AccessRightsChecker.AccessRights.Add | AccessRightsChecker.AccessRights.Ratify);
            AccessRightsChecker.ShowAccessRights(AccessRightsChecker.AccessRights.Add | AccessRightsChecker.AccessRights.Ratify);
        }
    }
}
