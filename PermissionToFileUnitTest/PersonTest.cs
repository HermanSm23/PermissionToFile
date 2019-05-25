using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PermissionToFileLibraryClasses;

namespace PermissionToFileUnitTest
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void IsLoggingTest()
        {
            string usernameTest = "user";
            string passwordTest = "pass";

            User userIsLoggingTest = new User("userIsLoggingUnitTest", "333", "user", false);

            Assert.AreEqual(false, userIsLoggingTest.IsLoggedIn(usernameTest, passwordTest));
        }
    }
}
