using NUnit.Framework;
using PilotApi.Repositories.Models.Entities;

namespace PilotApi.Repositories.Tests.Models.Entities
{
	[TestFixture]
	public class OrderDetailsEntityTests : TestBase
	{
		[Test]
		public void OrderDetailsEntity_CanBeInstantiated_Test()
		{
			// Act
			var entity = new OrderDetailsEntity();

			// Assert
			Assert.That(entity, Is.Not.Null);
			Assert.That(entity, Is.InstanceOf<OrderDetailsEntity>());
		}

		[Test]
		public void OrderDetailsEntity_OrderIdPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new OrderDetailsEntity();
			var orderId = 100;

			// Act
			entity.OrderID = orderId;

			// Assert
			Assert.That(entity.OrderID, Is.EqualTo(orderId));
		}

		[Test]
		public void OrderDetailsEntity_ProductIdPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new OrderDetailsEntity();
			var productId = 50;

			// Act
			entity.ProductID = productId;

			// Assert
			Assert.That(entity.ProductID, Is.EqualTo(productId));
		}

		[Test]
		public void OrderDetailsEntity_UnitPricePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new OrderDetailsEntity();
			var unitPrice = 19.99m;

			// Act
			entity.UnitPrice = unitPrice;

			// Assert
			Assert.That(entity.UnitPrice, Is.EqualTo(unitPrice));
		}

		[Test]
		public void OrderDetailsEntity_QuantityPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new OrderDetailsEntity();
			var quantity = (short)10;

			// Act
			entity.Quantity = quantity;

			// Assert
			Assert.That(entity.Quantity, Is.EqualTo(quantity));
		}

		[Test]
		public void OrderDetailsEntity_DiscountPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new OrderDetailsEntity();
			var discount = 0.15f;

			// Act
			entity.Discount = discount;

			// Assert
			Assert.That(entity.Discount, Is.EqualTo(discount));
		}

		[Test]
		public void OrderDetailsEntity_ToStringReturnsFormattedString_Test()
		{
			// Arrange
			var entity = new OrderDetailsEntity
			{
				OrderID = 100,
				ProductID = 50,
				UnitPrice = 19.99m,
				Quantity = 10,
				Discount = 0.15f
			};

			// Act
			var result = entity.ToString();

			// Assert
			Assert.That(result, Is.Not.Null.And.Not.Empty);
			Assert.That(result, Contains.Substring("OrderID=100"));
			Assert.That(result, Contains.Substring("ProductID=50"));
		}
	}
}


