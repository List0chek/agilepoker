namespace Task_13
{
    /// <summary>
    /// Класс Program.        
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Метод Main. Точка входа в программу.        
        /// </summary>
        /// <param name="args">Аргументы метода Main.</param>
        public static void Main(string[] args)
        {
            EarlyBound.CreateMultiplicationTable("MultiplicationTableEB.xlsx");
            LateBound.CreateMultiplicationTable("MultiplicationTableLB.xlsx");
        }
    }
}
