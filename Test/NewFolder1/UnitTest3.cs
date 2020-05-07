using System;
using System.Linq;
using Geo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.NewFolder1
{
	[TestClass]
	public class UnitTest3
	{
        ApplicationDbContext db = new ApplicationDbContext();
        [TestMethod]
        public void RemoveOne()
        {
            // Arrange   -------------------------------------    
            int count1 = db.Floors.ToList().Count();
            Floor Floor = new Floor(100, 2, "desc");
            db.Floors.Add(Floor);
            db.SaveChanges();
            // Act   -----------------------------------------        
            db.Floors.Remove(Floor);
            db.SaveChanges();

            // Assert-----------------------------------------
            int count2 = db.Floors.ToList().Count();

            Assert.AreEqual(count1, count2);
        }

        [TestMethod]
        public void RemoveEmpty()
        {
            // Arrange   -------------------------------------
            int count1 = db.Floors.ToList().Count();
            Floor Floor = new Floor(100, 2, "desc");
            db.Floors.Add(Floor);
            db.SaveChanges();

            // Act   -----------------------------------------      
            Floor empFloor = null;
            try
            {
                db.Floors.Remove(empFloor);
            }
            catch 
            {
                db.SaveChanges();

                // Assert-----------------------------------------
                int count2 = db.Floors.ToList().Count();

                Assert.AreEqual(count1+1, count2);
            }
            
        }

        [TestMethod]
        public void RemoveMany()
        {
            int count1 = db.Floors.ToList().Count();
            // Arrange   -------------------------------------
            Floor Floor = new Floor(100, 2, "desc");
            db.Floors.Add(Floor);
            db.SaveChanges();
            Floor Floor1 = new Floor(100, 2, "desc");
            db.Floors.Add(Floor);
            db.SaveChanges();
            Floor Floor2 = new Floor(100, 2, "desc");
            db.Floors.Add(Floor);
            db.SaveChanges();

            var Floors = db.Floors.ToList();

            // Act   -----------------------------------------
            for (int i = 0; i < 3; i++)
            {
                db.Floors.Remove(db.Floors.ToList().Last());
                db.SaveChanges();
            }
            // Assert-----------------------------------------
            int count2 = db.Floors.ToList().Count();

            Assert.AreEqual(count1, count2);
        }
    }
}
