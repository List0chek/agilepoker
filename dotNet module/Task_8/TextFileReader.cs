using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Task_8
{
    public class TextFileReader : IEnumerable<string>, IDisposable, IEnumerator<string>
    {
        private StreamReader streamReader;

        public string Current { get; set; }

        object IEnumerator.Current
        {
            get { return this.Current; }
        }

        /// <summary>
        /// Перемещает указатель на след. элемент, делает проверку на окончание листа.
        /// </summary>
        public bool MoveNext()
        {
            if ((this.Current = this.streamReader.ReadLine()) != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Сброс указателя.
        /// </summary>
        public void Reset()
        {
            this.streamReader.BaseStream.Position = 0;
        }

        public void Dispose()
        {
            this.streamReader.Dispose();
        }

        public TextFileReader(string path)
        {
            this.streamReader = new StreamReader(path);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}