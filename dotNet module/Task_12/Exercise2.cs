using System;
using System.Collections.Generic;
using System.Reflection;

namespace Task_12
{
    /// <summary>
    /// Класс Задание 2.      
    /// </summary>
    public class Exercise2
    {
        /// <summary>
        /// Метод создает экземпляр класса и выводит значения свойств.    
        /// </summary>
        /// <param name="assemblyPath">Путь к сборке.</param>
        /// <param name="className">Имя класса.</param>
        /// <returns>Возвращает имена всех read-write свойств экземпляра класса из выбранной сборки и строковые представления значений свойств.</returns>
        public static List<string> GetPropertiesInfo(string assemblyPath, string className)
        {
            var list = new List<string>();
            var assembly = Assembly.LoadFrom(assemblyPath);
            var type = assembly.GetType(className);
            var instance = Activator.CreateInstance(type);

            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                if (property.CanWrite && property.CanRead)
                {
                    list.Add("Property name: " + property.Name);
                    list.Add("Property value: " + property.GetValue(instance) + "\n");
                }
            }

            return list;
        }
    }
}