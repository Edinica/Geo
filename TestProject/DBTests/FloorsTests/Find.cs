using System;
using Geo.App_Start;
using Geo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.DBTests.FloorsTests
{
	[TestClass]
	public class Find
	{
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
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
            // TestController.RefrashDb(true);
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            TestController.ClearAll();
            TestController.RefrashDb(true);
        }

        [TestMethod]
        public void FindOne()
        {
            // Arrange   -------------------------------------    
            Floor Floor = new Floor("Description",1);
            TestController.AddFloor(Floor);

            Floor test = new Floor("Description", 1);

            // Act   -----------------------------------------     
            Floor result = TestController.FindFloor(test);

            // Assert-----------------------------------------
            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        public void FindOneNonExist()
        {
            // Arrange   -------------------------------------    
            Floor Floor = new Floor("Description", 1);
            TestController.AddFloor(Floor);

            Floor test = new Floor("Description2", 2);

            // Act   -----------------------------------------     
            Floor result = TestController.FindFloor(test);

            // Assert-----------------------------------------
            Assert.IsNull(result);
        }

        [TestMethod]
        public void FindNull()
        {
            // Arrange   -------------------------------------    
            Floor Floor = new Floor("Description", 1);
            TestController.AddFloor(Floor);

            Floor test = null;

            // Act   -----------------------------------------     
            Floor result = TestController.FindFloor(test);

            // Assert-----------------------------------------
            Assert.IsNull(result);
        }

    }
}
