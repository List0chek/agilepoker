using System;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace Task_4
{
    public class StringConcatAnalyzer
    {
        public static void StringConcatAnalyzeExmaple()
        {
            TimeSpan duration = new TimeSpan();
            Stopwatch stopwatch = new Stopwatch();

            var dataSet = new DataSet();
            var dataTable = new DataTable();
            string exampleString = "Hello, World!";
            StringBuilder exampleStringBuilder = new StringBuilder("Hello, World!");

            dataSet.Tables.Add("Shapes");

            dataTable = dataSet.Tables[0];

            dataTable.Columns.Add("Shape");
            dataTable.Columns.Add("Area");
            dataTable.Columns.Add("SideLength");
            dataTable.Rows.Add("Circle", "0", "62,83185307179586");
            dataTable.Rows.Add("Round", "314,1592653589793", "62,83185307179586");
            dataTable.Rows.Add("Rectangle", "50", "30");

            Console.WriteLine("Сравнение операций сложения строк");
            
            stopwatch.Start();
            for (int i = 0; i < 10000; i++)
            {
                GetDataSetSeparationWithoutStringBuilder(dataSet, "++", "++");
            }
            stopwatch.Stop();
            duration = stopwatch.Elapsed;
            Console.WriteLine(string.Format("{0:00}:{1:00}.{2:00}", duration.Minutes, duration.Seconds, duration.Milliseconds / 10));
            Console.WriteLine(duration);

            stopwatch.Restart();
            for (int i = 0; i < 10000; i++)
            {
                GetDataSetSeparationWithStringBuilder(dataSet, "++", "++");
            }
            stopwatch.Stop();
            duration = stopwatch.Elapsed;
            Console.WriteLine(string.Format("{0:00}:{1:00}.{2:00}", duration.Minutes, duration.Seconds, duration.Milliseconds / 10));
            Console.WriteLine(duration);
            Console.WriteLine();

            Console.WriteLine("Сравнение операций получения подстроки");
           
            stopwatch.Restart();
            for (int i = 0; i < 1000; i++)
            {
                string test = exampleString.Substring(5, 7);
            }
            stopwatch.Stop();
            duration = stopwatch.Elapsed;
            Console.WriteLine(duration);            
            stopwatch.Restart();
            for (int i = 0; i < 1000; i++)
            {
                string test = exampleStringBuilder.ToString(5, 7);
            }
            stopwatch.Stop();
            duration = stopwatch.Elapsed;
            Console.WriteLine(duration);
        }

        /// <summary>
        /// Метод для получения строки с сепараторами из датасета. Метод реализован без StringBuilder.
        /// </summary> 
        public static string GetDataSetSeparationWithoutStringBuilder(DataSet dataSet, string columnSeparator, string rowSeparator)
        {
            string resultString = string.Empty;
            foreach (DataTable dataTable in dataSet.Tables)
            {
                resultString += '\n';
                resultString += columnSeparator;
                foreach (DataColumn column in dataTable.Columns)
                {
                    resultString += column.ColumnName + columnSeparator;
                }
                resultString += '\n';

                foreach (DataRow row in dataTable.Rows)
                {
                    resultString += rowSeparator;
                    foreach (object record in row.ItemArray)
                    {
                        resultString += record.ToString() + rowSeparator;
                    }
                    resultString += '\n';
                }
            }
            return resultString;
        }

        /// <summary>
        /// Метод для получения строки с сепараторами из датасета. Метод реализован с помощью StringBuilder.
        /// </summary> 
        public static string GetDataSetSeparationWithStringBuilder(DataSet dataSet, string columnSeparator, string rowSeparator)
        {
            StringBuilder resultString = new StringBuilder();
            
            foreach (DataTable dataTable in dataSet.Tables)
            {
                resultString.AppendLine();
                resultString.Append(columnSeparator);
                foreach (DataColumn column in dataTable.Columns)
                {
                    resultString.Append(column.ColumnName + columnSeparator);
                }
                resultString.AppendLine();

                foreach (DataRow row in dataTable.Rows)
                {
                    resultString.Append(rowSeparator);
                    foreach (object record in row.ItemArray)
                    {
                        resultString.Append(record.ToString() + rowSeparator);
                    }
                    resultString.AppendLine();
                }
            }
            return resultString.ToString();
        }
    }
}