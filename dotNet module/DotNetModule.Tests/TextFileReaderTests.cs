using NUnit.Framework;
using System;
using System.IO;
using Task_8;

namespace DotNetModule.Tests
{
    public class TextFileReaderTests
    {
        [Test]
        public void TextFileReaderTest()
        {
            string path = "TextFileReaderTest.txt";
            string allConsoleOutput = string.Empty;

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                using (var textFileBruteForce = new TextFileReader(path))
                {
                    foreach (var item in textFileBruteForce)
                    {
                        Console.WriteLine(item);
                    }
                }

                allConsoleOutput = stringWriter.ToString();
            }

            Assert.AreEqual(File.ReadAllText(path), allConsoleOutput);
        }
    }
}
