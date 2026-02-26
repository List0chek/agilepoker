using System;
using System.Data;
using System.Text;

namespace Task_4
{
    public class DataSetUtils
    {
        public static void GetExampleDataSet()
        {
            var dataSet = new DataSet();
            var dataTable = new DataTable();

            dataSet.Tables.Add("Shapes");

            dataTable = dataSet.Tables[0];

            dataTable.Columns.Add("Shape");
            dataTable.Columns.Add("Area");
            dataTable.Columns.Add("SideLength");
            dataTable.Rows.Add("Circle", "0", "62,83185307179586");
            dataTable.Rows.Add("Round", "314,1592653589793", "62,83185307179586");
            dataTable.Rows.Add("Rectangle", "50", "30");

            Console.WriteLine(ConvertToString(dataSet, "|", "|"));
        }

        /// <summary>
        /// Метод ConvertToString. Сначала находит самую длинну запись и длину сохраняет, затем расставляет сепараторы и делает табуляцию.
        /// </summary>
        public static string ConvertToString(DataSet dataSet, string columnSeparator, string rowSeparator)
        {
            StringBuilder resultString = new StringBuilder();
            int maxRecordLength = 0;

            /// <summary>
            /// Данный цикл находит самую длинную запись и длину сохраняет.
            /// </summary>
            foreach (DataTable dataTable in dataSet.Tables)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    if (maxRecordLength < column.MaxLength)
                    {
                        maxRecordLength = column.MaxLength;
                    }
                }
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (var record in row.ItemArray)
                    {
                        if (maxRecordLength < record.ToString().Length)
                        {
                            maxRecordLength = record.ToString().Length;
                        }
                    }
                }
            }

            /// <summary>
            /// Данный цикл расставляет сепараторы и делает табуляцию.
            /// </summary> 
            foreach (DataTable dataTable in dataSet.Tables)
            {
                resultString.AppendLine();
                resultString.Append(columnSeparator);
                foreach (DataColumn column in dataTable.Columns)
                {
                    resultString.Append(column.ColumnName + columnSeparator.PadLeft(maxRecordLength - column.ColumnName.Length + columnSeparator.Length));
                }
                resultString.AppendLine();

                foreach (DataRow row in dataTable.Rows)
                {
                    resultString.Append(rowSeparator);
                    foreach (object record in row.ItemArray)
                    {
                      resultString.Append(record.ToString() + rowSeparator.PadLeft(maxRecordLength - record.ToString().Length + rowSeparator.Length));
                    }
                    resultString.AppendLine();
                }
            }
            return resultString.ToString();
        }
    }
}
