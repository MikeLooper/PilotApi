using NUnit.Framework;
using PilotApi.Repositories.Models.Entities;

namespace PilotApi.Repositories.Tests.Models.Entities
{
	[TestFixture]
	public class SuppliersEntityTests : TestBase
	{
		[Test]
		public void SuppliersEntity_CanBeInstantiated_Test()
		{
			// Act
			var entity = new SuppliersEntity();

			// Assert
			Assert.That(entity, Is.Not.Null);
			Assert.That(entity, Is.InstanceOf<SuppliersEntity>());
		}

		[Test]
		public void SuppliersEntity_SupplierIdPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new SuppliersEntity();
			var supplierId = 1;

			// Act
			entity.SupplierID = supplierId;

			// Assert
			Assert.That(entity.SupplierID, Is.EqualTo(supplierId));
		}

		[Test]
		public void SuppliersEntity_CompanyNamePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new SuppliersEntity();
			var companyName = "Tech Supplies Inc";

			// Act
			entity.CompanyName = companyName;

			// Assert
			Assert.That(entity.CompanyName, Is.EqualTo(companyName));
		}

		[Test]
		public void SuppliersEntity_ContactNamePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new SuppliersEntity();
			var contactName = "Bob Johnson";

			// Act
			entity.ContactName = contactName;

			// Assert
			Assert.That(entity.ContactName, Is.EqualTo(contactName));
		}

		[Test]
		public void SuppliersEntity_ContactTitlePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new SuppliersEntity();
			var contactTitle = "Sales Manager";

			// Act
			entity.ContactTitle = contactTitle;

			// Assert
			Assert.That(entity.ContactTitle, Is.EqualTo(contactTitle));
		}

		[Test]
		public void SuppliersEntity_AddressPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new SuppliersEntity();
			var address = "321 Tech Road";

			// Act
			entity.Address = address;

			// Assert
			Assert.That(entity.Address, Is.EqualTo(address));
		}

		[Test]
		public void SuppliersEntity_CityPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new SuppliersEntity();
			var city = "Seattle";

			// Act
			entity.City = city;

			// Assert
			Assert.That(entity.City, Is.EqualTo(city));
		}

		[Test]
		public void SuppliersEntity_RegionPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new SuppliersEntity();
			var region = "WA";

			// Act
			entity.Region = region;

			// Assert
			Assert.That(entity.Region, Is.EqualTo(region));
		}

		[Test]
		public void SuppliersEntity_PostalCodePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new SuppliersEntity();
			var postalCode = "98101";

			// Act
			entity.PostalCode = postalCode;

			// Assert
			Assert.That(entity.PostalCode, Is.EqualTo(postalCode));
		}

		[Test]
		public void SuppliersEntity_CountryPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new SuppliersEntity();
			var country = "USA";

			// Act
			entity.Country = country;

			// Assert
			Assert.That(entity.Country, Is.EqualTo(country));
		}

		[Test]
		public void SuppliersEntity_PhonePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new SuppliersEntity();
			var phone = "206-555-1234";

			// Act
			entity.Phone = phone;

			// Assert
			Assert.That(entity.Phone, Is.EqualTo(phone));
		}

		[Test]
		public void SuppliersEntity_FaxPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new SuppliersEntity();
			var fax = "206-555-5678";

			// Act
			entity.Fax = fax;

			// Assert
			Assert.That(entity.Fax, Is.EqualTo(fax));
		}

		[Test]
		public void SuppliersEntity_HomePagePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new SuppliersEntity();
			var homePage = "www.techsupplies.com";

			// Act
			entity.HomePage = homePage;

			// Assert
			Assert.That(entity.HomePage, Is.EqualTo(homePage));
		}

		[Test]
		public void SuppliersEntity_ToStringReturnsFormattedString_Test()
		{
			// Arrange
			var entity = new SuppliersEntity
			{
				SupplierID = 1,
				CompanyName = "Tech Supplies Inc",
				ContactName = "Bob Johnson",
				City = "Seattle"
			};

			// Act
			var result = entity.ToString();

			// Assert
			Assert.That(result, Is.Not.Null.And.Not.Empty);
			Assert.That(result, Contains.Substring("SupplierID=1"));
			Assert.That(result, Contains.Substring("CompanyName=Tech Supplies Inc"));
		}
	}
}


