using System;
using Geo.App_Start;
using Geo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.DBTests.FloorsTests
{
	[TestClass]
	public class Remove
	{
        [TestCleanup()]
        public void MyTestCleanup()
        {
            // обновить базу данных
            TestController.ClearAll();
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            TestController.ClearAll();
            TestController.RefrashDb(true);
        }

        [TestMethod]
        public void RemoveOne()
        {
            // Arrange   -------------------------------------    
            Floor Floor = new Floor("Description",1);
            TestController.AddFloor(Floor);

            // Act   -----------------------------------------        
            TestController.RemoveFloor(Floor);

            // Assert-----------------------------------------
            int count = TestController.LoadAllFloors().Count;

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void RemoveEmpty()
        {
            // Arrange   -------------------------------------    
            Floor Floor = new Floor("Description", 1);
            TestController.AddFloor(Floor);

            // Act   -----------------------------------------      
            Floor empFloor = null;
            TestController.RemoveFloor(empFloor);

            // Assert-----------------------------------------
            int count = TestController.LoadAllFloors().Count;

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void RemoveMany()
        {
            // Arrange   -------------------------------------
            TestController.AddFloor(new Floor("Description1", 1));
            TestController.AddFloor(new Floor("Description2", 2));
            TestController.AddFloor(new Floor("Description3", 3));
            TestController.AddFloor(new Floor("Description4", 1));
            TestController.AddFloor(new Floor("Description5", 2));
            var Floors = TestController.LoadAllFloors();

            // Act   -----------------------------------------
            TestController.RemoveFloor(Floors);

            // Assert-----------------------------------------
            int count = TestController.LoadAllFloors().Count;

            Assert.AreEqual(0, count);
        }
    }
}
