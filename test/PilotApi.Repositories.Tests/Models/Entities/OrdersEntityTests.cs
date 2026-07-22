using NUnit.Framework;
using PilotApi.Repositories.Models.Entities;
using System;

namespace PilotApi.Repositories.Tests.Models.Entities
{
	[TestFixture]
	public class OrdersEntityTests : TestBase
	{
		[Test]
		public void OrdersEntity_CanBeInstantiated_Test()
		{
			// Act
			var entity = new OrdersEntity();

			// Assert
			Assert.That(entity, Is.Not.Null);
			Assert.That(entity, Is.InstanceOf<OrdersEntity>());
		}

		[Test]
		public void OrdersEntity_OrderIdPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new OrdersEntity();
			var orderId = 1001;

			// Act
			entity.OrderID = orderId;

			// Assert
			Assert.That(entity.OrderID, Is.EqualTo(orderId));
		}

		[Test]
		public void OrdersEntity_CustomerIdPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new OrdersEntity();
			var customerId = "CUST001";

			// Act
			entity.CustomerID = customerId;

			// Assert
			Assert.That(entity.CustomerID, Is.EqualTo(customerId));
		}

		[Test]
		public void OrdersEntity_EmployeeIdPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new OrdersEntity();
			var employeeId = 5;

			// Act
			entity.EmployeeID = employeeId;

			// Assert
			Assert.That(entity.EmployeeID, Is.EqualTo(employeeId));
		}

		[Test]
		public void OrdersEntity_OrderDatePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new OrdersEntity();
			var orderDate = new DateTime(2023, 6, 15);

			// Act
			entity.OrderDate = orderDate;

			// Assert
			Assert.That(entity.OrderDate, Is.EqualTo(orderDate));
		}

		[Test]
		public void OrdersEntity_RequiredDatePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new OrdersEntity();
			var requiredDate = new DateTime(2023, 7, 1);

			// Act
			entity.RequiredDate = requiredDate;

			// Assert
			Assert.That(entity.RequiredDate, Is.EqualTo(requiredDate));
		}

		[Test]
		public void OrdersEntity_ShippedDatePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new OrdersEntity();
			var shippedDate = new DateTime(2023, 6, 20);

			// Act
			entity.ShippedDate = shippedDate;

			// Assert
			Assert.That(entity.ShippedDate, Is.EqualTo(shippedDate));
		}

		[Test]
		public void OrdersEntity_ShipViaPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new OrdersEntity();
			var shipVia = 2;

			// Act
			entity.ShipVia = shipVia;

			// Assert
			Assert.That(entity.ShipVia, Is.EqualTo(shipVia));
		}

		[Test]
		public void OrdersEntity_FreightPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new OrdersEntity();
			var freight = 25.50m;

			// Act
			entity.Freight = freight;

			// Assert
			Assert.That(entity.Freight, Is.EqualTo(freight));
		}

		[Test]
		public void OrdersEntity_ShipNamePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new OrdersEntity();
			var shipName = "John Smith";

			// Act
			entity.ShipName = shipName;

			// Assert
			Assert.That(entity.ShipName, Is.EqualTo(shipName));
		}

		[Test]
		public void OrdersEntity_ShipAddressPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new OrdersEntity();
			var shipAddress = "789 Elm Street";

			// Act
			entity.ShipAddress = shipAddress;

			// Assert
			Assert.That(entity.ShipAddress, Is.EqualTo(shipAddress));
		}

		[Test]
		public void OrdersEntity_ShipCityPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new OrdersEntity();
			var shipCity = "San Francisco";

			// Act
			entity.ShipCity = shipCity;

			// Assert
			Assert.That(entity.ShipCity, Is.EqualTo(shipCity));
		}

		[Test]
		public void OrdersEntity_ShipRegionPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new OrdersEntity();
			var shipRegion = "CA";

			// Act
			entity.ShipRegion = shipRegion;

			// Assert
			Assert.That(entity.ShipRegion, Is.EqualTo(shipRegion));
		}

		[Test]
		public void OrdersEntity_ShipPostalCodePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new OrdersEntity();
			var shipPostalCode = "94105";

			// Act
			entity.ShipPostalCode = shipPostalCode;

			// Assert
			Assert.That(entity.ShipPostalCode, Is.EqualTo(shipPostalCode));
		}

		[Test]
		public void OrdersEntity_ShipCountryPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new OrdersEntity();
			var shipCountry = "USA";

			// Act
			entity.ShipCountry = shipCountry;

			// Assert
			Assert.That(entity.ShipCountry, Is.EqualTo(shipCountry));
		}

		[Test]
		public void OrdersEntity_ToStringReturnsFormattedString_Test()
		{
			// Arrange
			var entity = new OrdersEntity
			{
				OrderID = 1001,
				CustomerID = "CUST001",
				OrderDate = new DateTime(2023, 6, 15)
			};

			// Act
			var result = entity.ToString();

			// Assert
			Assert.That(result, Is.Not.Null.And.Not.Empty);
			Assert.That(result, Contains.Substring("OrderID=1001"));
			Assert.That(result, Contains.Substring("CustomerID=CUST001"));
		}
	}
}


