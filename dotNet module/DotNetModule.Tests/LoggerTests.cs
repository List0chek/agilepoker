using NUnit.Framework;
using System.IO;
using System.Linq;
using Task_4;

namespace DotNetModule.Tests
{
    public class LoggerTests
    {
        [Test]
        public void LoggerTest()
        {
            using (var logger = new Logger("1000nows.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    logger.WriteString(i.ToString());
                }
            }

            Assert.AreEqual(File.ReadAllLines("1000nows.txt").Count(), 1000);
            int counter = 0;
            foreach (var line in File.ReadLines("1000nows.txt"))
            {
                Assert.AreEqual(line, counter.ToString());
                counter++;
            }

            File.Delete("1000nows.txt");
        }
    }
}
