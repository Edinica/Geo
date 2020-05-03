using System;
using Geo.App_Start;
using Geo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.DBTests.UserTests
{
	[TestClass]
	public class LdUser
	{
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            TestController.ClearAll();
            TestController.RefrashDb(true);
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            TestController.ClearAll();
            TestController.RefrashDb(true);
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            TestController.ClearAll();
            TestController.RefrashDb(true);
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            // обновить базу данных
            TestController.ClearAll();
        }

        [TestMethod]
        public void LoadEmptyUser()
        {
            // Arrange   -------------------------------------    

            // Act   -----------------------------------------        
            var user = TestController.LoadUserFromDb();

            // Assert-----------------------------------------
            Assert.AreEqual(null, user);
        }

        [TestMethod]
        public void LoadOkeyUser()
        {
            // Arrange   -------------------------------------    
            TestController.SaveUser(new ApplicationUser());


            // Act   -----------------------------------------        
            ApplicationUser user = TestController.LoadUserFromDb();
            TestController.Setname("Username");
            // Assert-----------------------------------------
            Assert.AreEqual("Username", user.UserName);
        }

        
    }
}
