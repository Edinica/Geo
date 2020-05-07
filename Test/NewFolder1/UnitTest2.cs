using System;
using System.Linq;
using Geo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.NewFolder1
{
	[TestClass]
	public class UnitTest2
	{
        ApplicationDbContext db = new ApplicationDbContext();
        [TestMethod]
        public void FindOne()
        {
            // Arrange   -------------------------------------    
            Floor Floor = new Floor(100, 2, "desc");
            db.Floors.Add(Floor);
            db.SaveChanges();
            Floor test = new Floor(100, 2, "desc");

            // Act   -----------------------------------------     
            Floor result = db.Floors.FirstOrDefault(x=>x.Level==test.Level&&x.Description==test.Description);

            // Assert-----------------------------------------
            Assert.AreEqual("desc", result.Description);
        }

        [TestMethod]
        public void FindOneNonExist()
        {
            // Arrange   -------------------------------------    
            Floor Floor = new Floor(100, 2, "desc");
            db.Floors.Add(Floor);
            db.SaveChanges();

            Floor test = new Floor(101, 3, "des2c");

            // Act   -----------------------------------------     
            Floor result = db.Floors.FirstOrDefault(x => x.Level == test.Level && x.Description == test.Description&&x.Id==test.Id);

            // Assert-----------------------------------------
            Assert.IsNull(result);
        }

        [TestMethod]
        public void FindNull()
        {
            // Arrange   -------------------------------------    
            Floor Floor = new Floor(100, 2, "desc");
            db.Floors.Add(Floor);
            db.SaveChanges();

            Floor test = null;

            // Act   -----------------------------------------     
            Floor result = db.Floors.Find(test);

            // Assert-----------------------------------------
            Assert.IsNull(result);
        }

    }
}
