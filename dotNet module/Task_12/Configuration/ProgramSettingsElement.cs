using System.Configuration;

namespace Task_12
{
    /// <summary>
    /// Класс элементов.
    /// </summary>
    public class ProgramSettingsElement : ConfigurationElement
    {
        /// <summary>
        /// Свойство, которое хранит и позволяет задать IntSetting. Должно быть уникальным.
        /// </summary>
        [ConfigurationProperty("IntSetting", IsKey = true, IsRequired = true)]
        public int IntSetting
        {
            get
            {
                return (int)this["IntSetting"];
            }

            set
            {
                base["IntSetting"] = value;
            }
        }

        /// <summary>
        /// Свойство, которое хранит и позволяет задать StrSetting.
        /// </summary>
        [ConfigurationProperty("StrSetting", IsRequired = true)]
        public string StrSetting
        {
            get
            {
                return (string)this["StrSetting"];
            }

            set
            {
                base["StrSetting"] = value;
            }
        }
    }
}