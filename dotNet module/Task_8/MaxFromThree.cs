using System;

namespace Task_8
{
    public class MaxFromThree
    {
        /// <summary>
        /// Возвращает максимальное из трех значение generic типа.
        /// </summary>
        public static T GetMaxFromThreeElements<T>(T operand1, T operand2, T operand3) where T : IComparable<T>
        {
            var maxValue = operand1;

            if (operand1.CompareTo(operand2) > 0)
            {
                maxValue = operand1;
            }
            else maxValue = operand2;

            if (maxValue.CompareTo(operand3) < 0)
            {
                maxValue = operand3;
            }

            return maxValue;
        }
    }
}
