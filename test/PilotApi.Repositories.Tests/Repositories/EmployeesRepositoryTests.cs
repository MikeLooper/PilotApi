using NUnit.Framework;
using PilotApi.Repositories.Repositories;
using PilotApi.Repositories.Tests.Testing.Utilities;
using System;

namespace PilotApi.Repositories.Tests.Repositories
{
	[TestFixture]
	public class EmployeesRepositoryTests : TestBase
	{
		[Test]
		public void EmployeesRepository_Constructor_Succeeds_Test()
		{
			// arrange
			// act
			var testObject = RepositoryDoublesUtilities.GetEmployeesRepositorySpy();

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
		public void EmployeesRepository_HasPublicConstructor_Test() => Assert.That(typeof(EmployeesRepository).GetConstructors().Length, Is.GreaterThan(0));

		[Test]
		public void EmployeesRepository_InheritsFromRepositoryBase_Test()
		{
			var baseType = typeof(EmployeesRepository).BaseType;
			Assert.That(baseType!.Name, Contains.Substring("RepositoryBase"));
		}

		[Test]
		public void EmployeesRepository_TypeExists_Test() => Assert.That(typeof(EmployeesRepository), Is.Not.Null);
	}
}

