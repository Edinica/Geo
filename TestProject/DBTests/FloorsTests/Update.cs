using System;
using Geo.App_Start;
using Geo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.DBTests.FloorsTests
{
	[TestClass]
	public class Update
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
        public void UpdateOne()
        {
            // Arrange   -------------------------------------    
            Floor Floor = new Floor("Description",1);
            TestController.AddFloor(Floor);

            // Act   -----------------------------------------       
            Floor.Description = "DescriptionDescription";
            TestController.UpdateFloor(Floor);

            // Assert-----------------------------------------
            string str = TestController.LoadAllFloors()[0].Description;

            Assert.AreEqual("DescriptionDescription", str);
        }

        [TestMethod]
        public void UpdateEmpty()
        {
            // Arrange   -------------------------------------    
            Floor Floor = new Floor("Description", 1);
            TestController.AddFloor(Floor);

            // Act   -----------------------------------------       
            Floor = null;
            TestController.UpdateFloor(Floor);

            // Assert-----------------------------------------
            string upstring = TestController.LoadAllFloors()[0].Description;

            Assert.AreEqual("Description", upstring);
        }

        [TestMethod]
        public void NonUpdateWoW()
        {
            // Arrange   -------------------------------------    
            Floor Floor = new Floor("Description", 1);
            TestController.AddFloor(Floor);

            // Act   -----------------------------------------       
            Floor.Description = "DescriptionDescription";

            // Assert-----------------------------------------
            string upstring = TestController.LoadAllFloors()[0].Description;

            Assert.AreEqual("DescriptionDescription", upstring);
        }
    }
}
