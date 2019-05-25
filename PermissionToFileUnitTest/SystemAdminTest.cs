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
            SystemAdmin systemAdminBanTest = new SystemAdmin("systemAdminUnitTest", "222", "systemAdmin");
            User userBanTest = new User("userUnitTest", "333", "user", false);

            systemAdminBanTest.BanUser(userBanTest);

            Assert.AreEqual(true, userBanTest.Banned);
        }

        [TestMethod]
        public void UnBanUserTest()
        {
            SystemAdmin systemAdminUnBanTest = new SystemAdmin("systemAdminUnBanUnitTest", "222", "systemAdmin");
            User userUnBanTest = new User("userUnBanUnitTest", "333", "user", true);

            systemAdminUnBanTest.UnBanUser(userUnBanTest);

            Assert.AreEqual(false, userUnBanTest.Banned);
        }
    }
}
