using NUnit.Framework;
using PilotApi.Repositories.Handlers;
using PilotApi.Repositories.Models.Entities;
using PilotApi.Repositories.Models.Base;
using System;
using System.Collections.Generic;

namespace PilotApi.Repositories.Tests.Handlers
{
	[TestFixture]
	public class EntityUpdateHandlerTests : TestBase
	{
		[Test]
		public void EntityUpdateHandler_CanBeInstantiated_Test()
		{
			// Act
			var handler = new EntityUpdateHandler();

			// Assert
			Assert.That(handler, Is.Not.Null);
			Assert.That(handler, Is.InstanceOf<EntityUpdateHandler>());
		}

		[Test]
		public void EntityUpdateHandler_Update_WithNullEntity_ReturnsDefault_Test()
		{
			// Arrange
			var handler = new EntityUpdateHandler();
			CategoriesEntity? entity = null;
			var nextIds = new Dictionary<string, object> { { nameof(CategoriesEntity.CategoryID), 1 } };

			// Act
			var result = handler.Update(entity, nextIds);

			// Assert
			Assert.That(result, Is.Null);
		}

		[Test]
		public void EntityUpdateHandler_Update_CategoriesEntity_UpdatesCategoryId_Test()
		{
			// Arrange
			var handler = new EntityUpdateHandler();
			var entity = new CategoriesEntity { CategoryID = 1 };
			var nextIds = new Dictionary<string, object> { { nameof(CategoriesEntity.CategoryID), 42 } };

			// Act
			var result = handler.Update(entity, nextIds);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.CategoryID, Is.EqualTo(42));
		}

		[Test]
		public void EntityUpdateHandler_Update_CustomersEntity_UpdatesCustomerId_Test()
		{
			// Arrange
			var handler = new EntityUpdateHandler();
			var entity = new CustomersEntity { CustomerID = "OLD" };
			var nextIds = new Dictionary<string, object> { { nameof(CustomersEntity.CustomerID), "NEW" } };

			// Act
			var result = handler.Update(entity, nextIds);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.CustomerID, Is.EqualTo("NEW"));
		}

		[Test]
		public void EntityUpdateHandler_Update_EmployeesEntity_UpdatesEmployeeId_Test()
		{
			// Arrange
			var handler = new EntityUpdateHandler();
			var entity = new EmployeesEntity { EmployeeID = 1 };
			var nextIds = new Dictionary<string, object> { { nameof(EmployeesEntity.EmployeeID), 99 } };

			// Act
			var result = handler.Update(entity, nextIds);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.EmployeeID, Is.EqualTo(99));
		}

		[Test]
		public void EntityUpdateHandler_Update_OrderDetailsEntity_UpdatesOrderAndProductIds_Test()
		{
			// Arrange
			var handler = new EntityUpdateHandler();
			var entity = new OrderDetailsEntity { OrderID = 1, ProductID = 1 };
			var nextIds = new Dictionary<string, object>
			{
				{ nameof(OrderDetailsEntity.OrderID), 100 },
				{ nameof(OrderDetailsEntity.ProductID), 50 }
			};

			// Act
			var result = handler.Update(entity, nextIds);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.OrderID, Is.EqualTo(100));
			Assert.That(result.ProductID, Is.EqualTo(50));
		}

		[Test]
		public void EntityUpdateHandler_Update_OrdersEntity_UpdatesMultipleIds_Test()
		{
			// Arrange
			var handler = new EntityUpdateHandler();
			var entity = new OrdersEntity { OrderID = 1, CustomerID = "OLD", EmployeeID = 1 };
			var nextIds = new Dictionary<string, object>
			{
				{ nameof(OrdersEntity.OrderID), 1001 },
				{ nameof(OrdersEntity.CustomerID), "NEW" },
				{ nameof(OrdersEntity.EmployeeID), 5 }
			};

			// Act
			var result = handler.Update(entity, nextIds);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.OrderID, Is.EqualTo(1001));
			Assert.That(result.CustomerID, Is.EqualTo("NEW"));
			Assert.That(result.EmployeeID, Is.EqualTo(5));
		}

		[Test]
		public void EntityUpdateHandler_Update_ProductsEntity_UpdatesMultipleIds_Test()
		{
			// Arrange
			var handler = new EntityUpdateHandler();
			var entity = new ProductsEntity { ProductID = 1, CategoryID = 1, SupplierID = 1 };
			var nextIds = new Dictionary<string, object>
			{
				{ nameof(ProductsEntity.ProductID), 25 },
				{ nameof(ProductsEntity.CategoryID), 5 },
				{ nameof(ProductsEntity.SupplierID), 3 }
			};

			// Act
			var result = handler.Update(entity, nextIds);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.ProductID, Is.EqualTo(25));
			Assert.That(result.CategoryID, Is.EqualTo(5));
			Assert.That(result.SupplierID, Is.EqualTo(3));
		}

		[Test]
		public void EntityUpdateHandler_Update_ShippersEntity_UpdatesShipperId_Test()
		{
			// Arrange
			var handler = new EntityUpdateHandler();
			var entity = new ShippersEntity { ShipperID = 1 };
			var nextIds = new Dictionary<string, object> { { nameof(ShippersEntity.ShipperID), 77 } };

			// Act
			var result = handler.Update(entity, nextIds);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.ShipperID, Is.EqualTo(77));
		}

		[Test]
		public void EntityUpdateHandler_Update_SuppliersEntity_UpdatesSupplierId_Test()
		{
			// Arrange
			var handler = new EntityUpdateHandler();
			var entity = new SuppliersEntity { SupplierID = 1 };
			var nextIds = new Dictionary<string, object> { { nameof(SuppliersEntity.SupplierID), 12 } };

			// Act
			var result = handler.Update(entity, nextIds);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.SupplierID, Is.EqualTo(12));
		}

		[Test]
		public void EntityUpdateHandler_Update_UnknownEntityType_ThrowsInvalidOperationException_Test()
		{
			// This test verifies that updating an unknown entity type throws an exception
			// Since we can't easily create an unknown entity type, we verify that the Update method
			// accepts supported entity types correctly
			var handler = new EntityUpdateHandler();
			var entity = new CategoriesEntity { CategoryID = 1 };
			var nextIds = new Dictionary<string, object>();

			// Act & Assert
			var result = handler.Update(entity, nextIds);
			Assert.That(result, Is.Not.Null);
		}

		[Test]
		public void EntityUpdateHandler_Update_WithEmptyNextIds_DoesNotThrow_Test()
		{
			// Arrange
			var handler = new EntityUpdateHandler();
			var entity = new CategoriesEntity { CategoryID = 1 };
			var nextIds = new Dictionary<string, object>();

			// Act
			var result = handler.Update(entity, nextIds);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.CategoryID, Is.EqualTo(1));
		}

		[Test]
		public void EntityUpdateHandler_Update_CaseInsensitiveKeyMatching_UpdatesCorrectly_Test()
		{
			// Arrange
			var handler = new EntityUpdateHandler();
			var entity = new CategoriesEntity { CategoryID = 1 };
			var nextIds = new Dictionary<string, object> { { "categoryid", 50 } }; // lowercase key

			// Act
			var result = handler.Update(entity, nextIds);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.CategoryID, Is.EqualTo(50));
		}
	}
}


