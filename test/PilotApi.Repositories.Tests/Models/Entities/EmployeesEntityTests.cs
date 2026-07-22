using NUnit.Framework;
using PilotApi.Repositories.Models.Entities;
using System;

namespace PilotApi.Repositories.Tests.Models.Entities
{
	[TestFixture]
	public class EmployeesEntityTests : TestBase
	{
		[Test]
		public void EmployeesEntity_CanBeInstantiated_Test()
		{
			// Act
			var entity = new EmployeesEntity();

			// Assert
			Assert.That(entity, Is.Not.Null);
			Assert.That(entity, Is.InstanceOf<EmployeesEntity>());
		}

		[Test]
		public void EmployeesEntity_EmployeeIdPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new EmployeesEntity();
			var employeeId = 5;

			// Act
			entity.EmployeeID = employeeId;

			// Assert
			Assert.That(entity.EmployeeID, Is.EqualTo(employeeId));
		}

		[Test]
		public void EmployeesEntity_FirstNamePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new EmployeesEntity();
			var firstName = "John";

			// Act
			entity.FirstName = firstName;

			// Assert
			Assert.That(entity.FirstName, Is.EqualTo(firstName));
		}

		[Test]
		public void EmployeesEntity_LastNamePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new EmployeesEntity();
			var lastName = "Smith";

			// Act
			entity.LastName = lastName;

			// Assert
			Assert.That(entity.LastName, Is.EqualTo(lastName));
		}

		[Test]
		public void EmployeesEntity_TitlePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new EmployeesEntity();
			var title = "Sales Manager";

			// Act
			entity.Title = title;

			// Assert
			Assert.That(entity.Title, Is.EqualTo(title));
		}

		[Test]
		public void EmployeesEntity_TitleOfCourtesyPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new EmployeesEntity();
			var titleOfCourtesy = "Mr.";

			// Act
			entity.TitleOfCourtesy = titleOfCourtesy;

			// Assert
			Assert.That(entity.TitleOfCourtesy, Is.EqualTo(titleOfCourtesy));
		}

		[Test]
		public void EmployeesEntity_BirthDatePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new EmployeesEntity();
			var birthDate = new DateTime(1970, 5, 15);

			// Act
			entity.BirthDate = birthDate;

			// Assert
			Assert.That(entity.BirthDate, Is.EqualTo(birthDate));
		}

		[Test]
		public void EmployeesEntity_HireDatePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new EmployeesEntity();
			var hireDate = new DateTime(2020, 1, 1);

			// Act
			entity.HireDate = hireDate;

			// Assert
			Assert.That(entity.HireDate, Is.EqualTo(hireDate));
		}

		[Test]
		public void EmployeesEntity_AddressPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new EmployeesEntity();
			var address = "456 Oak Lane";

			// Act
			entity.Address = address;

			// Assert
			Assert.That(entity.Address, Is.EqualTo(address));
		}

		[Test]
		public void EmployeesEntity_CityPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new EmployeesEntity();
			var city = "Chicago";

			// Act
			entity.City = city;

			// Assert
			Assert.That(entity.City, Is.EqualTo(city));
		}

		[Test]
		public void EmployeesEntity_RegionPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new EmployeesEntity();
			var region = "IL";

			// Act
			entity.Region = region;

			// Assert
			Assert.That(entity.Region, Is.EqualTo(region));
		}

		[Test]
		public void EmployeesEntity_PostalCodePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new EmployeesEntity();
			var postalCode = "60601";

			// Act
			entity.PostalCode = postalCode;

			// Assert
			Assert.That(entity.PostalCode, Is.EqualTo(postalCode));
		}

		[Test]
		public void EmployeesEntity_CountryPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new EmployeesEntity();
			var country = "USA";

			// Act
			entity.Country = country;

			// Assert
			Assert.That(entity.Country, Is.EqualTo(country));
		}

		[Test]
		public void EmployeesEntity_HomePhonePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new EmployeesEntity();
			var homePhone = "555-1111";

			// Act
			entity.HomePhone = homePhone;

			// Assert
			Assert.That(entity.HomePhone, Is.EqualTo(homePhone));
		}

		[Test]
		public void EmployeesEntity_ExtensionPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new EmployeesEntity();
			var extension = "1234";

			// Act
			entity.Extension = extension;

			// Assert
			Assert.That(entity.Extension, Is.EqualTo(extension));
		}

		[Test]
		public void EmployeesEntity_PhotoPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new EmployeesEntity();
			var photo = new byte[] { 1, 2, 3, 4, 5 };

			// Act
			entity.Photo = photo;

			// Assert
			Assert.That(entity.Photo, Is.EqualTo(photo));
		}

		[Test]
		public void EmployeesEntity_NotesPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new EmployeesEntity();
			var notes = "Senior sales manager";

			// Act
			entity.Notes = notes;

			// Assert
			Assert.That(entity.Notes, Is.EqualTo(notes));
		}

		[Test]
		public void EmployeesEntity_ReportsToPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new EmployeesEntity();
			var reportsTo = 2;

			// Act
			entity.ReportsTo = reportsTo;

			// Assert
			Assert.That(entity.ReportsTo, Is.EqualTo(reportsTo));
		}

		[Test]
		public void EmployeesEntity_PhotoPathPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new EmployeesEntity();
			var photoPath = "photos/john_smith.jpg";

			// Act
			entity.PhotoPath = photoPath;

			// Assert
			Assert.That(entity.PhotoPath, Is.EqualTo(photoPath));
		}

		[Test]
		public void EmployeesEntity_ToStringReturnsFormattedString_Test()
		{
			// Arrange
			var entity = new EmployeesEntity
			{
				EmployeeID = 1,
				FirstName = "Jane",
				LastName = "Doe",
				Title = "Sales Manager"
			};

			// Act
			var result = entity.ToString();

			// Assert
			Assert.That(result, Is.Not.Null.And.Not.Empty);
			Assert.That(result, Contains.Substring("EmployeeID=1"));
			Assert.That(result, Contains.Substring("FirstName=Jane"));
		}
	}
}


