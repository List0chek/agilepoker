using System;
using System.Configuration;

namespace Task_12
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
            Console.WriteLine("Exercise1:");
            var exercise1 = new Example();
            var properties1 = Exercise1.GetPropertiesInfo(exercise1);
            foreach (var property in properties1)
            {
                Console.WriteLine(property);
            }

            Console.WriteLine();

            Console.WriteLine("Exercise2:");
            var properties2 = Exercise2.GetPropertiesInfo("Task_12.dll", "Task_12.Example");
            foreach (var property in properties2)
            {
                Console.WriteLine(property);
            }

            Console.WriteLine();

            Console.WriteLine("Exercise3:");
            var exercise3 = new Example();
            var properties3 = Exercise3.GetPropertiesInfo(exercise3);
            foreach (var property in properties3)
            {
                Console.WriteLine(property);
            }

            Console.WriteLine();

            Console.WriteLine("Exercise4:");
            var exampleConfig = (ProgramSettingsConfig)ConfigurationManager.GetSection("ProgramSettings");
            foreach (ProgramSettingsElement instance in exampleConfig.ProgramSettingsInstances)
            {
                    Console.WriteLine("{0} {1}", instance.IntSetting, instance.StrSetting);
            }

            Console.WriteLine();

            Console.WriteLine("Exercise5:");
            var propertiesFromOldDLL = Exercise2.GetPropertiesInfo("Task_12_old.dll", "Task_12.Example");
            var propertiesFromNewDll = Exercise2.GetPropertiesInfo("Task_12.dll", "Task_12.Example");
            Console.WriteLine("Task_12_old.dll");
            foreach (var property in propertiesFromOldDLL)
            {
                Console.WriteLine(property);
            }

            Console.WriteLine();
            Console.WriteLine("Task_12.dll");
            foreach (var property in propertiesFromNewDll)
            {
                Console.WriteLine(property);
            }

            Console.WriteLine();
        }
    }
}
