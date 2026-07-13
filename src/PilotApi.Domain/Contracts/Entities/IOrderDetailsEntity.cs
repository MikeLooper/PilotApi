using PilotApi.Domain.Contracts.Base;
using System;

namespace PilotApi.Domain.Contracts.Entities
{
	public interface IOrderDetailsEntity : IEntityBase
	{
		public Single Discount { get; set; }

		public int OrderID { get; set; }

		public int ProductID { get; set; }

		public short Quantity { get; set; }

		public decimal UnitPrice { get; set; }
	}
}
