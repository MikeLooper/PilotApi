using NUnit.Framework;
using PilotApi.Repositories.Repositories;
using PilotApi.Repositories.Tests.Testing.Utilities;
using System;

namespace PilotApi.Repositories.Tests.Repositories
{
	[TestFixture]
	public class OrdersRepositoryTests : TestBase
	{
		[Test]
		public void OrdersRepository_Constructor_Succeeds_Test()
		{
			// arrange
			// act
			var testObject = RepositoryDoublesUtilities.GetOrdersRepositorySpy();

			Console.WriteLine($"testObject: {testObject}");
			Assert.IsNotNull(testObject);
			Assert.IsNotNull(testObject.ColumnNamesSpy);
			Assert.IsNotEmpty(testObject.ColumnNamesSpy);
			Assert.IsNotNull(testObject.EntityColumnsSpy);
			Assert.IsNotEmpty(testObject.EntityColumnsSpy);
			Assert.IsNotNull(testObject.KeyColumnNamesSpy);
			Assert.IsNotEmpty(testObject.KeyColumnNamesSpy);
			Assert.IsNotNull(testObject.TableNameSpy);
		}

		[Test]
		public void OrdersRepository_HasPublicConstructor_Test() => Assert.That(typeof(OrdersRepository).GetConstructors().Length, Is.GreaterThan(0));

		[Test]
		public void OrdersRepository_InheritsFromRepositoryBase_Test()
		{
			var baseType = typeof(OrdersRepository).BaseType;
			Assert.That(baseType!.Name, Contains.Substring("RepositoryBase"));
		}

		[Test]
		public void OrdersRepository_TypeExists_Test() => Assert.That(typeof(OrdersRepository), Is.Not.Null);
	}
}

