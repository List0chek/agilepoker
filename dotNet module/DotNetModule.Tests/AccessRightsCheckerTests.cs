using NUnit.Framework;
using System;
using System.IO;
using Task_4;

namespace DotNetModule.Tests
{
    public class AccessRightsCheckerTests
    {
        [Test]
        [TestCase(AccessRightsChecker.AccessRights.AccessDenied | AccessRightsChecker.AccessRights.Add | AccessRightsChecker.AccessRights.Ratify, ExpectedResult = "AccessDenied\r\n")]
        [TestCase(AccessRightsChecker.AccessRights.Add | AccessRightsChecker.AccessRights.Ratify, ExpectedResult = "Add, Ratify\r\n")]
        public string ShowAccessRightsTest(AccessRightsChecker.AccessRights accessRights)
        {
            string allConsoleOutput = string.Empty;
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                AccessRightsChecker.ShowAccessRights(accessRights);
                allConsoleOutput = stringWriter.ToString();
            }

            return allConsoleOutput;
        }
    }
}
