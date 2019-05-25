using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PermissionToFileLibraryClasses;

namespace PermissionToFileUnitTest
{
    [TestClass]
    public class HelperAdminTest
    {
        [TestMethod]
        public void BanUserTest()
        {
            HelperAdmin helperBanTest = new HelperAdmin("Moderator", "222", "helper");
            User userBanTest = new User("userUnitTest", "333", "user", false);

            helperBanTest.BanUser(userBanTest);

            Assert.AreEqual(true, userBanTest.Banned);
        }

        [TestMethod]
        public void UnBanUserTest()
        {
            HelperAdmin helperUnBanTest = new HelperAdmin("Moderator", "222", "helper");
            User userUnBanTest = new User("userUnBanUnitTest", "333", "user", true);

            helperUnBanTest.UnBanUser(userUnBanTest);

            Assert.AreEqual(false, userUnBanTest.Banned);
        }
    }
}
