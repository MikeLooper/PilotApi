using NUnit.Framework;
using PilotApi.Repositories.Models.Entities;

namespace PilotApi.Repositories.Tests.Models.Entities
{
	[TestFixture]
	public class CustomersEntityTests : TestBase
	{
		[Test]
		public void CustomersEntity_CanBeInstantiated_Test()
		{
			// Act
			var entity = new CustomersEntity();

			// Assert
			Assert.That(entity, Is.Not.Null);
			Assert.That(entity, Is.InstanceOf<CustomersEntity>());
		}

		[Test]
		public void CustomersEntity_CustomerIdPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new CustomersEntity();
			var customerId = "CUST001";

			// Act
			entity.CustomerID = customerId;

			// Assert
			Assert.That(entity.CustomerID, Is.EqualTo(customerId));
		}

		[Test]
		public void CustomersEntity_AddressPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new CustomersEntity();
			var address = "123 Main Street";

			// Act
			entity.Address = address;

			// Assert
			Assert.That(entity.Address, Is.EqualTo(address));
		}

		[Test]
		public void CustomersEntity_CityPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new CustomersEntity();
			var city = "New York";

			// Act
			entity.City = city;

			// Assert
			Assert.That(entity.City, Is.EqualTo(city));
		}

		[Test]
		public void CustomersEntity_CompanyNamePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new CustomersEntity();
			var companyName = "Acme Corp";

			// Act
			entity.CompanyName = companyName;

			// Assert
			Assert.That(entity.CompanyName, Is.EqualTo(companyName));
		}

		[Test]
		public void CustomersEntity_ContactNamePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new CustomersEntity();
			var contactName = "John Doe";

			// Act
			entity.ContactName = contactName;

			// Assert
			Assert.That(entity.ContactName, Is.EqualTo(contactName));
		}

		[Test]
		public void CustomersEntity_ContactTitlePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new CustomersEntity();
			var contactTitle = "Manager";

			// Act
			entity.ContactTitle = contactTitle;

			// Assert
			Assert.That(entity.ContactTitle, Is.EqualTo(contactTitle));
		}

		[Test]
		public void CustomersEntity_CountryPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new CustomersEntity();
			var country = "USA";

			// Act
			entity.Country = country;

			// Assert
			Assert.That(entity.Country, Is.EqualTo(country));
		}

		[Test]
		public void CustomersEntity_FaxPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new CustomersEntity();
			var fax = "555-1234";

			// Act
			entity.Fax = fax;

			// Assert
			Assert.That(entity.Fax, Is.EqualTo(fax));
		}

		[Test]
		public void CustomersEntity_PhonePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new CustomersEntity();
			var phone = "555-5678";

			// Act
			entity.Phone = phone;

			// Assert
			Assert.That(entity.Phone, Is.EqualTo(phone));
		}

		[Test]
		public void CustomersEntity_PostalCodePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new CustomersEntity();
			var postalCode = "10001";

			// Act
			entity.PostalCode = postalCode;

			// Assert
			Assert.That(entity.PostalCode, Is.EqualTo(postalCode));
		}

		[Test]
		public void CustomersEntity_RegionPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new CustomersEntity();
			var region = "NY";

			// Act
			entity.Region = region;

			// Assert
			Assert.That(entity.Region, Is.EqualTo(region));
		}

		[Test]
		public void CustomersEntity_ToStringReturnsFormattedString_Test()
		{
			// Arrange
			var entity = new CustomersEntity
			{
				CustomerID = "CUST001",
				CompanyName = "Tech Solutions",
				ContactName = "Jane Smith",
				City = "Boston"
			};

			// Act
			var result = entity.ToString();

			// Assert
			Assert.That(result, Is.Not.Null.And.Not.Empty);
			Assert.That(result, Contains.Substring("CustomerID=CUST001"));
			Assert.That(result, Contains.Substring("CompanyName=Tech Solutions"));
		}
	}
}


