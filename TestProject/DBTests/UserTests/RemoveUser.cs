using System;
using Geo.App_Start;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.DBTests.UserTests
{
	[TestClass]
	public class RemoveUser
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
        public void SimpleDelete()
        {
            // Arrange   -------------------------------------    
            TestController.LoadSampleUser("Username", "","email@mail.ru");

            // Act   -----------------------------------------        
            TestController.RemoveUser(new Geo.Models.ApplicationUser());

            // Assert-----------------------------------------
            Assert.AreEqual(false, TestController.isSavedUser());
        }

        
        [TestMethod]
        public void RemoveNull()
        {
            // Arrange   -------------------------------------    
            TestController.LoadSampleUser(new Geo.Models.ApplicationUser());
            TestController.Setname("USER");

            // Act   -----------------------------------------        
            TestController.RemoveUser(null);

            // Assert-----------------------------------------
            Assert.AreEqual("USER", TestController.LoadUserFromDb().UserName);
        }
    }
}
