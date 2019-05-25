using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PermissionToFileLibraryClasses;

namespace PermissionToFileUnitTest
{
    [TestClass]
    public class SystemAdminTest
    {
        [TestMethod]
        public void BanUserTest()
        {
            SystemAdmin systemAdminTest = new SystemAdmin("systemAdminUnitTest", "222", "systemAdmin");
            User userTest = new User("userUnitTest", "333", "user", false);

            systemAdminTest.BanUser(userTest);

            Assert.AreEqual(true, userTest.Banned);
        }
    }
}
