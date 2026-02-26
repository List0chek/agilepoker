using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Task_12;

namespace DotNetModule.Tests
{
    public class GetPropertiesInfoTests
    {
        [Test]
        public void GetPropertiesInfoTest()
        {
            var example = new Example();
            var properties1 = Exercise1.GetPropertiesInfo(example);
            var properties2 = Exercise2.GetPropertiesInfo("Task_12_orig.dll", "Task_12.Example");
            for (int i = 0; i < properties2.Count; i++)
            {
                Assert.AreEqual(properties2[i], properties1[i]);
            }

            var properties3 = Exercise3.GetPropertiesInfo(example);
            Assert.AreEqual(properties2.Count - 2, properties3.Count);
            var testList = new List<string>();
            testList.Add("Property name: DaysInBissextileYear");
            testList.Add("Property value: 366\n");
            Assert.AreEqual(testList, properties2.Except(properties3));
        }
    }
}
