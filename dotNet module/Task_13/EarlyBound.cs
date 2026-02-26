using Microsoft.Office.Interop.Excel;
using System;

namespace Task_13
{
    /// <summary>
    /// Класс для создания таблицы с ранним связыванием. 
    /// </summary>
    public class EarlyBound
    {
        /// <summary>
        /// Метод создает xlsx файл и в нем рисует таблицу умножения. Использует раннее связывание. 
        /// </summary>
        /// <param name="path">Путь для сохранения файла.</param>
        public static void CreateMultiplicationTable(string path)
        {
            var excelApp = new Application();
            excelApp.Visible = true;
            excelApp.Workbooks.Add();
            var worksheet = excelApp.Worksheets[1];
            for (int i = 1; i <= 9; i++)
            {
                worksheet.Cells[i + 1, 2].Interior.Color = XlRgbColor.rgbAquamarine;
                worksheet.Cells[2, i + 1].Interior.Color = XlRgbColor.rgbAquamarine;
                for (int j = 1; j <= 9; j++)
                {
                    worksheet.Cells[i + 1, j + 1] = i * j;
                }
            }

            excelApp.Application.ActiveWorkbook.SaveAs(path, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing);
        }
    }
}
