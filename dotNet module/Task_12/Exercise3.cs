using System;
using System.Collections.Generic;

namespace Task_12
{
    /// <summary>
    /// Класс Задание 3.      
    /// </summary>
    public class Exercise3
    {
        /// <summary>
        /// Метод записывает в список имена всех read-write свойств входного объекта и строковые представления значений свойств, при этом игнорирует свойства, помеченные атрибутом [Obsolete].    
        /// </summary>
        /// <param name="obj">Входной параметр типа object.</param>
        /// <returns>Возвращает имена всех read-write свойств входного объекта и строковые представления значений свойств.</returns>
        public static List<string> GetPropertiesInfo(object obj)
        {
            var list = new List<string>();
            var type = obj.GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                if (property.CanWrite && property.CanRead && !Attribute.IsDefined(property, typeof(ObsoleteAttribute)))
                {
                    list.Add("Property name: " + property.Name);
                    list.Add("Property value: " + property.GetValue(obj) + "\n");
                }
            }

            return list;
        }
    }
}