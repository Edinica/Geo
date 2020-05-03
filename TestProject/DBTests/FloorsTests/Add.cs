using System;
using System.Collections.Generic;
using Geo.App_Start;
using Geo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.DBTests.FloorsTests
{
	[TestClass]
	public class Add
	{
		[TestInitialize()]
        public void MyTestInitialize()
        {
            // очистка контекста
            //TestController.ClearAll();
            TestController.RefrashDb(true);
            Floor Floor = new Floor();

            // Act   -----------------------------------------
            TestController.AddFloor(Floor);
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
        public void AddOne()
        {
            // Arrange   -------------------------------------    
            Floor Floor = new Floor("Floor1",1);

            // Act   -----------------------------------------        
            TestController.AddFloor(Floor);

            // Assert-----------------------------------------
            int count = TestController.LoadAllFloors().Count;

            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void AddFiveSame()
        {
            // Arrange   -------------------------------------

            // Act   -----------------------------------------
            TestController.AddFloor(new Floor("Floor1", 1));
            TestController.AddFloor(new Floor("Floor2", 2));
            TestController.AddFloor(new Floor("Floor3", 1));
            TestController.AddFloor(new Floor("Floor4", 2));
            TestController.AddFloor(new Floor("Floor5", 1));
            // Assert-----------------------------------------
            int count = TestController.LoadAllFloors().Count;

            Assert.AreEqual(5, count);
        }
        
        [TestMethod]
        public void AddListPP()
        {
            // Arrange   -------------------------------------
             Floor Floor = new Floor("Floor1", 1);
             Floor Floor1 = new Floor("Floor2", 1);
             Floor Floor2 = new Floor("Floor3", 1);

            // Act   -----------------------------------------
            TestController.AddFloor(Floor);
            TestController.AddFloor(Floor1);
            TestController.AddFloor(Floor2);

            // Assert-----------------------------------------
            int count = TestController.LoadAllFloors().Count;

            Assert.AreEqual(3, count);
        }
           
        [TestMethod]
        public void AddList()
        {
            // Arrange   -------------------------------------
            List<Floor> Floors = new List<Floor>();
            Floors.Add(new Floor("Floor1", 1));
            Floors.Add(new Floor("Floor2", 1));
            Floors.Add(new Floor("Floor3", 1));

            // Act   -----------------------------------------
            TestController.AddFloor(Floors);

            // Assert-----------------------------------------
            int count = TestController.LoadAllFloors().Count;

            Assert.AreEqual(3, count);
        }
        
        [TestMethod]
        public void AddEmpty()
        {
            // Arrange   -------------------------------------
            

            // Assert-----------------------------------------
            int count = TestController.LoadAllFloors().Count;

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void AddNull()
        {
            TestController.ClearAll();
            // Arrange   -------------------------------------
            Floor Floor = null;

            // Act   -----------------------------------------
            TestController.AddFloor(Floor);

            // Assert-----------------------------------------
            int count = TestController.LoadAllFloors().Count;

            Assert.AreEqual(0, count);
        }    
	}
}
