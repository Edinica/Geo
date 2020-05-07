using Geo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geo.NewFolder1
{
	[TestClass]
	public class testclass
	{
		[TestMethod]
		public void TestMethod1()
		{
			ApplicationDbContext db = new ApplicationDbContext();
			//var floor = new Floor();
			//floor.Description = "";
			//floor.Level = 18;
			//floor.BuildingId = 3;
			//floor.Id = 100;
			Building xxx = db.Buildings.Find(1);
			xxx.Address = "Первый этаж1";
			//db.Floors.Add(floor);
			db.Floors.FirstOrDefault(x => x.Id == xxx.Id).Description = xxx.Address;
			db.SaveChanges();
		}
	}
}