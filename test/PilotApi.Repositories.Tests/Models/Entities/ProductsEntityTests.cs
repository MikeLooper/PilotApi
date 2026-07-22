using NUnit.Framework;
using PilotApi.Repositories.Models.Entities;

namespace PilotApi.Repositories.Tests.Models.Entities
{
	[TestFixture]
	public class ProductsEntityTests : TestBase
	{
		[Test]
		public void ProductsEntity_CanBeInstantiated_Test()
		{
			// Act
			var entity = new ProductsEntity();

			// Assert
			Assert.That(entity, Is.Not.Null);
			Assert.That(entity, Is.InstanceOf<ProductsEntity>());
		}

		[Test]
		public void ProductsEntity_ProductIdPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new ProductsEntity();
			var productId = 25;

			// Act
			entity.ProductID = productId;

			// Assert
			Assert.That(entity.ProductID, Is.EqualTo(productId));
		}

		[Test]
		public void ProductsEntity_ProductNamePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new ProductsEntity();
			var productName = "Laptop";

			// Act
			entity.ProductName = productName;

			// Assert
			Assert.That(entity.ProductName, Is.EqualTo(productName));
		}

		[Test]
		public void ProductsEntity_SupplierIdPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new ProductsEntity();
			var supplierId = 3;

			// Act
			entity.SupplierID = supplierId;

			// Assert
			Assert.That(entity.SupplierID, Is.EqualTo(supplierId));
		}

		[Test]
		public void ProductsEntity_CategoryIdPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new ProductsEntity();
			var categoryId = 1;

			// Act
			entity.CategoryID = categoryId;

			// Assert
			Assert.That(entity.CategoryID, Is.EqualTo(categoryId));
		}

		[Test]
		public void ProductsEntity_QuantityPerUnitPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new ProductsEntity();
			var quantityPerUnit = "10 boxes";

			// Act
			entity.QuantityPerUnit = quantityPerUnit;

			// Assert
			Assert.That(entity.QuantityPerUnit, Is.EqualTo(quantityPerUnit));
		}

		[Test]
		public void ProductsEntity_UnitPricePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new ProductsEntity();
			var unitPrice = 599.99m;

			// Act
			entity.UnitPrice = unitPrice;

			// Assert
			Assert.That(entity.UnitPrice, Is.EqualTo(unitPrice));
		}

		[Test]
		public void ProductsEntity_UnitsInStockPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new ProductsEntity();
			var unitsInStock = (short)50;

			// Act
			entity.UnitsInStock = unitsInStock;

			// Assert
			Assert.That(entity.UnitsInStock, Is.EqualTo(unitsInStock));
		}

		[Test]
		public void ProductsEntity_UnitsOnOrderPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new ProductsEntity();
			var unitsOnOrder = (short)10;

			// Act
			entity.UnitsOnOrder = unitsOnOrder;

			// Assert
			Assert.That(entity.UnitsOnOrder, Is.EqualTo(unitsOnOrder));
		}

		[Test]
		public void ProductsEntity_ReorderLevelPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new ProductsEntity();
			var reorderLevel = (short)20;

			// Act
			entity.ReorderLevel = reorderLevel;

			// Assert
			Assert.That(entity.ReorderLevel, Is.EqualTo(reorderLevel));
		}

		[Test]
		public void ProductsEntity_DiscontinuedPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new ProductsEntity();
			var discontinued = true;

			// Act
			entity.Discontinued = discontinued;

			// Assert
			Assert.That(entity.Discontinued, Is.EqualTo(discontinued));
		}

		[Test]
		public void ProductsEntity_ToStringReturnsFormattedString_Test()
		{
			// Arrange
			var entity = new ProductsEntity
			{
				ProductID = 25,
				ProductName = "Laptop",
				UnitPrice = 599.99m,
				UnitsInStock = 50
			};

			// Act
			var result = entity.ToString();

			// Assert
			Assert.That(result, Is.Not.Null.And.Not.Empty);
			Assert.That(result, Contains.Substring("ProductID=25"));
			Assert.That(result, Contains.Substring("ProductName=Laptop"));
		}
	}
}


