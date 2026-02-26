using System.Configuration;

namespace Task_12
{
    /// <summary>
    /// Класс ProgramSettingsConfig.      
    /// </summary>
    public class ProgramSettingsConfig : ConfigurationSection
    {
        /// <summary>
        /// Свойство, которое дает доступ к коллекции ProgramSettingsCollection. Принимает коллекцию и парсит ее.    
        /// </summary>
        [ConfigurationProperty("instances")]
        [ConfigurationCollection(typeof(ProgramSettingsCollection))]
        public ProgramSettingsCollection ProgramSettingsInstances
        {
            get
            {
                return (ProgramSettingsCollection)this["instances"];
            }
        }
    }
}
