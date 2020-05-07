using Geo.Controllers;
using Geo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Geo.Controllers
{
	[TestClass]
	public class BuildingsControllerTests
	{
		private MockRepository mockRepository;



		[TestInitialize]
		public void TestInitialize()
		{
			this.mockRepository = new MockRepository(MockBehavior.Strict);


		}

		private BuildingsController CreateBuildingsController()
		{
			return new BuildingsController();
		}

		[TestMethod]
		public void Index_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var buildingsController = this.CreateBuildingsController();

			// Act
			var result = buildingsController.Index();

			// Assert
			Assert.Fail();
			this.mockRepository.VerifyAll();
		}

		[TestMethod]
		public void Details_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var buildingsController = this.CreateBuildingsController();
			int? id = null;

			// Act
			var result = buildingsController.Details(
				id);

			// Assert
			Assert.Fail();
			this.mockRepository.VerifyAll();
		}

		[TestMethod]
		public void Create_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var buildingsController = this.CreateBuildingsController();

			// Act
			var result = buildingsController.Create();

			// Assert
			Assert.Fail();
			this.mockRepository.VerifyAll();
		}

		[TestMethod]
		public void Create_StateUnderTest_ExpectedBehavior1()
		{
			// Arrange
			var buildingsController = this.CreateBuildingsController();
			Building building = null;

			// Act
			var result = buildingsController.Create(
				building);

			// Assert
			Assert.Fail();
			this.mockRepository.VerifyAll();
		}

		[TestMethod]
		public void Edit_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var buildingsController = this.CreateBuildingsController();
			int? id = null;

			// Act
			var result = buildingsController.Edit(
				id);

			// Assert
			Assert.Fail();
			this.mockRepository.VerifyAll();
		}

		[TestMethod]
		public void NF_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var buildingsController = this.CreateBuildingsController();

			// Act
			var result = buildingsController.NF();

			// Assert
			Assert.Fail();
			this.mockRepository.VerifyAll();
		}

		[TestMethod]
		public void Plan_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var buildingsController = this.CreateBuildingsController();
			int? id = null;

			// Act
			var result = buildingsController.Plan(
				id);

			// Assert
			Assert.Fail();
			this.mockRepository.VerifyAll();
		}

		[TestMethod]
		public void Edit_StateUnderTest_ExpectedBehavior1()
		{
			// Arrange
			var buildingsController = this.CreateBuildingsController();
			Building building = null;

			// Act
			var result = buildingsController.Edit(
				building);

			// Assert
			Assert.Fail();
			this.mockRepository.VerifyAll();
		}

		[TestMethod]
		public void Delete_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var buildingsController = this.CreateBuildingsController();
			int? id = null;

			// Act
			var result = buildingsController.Delete(
				id);

			// Assert
			Assert.Fail();
			this.mockRepository.VerifyAll();
		}

		[TestMethod]
		public void DeleteConfirmed_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var buildingsController = this.CreateBuildingsController();
			int id = 0;

			// Act
			var result = buildingsController.DeleteConfirmed(
				id);

			// Assert
			Assert.Fail();
			this.mockRepository.VerifyAll();
		}
	}
}
