using System;
using System.IO;

namespace Task_4
{
    /// <summary>
    /// Логгер - класс для ведения логов.
    /// </summary>
    public class Logger : IDisposable
    {
        /// <summary>
        /// To detect redundant call.
        /// </summary> 
        private bool disposed = false;

        /// <summary>
        /// Файл логов.
        /// </summary>
        private FileStream logFile;

        /// <summary>
        /// Писатель в лог.
        /// </summary>
        private StreamWriter logWriter;

        /// <summary>
        /// Public implementation of Dispose pattern callable by consumers.
        /// </summary> 
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Protected implementation of Dispose pattern.
        /// </summary> 
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed == false)
            {
                if (disposing)
                {
                    this.logWriter.Dispose();
                    this.logFile.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Создать объект.
        /// </summary>
        /// <param name="fileName">Имя файла логов.</param>
        public Logger(string fileName)
        {
            this.logFile = new FileStream(fileName, FileMode.Append);
            this.logWriter = new StreamWriter(this.logFile);
        }

        public void WriteString(string data)
        {
            this.logWriter.WriteLine(data);
        }
    }
}
