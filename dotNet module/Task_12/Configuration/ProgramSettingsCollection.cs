using System.Configuration;

namespace Task_12
{
    /// <summary>
    /// Класс коллекции настроек.      
    /// </summary>
    public class ProgramSettingsCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Метод позволяет создать новый элемент конфигурации.      
        /// </summary>
        /// /// <returns>Возвращает новый элемент конфигурации.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new ProgramSettingsElement();
        }

        /// <summary>
        /// Метод позволяет получить ключ элемента.      
        /// </summary>
        /// <param name="element">Configuration file element.</param>
        /// <returns>Возвращает ключ выбранного элемента.</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ProgramSettingsElement)element).IntSetting;
        }
    }
}
