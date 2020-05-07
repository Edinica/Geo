using System;
using System.Collections.Generic;
using System.Linq;
using Geo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.NewFolder1
{
	[TestClass]
	public class UnitTest1
	{ApplicationDbContext db = new ApplicationDbContext();
		[TestMethod]
		public void TestMethod1()
		{
			//ApplicationDbContext db = new ApplicationDbContext();
			////var floor = new Floor();
			////floor.Description = "";
			////floor.Level = 18;
			////floor.BuildingId = 3;
			////floor.Id = 100;
			//Building xxx = db.Buildings.Find(1);
			//xxx.Address = "Первый";
			////db.Floors.Add(floor);
			//db.Floors.FirstOrDefault(x => x.Id == xxx.Id).Description = xxx.Address;
			//db.SaveChanges();

			//ApplicationDbContext db = new ApplicationDbContext();
			//db.Buildings.Remove(db.Buildings.FirstOrDefault(x=>x.Id==5));
			//db.SaveChanges();
			
			db.Floors.Add(new Floor());
			db.SaveChanges();
		}
        [TestMethod]
        public void AddOne()
        {

            //context.Database.Delete();

            // Arrange   -------------------------------------    
            Floor Floor = new Floor();
            var p = db.Floors.ToString();
            int count1 = db.Floors.ToList().Count;
            //TestController.AddFloor(Floor);
            db.Floors.Add(Floor);
            db.SaveChanges();


            // Act   -----------------------------------------        


            // Assert-----------------------------------------
            int count2 = db.Floors.ToList().Count;

            Assert.AreEqual(count1+1, count2);
        }

        [TestMethod]
        public void AddFiveSame()
        {
            // Arrange   -------------------------------------
            int count1 = db.Floors.ToList().Count();
            // Act   -----------------------------------------
            db.Floors.Add(new Floor());
            db.Floors.Add(new Floor());
            db.Floors.Add(new Floor());
            db.Floors.Add(new Floor());
            db.Floors.Add(new Floor());
            db.SaveChanges();
            // Assert-----------------------------------------
            int count2 = db.Floors.ToList().Count;

            Assert.AreEqual(count1+5, count2);
        }


        [TestMethod]
        public void AddList()
        {
            int count1 = db.Floors.ToList().Count();
            // Arrange   -------------------------------------
            List<Floor> Floors = new List<Floor>();
            Floors.Add(new Floor());
            Floors.Add(new Floor());
            Floors.Add(new Floor());

            // Act   -----------------------------------------
            for(int i=0;i<Floors.Count();i++)
            db.Floors.Add(Floors[i]);
            db.SaveChanges();

            // Assert-----------------------------------------
            int count2 = db.Floors.ToList().Count();

            Assert.AreEqual(count1+3, count2);
        }

        [TestMethod]
        public void AddEmpty()
        {
            // Arrange   -------------------------------------
            int count1 = db.Floors.ToList().Count();
            db.Floors.Add(new Floor(100,2,"desc"));
            db.SaveChanges();
            // Assert-----------------------------------------
            int count2 = db.Floors.ToList().Count();

            Assert.AreEqual(count1+1, count2);
        }

        [TestMethod]
        public void AddNull()
        {
            int count1 = db.Floors.ToList().Count();
            try { db.Floors.Add(null); }
            catch 
            {
            db.SaveChanges();
            // Assert-----------------------------------------
            int count2 = db.Floors.ToList().Count();



            Assert.AreEqual(count2, count1);
            }
            
        }
    }
}

