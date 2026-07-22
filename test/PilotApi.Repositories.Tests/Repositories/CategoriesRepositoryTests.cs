using NUnit.Framework;
using PilotApi.Repositories.Repositories;
using PilotApi.Repositories.Tests.Testing.Utilities;
using System;

namespace PilotApi.Repositories.Tests.Repositories
{
	[TestFixture]
	public class CategoriesRepositoryTests : TestBase
	{
		[Test]
		public void CategoriesRepository_Constructor_Succeeds_Test()
		{
			// arrange
			// act
			var testObject = RepositoryDoublesUtilities.GetCategoriesRepositorySpy();

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
		public void CategoriesRepository_HasPublicConstructor_Test()
		{
			// Arrange
			var type = typeof(CategoriesRepository);
			var constructors = type.GetConstructors();

			// Assert
			Assert.That(constructors.Length, Is.GreaterThan(0));
		}

		[Test]
		public void CategoriesRepository_InheritsFromRepositoryBase_Test()
		{
			// Arrange
			var type = typeof(CategoriesRepository);
			var baseType = type.BaseType;

			// Assert
			Assert.That(baseType, Is.Not.Null);
			Assert.That(baseType!.Name, Contains.Substring("RepositoryBase"));
		}

		[Test]
		public void CategoriesRepository_TypeExists_Test()
		{
			// Arrange & Act
			var type = typeof(CategoriesRepository);

			// Assert
			Assert.That(type, Is.Not.Null);
		}
	}
}

