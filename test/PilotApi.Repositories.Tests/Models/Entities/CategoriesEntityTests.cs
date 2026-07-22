using NUnit.Framework;
using PilotApi.Repositories.Models.Entities;

namespace PilotApi.Repositories.Tests.Models.Entities
{
	[TestFixture]
	public class CategoriesEntityTests : TestBase
	{
		[Test]
		public void CategoriesEntity_CanBeInstantiated_Test()
		{
			// Act
			var entity = new CategoriesEntity();

			// Assert
			Assert.That(entity, Is.Not.Null);
			Assert.That(entity, Is.InstanceOf<CategoriesEntity>());
		}

		[Test]
		public void CategoriesEntity_CategoryIdPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new CategoriesEntity();
			var categoryId = 42;

			// Act
			entity.CategoryID = categoryId;

			// Assert
			Assert.That(entity.CategoryID, Is.EqualTo(categoryId));
		}

		[Test]
		public void CategoriesEntity_CategoryNamePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new CategoriesEntity();
			var categoryName = "Electronics";

			// Act
			entity.CategoryName = categoryName;

			// Assert
			Assert.That(entity.CategoryName, Is.EqualTo(categoryName));
		}

		[Test]
		public void CategoriesEntity_DescriptionPropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new CategoriesEntity();
			var description = "Electronic devices and accessories";

			// Act
			entity.Description = description;

			// Assert
			Assert.That(entity.Description, Is.EqualTo(description));
		}

		[Test]
		public void CategoriesEntity_PicturePropertyCanBeSet_Test()
		{
			// Arrange
			var entity = new CategoriesEntity();
			var picture = new byte[] { 1, 2, 3, 4, 5 };

			// Act
			entity.Picture = picture;

			// Assert
			Assert.That(entity.Picture, Is.EqualTo(picture));
		}

		[Test]
		public void CategoriesEntity_ToStringReturnsFormattedString_Test()
		{
			// Arrange
			var entity = new CategoriesEntity
			{
				CategoryID = 1,
				CategoryName = "Books",
				Description = "Books and literature",
				Picture = new byte[] { 1, 2, 3 }
			};

			// Act
			var result = entity.ToString();

			// Assert
			Assert.That(result, Is.Not.Null.And.Not.Empty);
			Assert.That(result, Contains.Substring("CategoryID=1"));
			Assert.That(result, Contains.Substring("CategoryName=Books"));
		}
	}
}


