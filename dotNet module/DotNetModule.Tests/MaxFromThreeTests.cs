using NUnit.Framework;
using System;
using Task_8;

namespace DotNetModule.Tests
{
    public class MaxFromThreeTests
    {
        [Test]
        [TestCase(12, 14, 16, ExpectedResult = 16)]
        [TestCase(12.3, 16.3, 14.3, ExpectedResult = 16.3)]
        public T GetMaxFromThreeElementsTest<T>(T operand1, T operand2, T operand3) where T : IComparable<T>
        {
            return MaxFromThree.GetMaxFromThreeElements(operand1, operand2, operand3);
        }
    }
}
