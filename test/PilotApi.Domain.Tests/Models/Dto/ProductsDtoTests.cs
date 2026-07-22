using NUnit.Framework;
using PilotApi.Domain.Models.Dto;

namespace PilotApi.Domain.Tests.Models.Dto
{
	[TestFixture]
	public class ProductsDtoTests
	{
		[Test]
		public void ProductsDto_Properties_RoundTripAndToStringReturnsExpectedValue_Test()
		{
			ProductsDto dto = new()
			{
				CategoryID = 4,
				Discontinued = true,
				ProductID = 18,
				ProductName = "Chef Anton's Cajun Seasoning",
				QuantityPerUnit = "48 - 6 oz jars",
				ReorderLevel = 10,
				SupplierID = 2,
				UnitPrice = 22.5m,
				UnitsInStock = 53,
				UnitsOnOrder = 0,
			};

			Assert.That(dto.CategoryID, Is.EqualTo(4));
			Assert.That(dto.Discontinued, Is.True);
			Assert.That(dto.ProductID, Is.EqualTo(18));
			Assert.That(dto.ProductName, Is.EqualTo("Chef Anton's Cajun Seasoning"));
			Assert.That(dto.QuantityPerUnit, Is.EqualTo("48 - 6 oz jars"));
			Assert.That(dto.ReorderLevel, Is.EqualTo(10));
			Assert.That(dto.SupplierID, Is.EqualTo(2));
			Assert.That(dto.UnitPrice, Is.EqualTo(22.5m));
			Assert.That(dto.UnitsInStock, Is.EqualTo(53));
			Assert.That(dto.UnitsOnOrder, Is.EqualTo(0));
			Assert.That(dto.ToString(), Is.EqualTo("CategoryID=4, Discontinued=True, ProductID=18, ProductName=Chef Anton's Cajun Seasoning, QuantityPerUnit=48 - 6 oz jars, ReorderLevel=10, SupplierID=2, UnitPrice=22.5, UnitsInStock=53, UnitsOnOrder=0"));
		}
	}
}

