using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PermissionToFileLibraryClasses;

namespace PermissionToFileUnitTest
{
    [TestClass]
    public class ModeratorTest
    {
        [TestMethod]
        public void BanUserTest()
        {
            Moderator moderBanTest = new Moderator("Moderator", "222", "moder");
            User userBanTest = new User("userUnitTest", "333", "user", false);

            moderBanTest.BanUser(userBanTest);

            Assert.AreEqual(true, userBanTest.Banned);
        }

        [TestMethod]
        public void UnBanUserTest()
        {
            Moderator moderUnBanTest = new Moderator("Moderator", "222", "moder");
            User userUnBanTest = new User("userUnBanUnitTest", "333", "user", true);

            moderUnBanTest.UnBanUser(userUnBanTest);

            Assert.AreEqual(false, userUnBanTest.Banned);
        }
    }
}
