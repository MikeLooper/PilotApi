using NUnit.Framework;
using PilotApi.Repositories.Repositories;
using PilotApi.Repositories.Tests.Testing.Utilities;
using System;

namespace PilotApi.Repositories.Tests.Repositories
{
	[TestFixture]
	public class SuppliersRepositoryTests : TestBase
	{
		[Test]
		public void SuppliersRepository_Constructor_Succeeds_Test()
		{
			// arrange
			// act
			var testObject = RepositoryDoublesUtilities.GetSuppliersRepositorySpy();

			// assert
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
		public void SuppliersRepository_HasPublicConstructor_Test() => Assert.That(typeof(SuppliersRepository).GetConstructors().Length, Is.GreaterThan(0));

		[Test]
		public void SuppliersRepository_InheritsFromRepositoryBase_Test()
		{
			var baseType = typeof(SuppliersRepository).BaseType;
			Assert.That(baseType!.Name, Contains.Substring("RepositoryBase"));
		}

		[Test]
		public void SuppliersRepository_TypeExists_Test() => Assert.That(typeof(SuppliersRepository), Is.Not.Null);
	}
}

