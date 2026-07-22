using NUnit.Framework;
using PilotApi.Repositories.Repositories;
using PilotApi.Repositories.Tests.Testing.Utilities;
using System;

namespace PilotApi.Repositories.Tests.Repositories
{
	[TestFixture]
	public class ShippersRepositoryTests : TestBase
	{
		[Test]
		public void ShippersRepository_Constructor_Succeeds_Test()
		{
			// arrange
			// act
			var testObject = RepositoryDoublesUtilities.GetShippersRepositorySpy();

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
		public void ShippersRepository_HasPublicConstructor_Test() => Assert.That(typeof(ShippersRepository).GetConstructors().Length, Is.GreaterThan(0));

		[Test]
		public void ShippersRepository_InheritsFromRepositoryBase_Test()
		{
			var baseType = typeof(ShippersRepository).BaseType;
			Assert.That(baseType!.Name, Contains.Substring("RepositoryBase"));
		}

		[Test]
		public void ShippersRepository_TypeExists_Test() => Assert.That(typeof(ShippersRepository), Is.Not.Null);
	}
}

