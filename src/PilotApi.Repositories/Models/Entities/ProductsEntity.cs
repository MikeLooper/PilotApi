using PilotApi.Domain.Contracts.Entities;
using PilotApi.Repositories.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PilotApi.Repositories.Models.Entities
{
	[Table("Products", Schema = "dbo")]
	public class ProductsEntity : EntityBase, IProductsEntity
	{
		public int? CategoryID { get; set; }

		public bool Discontinued { get; set; }

		[Key]
		public int ProductID { get; set; }

		public string ProductName { get; set; }

		public string? QuantityPerUnit { get; set; }

		public short ReorderLevel { get; set; }

		public int? SupplierID { get; set; }

		public decimal? UnitPrice { get; set; }

		public short UnitsInStock { get; set; }

		public short UnitsOnOrder { get; set; }
	}
}
