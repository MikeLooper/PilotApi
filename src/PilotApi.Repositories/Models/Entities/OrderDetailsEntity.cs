using PilotApi.Domain.Contracts.Entities;
using PilotApi.Repositories.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PilotApi.Repositories.Models.Entities
{
	[Table("Order Details", Schema = "dbo")]
	public class OrderDetailsEntity : EntityBase, IOrderDetailsEntity
	{
		public Single Discount { get; set; }

		public int OrderID { get; set; }

		public int ProductID { get; set; }

		public short Quantity { get; set; }

		public decimal UnitPrice { get; set; }
	}
}
