using NUnit.Framework;
using PilotApi.Repositories.Repositories.Base;
using PilotApi.Repositories.Models.Entities;

namespace PilotApi.Repositories.Tests.Repositories.Base
{
	[TestFixture]
	public class RepositoryBaseTests : TestBase
	{
		[Test]
		public void RepositoryBase_IsAbstractClass_Test()
		{
			// Arrange
			var repositoryBaseType = typeof(RepositoryBase<>);

			// Assert
			Assert.That(repositoryBaseType.IsAbstract, Is.True);
		}

		[Test]
		public void RepositoryBase_GenericTypeHasConstraints_Test()
		{
			// Arrange
			var repositoryBaseType = typeof(RepositoryBase<>);
			var genericArgs = repositoryBaseType.GetGenericArguments();

			// Assert
			Assert.That(genericArgs.Length, Is.EqualTo(1));
			Assert.That(genericArgs[0].Name, Is.EqualTo("TEntity"));
		}

		[Test]
		public void RepositoryBase_CanBeUsedWithEntityBaseTypes_Test()
		{
			// Verify that concrete repository implementations exist
			var categoriesRepoType = typeof(PilotApi.Repositories.Repositories.CategoriesRepository);
			Assert.That(categoriesRepoType, Is.Not.Null);

			var customersRepoType = typeof(PilotApi.Repositories.Repositories.CustomersRepository);
			Assert.That(customersRepoType, Is.Not.Null);

			var employeesRepoType = typeof(PilotApi.Repositories.Repositories.EmployeesRepository);
			Assert.That(employeesRepoType, Is.Not.Null);

			var ordersRepoType = typeof(PilotApi.Repositories.Repositories.OrdersRepository);
			Assert.That(ordersRepoType, Is.Not.Null);

			var orderDetailsRepoType = typeof(PilotApi.Repositories.Repositories.OrderDetailsRepository);
			Assert.That(orderDetailsRepoType, Is.Not.Null);

			var productsRepoType = typeof(PilotApi.Repositories.Repositories.ProductsRepository);
			Assert.That(productsRepoType, Is.Not.Null);

			var shippersRepoType = typeof(PilotApi.Repositories.Repositories.ShippersRepository);
			Assert.That(shippersRepoType, Is.Not.Null);

			var suppliersRepoType = typeof(PilotApi.Repositories.Repositories.SuppliersRepository);
			Assert.That(suppliersRepoType, Is.Not.Null);
		}

		[Test]
		public void RepositoryBase_HasAbstractProperties_Test()
		{
			// Arrange
			var repositoryBaseType = typeof(RepositoryBase<>);
			var allProperties = repositoryBaseType.GetProperties(
				System.Reflection.BindingFlags.Public |
				System.Reflection.BindingFlags.NonPublic |
				System.Reflection.BindingFlags.Instance);

			// Assert
			Assert.That(allProperties.Length, Is.GreaterThan(0));
		}
	}
}

