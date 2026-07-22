using NUnit.Framework;
using PilotApi.Repositories.Models.Base;

namespace PilotApi.Repositories.Tests.Models.Entities
{
	[TestFixture]
	public class ShippersEntityTests : TestBase
	{
		[Test]
		public void ShippersEntity_CanBeInstantiated_Test()
		{
			// Act
			var entity = new ShippersEntity();

			// Assert
			Assert.That(entity, Is.Not.Null);
			Assert.That(entity, Is.InstanceOf<ShippersEntity>());
		}

		[Test]
		public void ShippersEntity_ShipperIdPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new ShippersEntity();
			var shipperId = 1;

			// Act
			entity.ShipperID = shipperId;

			// Assert
			Assert.That(entity.ShipperID, Is.EqualTo(shipperId));
		}

		[Test]
		public void ShippersEntity_CompanyNamePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new ShippersEntity();
			var companyName = "FedEx";

			// Act
			entity.CompanyName = companyName;

			// Assert
			Assert.That(entity.CompanyName, Is.EqualTo(companyName));
		}

		[Test]
		public void ShippersEntity_PhonePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new ShippersEntity();
			var phone = "1-800-123-4567";

			// Act
			entity.Phone = phone;

			// Assert
			Assert.That(entity.Phone, Is.EqualTo(phone));
		}

		[Test]
		public void ShippersEntity_ToStringReturnsFormattedString_Test()
		{
			// Arrange
			var entity = new ShippersEntity
			{
				ShipperID = 1,
				CompanyName = "FedEx",
				Phone = "1-800-123-4567"
			};

			// Act
			var result = entity.ToString();

			// Assert
			Assert.That(result, Is.Not.Null.And.Not.Empty);
			Assert.That(result, Contains.Substring("ShipperID=1"));
			Assert.That(result, Contains.Substring("CompanyName=FedEx"));
		}
	}
}


