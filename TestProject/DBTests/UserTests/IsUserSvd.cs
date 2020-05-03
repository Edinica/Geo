using System;
using Geo.App_Start;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.DBTests.UserTests
{
	[TestClass]
	public class IsUserSvd
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
        public void IsUserSavedYep()
        {
            // Arrange   -------------------------------------    
            TestController.LoadSampleUser("name", "pass", "email@email.ru");

            // Act   -----------------------------------------        
            bool issaved = TestController.isSavedUser();

            // Assert-----------------------------------------

            Assert.AreEqual(true, issaved);
            TestController.LoginOut("name");
        }

        [TestMethod]
        public void IsUserSavedNo()
        {
            // Arrange   -------------------------------------    
            TestController.LoadSampleUser("name", "pass", "email@email.ru");
            TestController.LoginOut("name");
            // Act   -----------------------------------------        
            bool issaved = TestController.isSavedUser();

            // Assert-----------------------------------------

            Assert.AreEqual(false, issaved);
        }

        [TestMethod]
        public void IsUserSavedNoNo()
        {
            // Arrange   -------------------------------------    

            // Act   -----------------------------------------        
            bool issaved = TestController.isSavedUser();

            // Assert-----------------------------------------

            Assert.AreEqual(false, issaved);
        }
    }
}
