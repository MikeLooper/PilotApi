using NUnit.Framework;
using PilotApi.Repositories.Repositories;
using PilotApi.Repositories.Tests.Testing.Utilities;
using System;

namespace PilotApi.Repositories.Tests.Repositories
{
	[TestFixture]
	public class OrderDetailsRepositoryTests : TestBase
	{
		[Test]
		public void OrderDetailsRepository_Constructor_Succeeds_Test()
		{
			// arrange
			// act
			var testObject = RepositoryDoublesUtilities.GetOrderDetailsRepositorySpy();

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
		public void OrderDetailsRepository_HasPublicConstructor_Test() => Assert.That(typeof(OrderDetailsRepository).GetConstructors().Length, Is.GreaterThan(0));

		[Test]
		public void OrderDetailsRepository_InheritsFromRepositoryBase_Test()
		{
			var baseType = typeof(OrderDetailsRepository).BaseType;
			Assert.That(baseType!.Name, Contains.Substring("RepositoryBase"));
		}

		[Test]
		public void OrderDetailsRepository_TypeExists_Test() => Assert.That(typeof(OrderDetailsRepository), Is.Not.Null);
	}
}

