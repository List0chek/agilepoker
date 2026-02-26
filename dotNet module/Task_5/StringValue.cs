using System;

namespace Task_5
{
    /// <summary>
    /// Для реализации сравнения используем интерфейс IEquatable.
    /// </summary> 
    public class StringValue : IEquatable<StringValue>
    {
        public string Value { get; private set; }

        public StringValue(string value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as StringValue);
        }

        /// <summary>
        /// Метод сравнения. Если ссылки равны, то возвращаем true.  
        /// </summary> 
        public bool Equals(StringValue other)
        {
            if (other == null)
            {
                return false;
            }
            if (this.Value.Equals(other.Value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Переопределяем метод. Для сравнения нужно, чтобы ссылки совпадали. 
        /// </summary> 
        public override int GetHashCode()
        {
            if (this.Value == null)
            {
                return base.GetHashCode();
            }
            return this.Value.GetHashCode();
        }

        public static bool operator ==(StringValue leftValue, StringValue rightValue)
        {
            if (leftValue == null || rightValue == null)
            {
                return false;
            }
            return Equals(rightValue, leftValue);
        }

        public static bool operator !=(StringValue leftValue, StringValue rightValue)
        {
            if (leftValue == null || rightValue == null)
            {
                return false;
            }
            return !Equals(rightValue, leftValue);
        }
    }
}