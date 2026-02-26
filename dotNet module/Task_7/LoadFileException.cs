using System;

namespace Task_7
{
    [Serializable]
    public class LoadFileException : Exception
    {
        public LoadFileException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
