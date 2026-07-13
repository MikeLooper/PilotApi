using PilotApi.Domain.Contracts.Base;

namespace PilotApi.Domain.Contracts.Entities
{
	public interface IProductsEntity : IEntityBase
	{
		public int? CategoryID { get; set; }

		public bool Discontinued { get; set; }

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
