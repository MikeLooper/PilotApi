using NUnit.Framework;
using PilotApi.Repositories.Repositories;
using PilotApi.Repositories.Tests.Testing.Utilities;
using System;

namespace PilotApi.Repositories.Tests.Repositories
{
	[TestFixture]
	public class CustomersRepositoryTests : TestBase
	{
		[Test]
		public void CustomersRepository_Constructor_Succeeds_Test()
		{
			// arrange
			// act
			var testObject = RepositoryDoublesUtilities.GetCustomersRepositorySpy();

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
		public void CustomersRepository_HasPublicConstructor_Test()
		{
			var type = typeof(CustomersRepository);
			var constructors = type.GetConstructors();
			Assert.That(constructors.Length, Is.GreaterThan(0));
		}

		[Test]
		public void CustomersRepository_InheritsFromRepositoryBase_Test()
		{
			var type = typeof(CustomersRepository);
			var baseType = type.BaseType;
			Assert.That(baseType, Is.Not.Null);
			Assert.That(baseType!.Name, Contains.Substring("RepositoryBase"));
		}

		[Test]
		public void CustomersRepository_TypeExists_Test()
		{
			var type = typeof(CustomersRepository);
			Assert.That(type, Is.Not.Null);
		}
	}
}

