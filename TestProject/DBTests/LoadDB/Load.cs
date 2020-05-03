using System;
using Geo.App_Start;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.DBTests.BuildingTests
{
	[TestClass]
	public class Load
	{
		[ClassInitialize()]
		public static void MyClassInitialize(TestContext testContext)
		{
			TestController.RefrashDb(true);
			TestController.ClearAll();
		}
	}
}
