using System;

namespace Task_12
{
    /// <summary>
    /// Класс примеров свойств.      
    /// </summary>
    public class Example
    {
        /// <summary>
        /// Свойство HelloWorld.        
        /// </summary>
        public string HelloWorld { get; set; } = "Hello, World!";

        /// <summary>
        /// Свойство ByeWorld.   
        /// </summary>
        public string ByeWorld { get; set; } = "Bye, World(";
        
        /// <summary>
        /// Свойство DaysInBissextileYear.        
        /// </summary>
        [Obsolete]
        public int DaysInBissextileYear { get; set; } = 366;
    }
}
