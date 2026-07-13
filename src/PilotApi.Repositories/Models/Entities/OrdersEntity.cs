using PilotApi.Domain.Contracts.Entities;
using PilotApi.Repositories.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PilotApi.Repositories.Models.Entities
{
	[Table("Orders", Schema = "dbo")]
	public class OrdersEntity : EntityBase, IOrdersEntity
	{
		public string? CustomerID { get; set; }

		public int? EmployeeID { get; set; }

		public decimal? Freight { get; set; }

		public DateTime? OrderDate { get; set; }

		[Key]
		public int OrderID { get; set; }

		public DateTime? RequiredDate { get; set; }

		public string? ShipAddress { get; set; }

		public string? ShipCity { get; set; }

		public string? ShipCountry { get; set; }

		public string? ShipName { get; set; }

		public DateTime? ShippedDate { get; set; }

		public string? ShipPostalCode { get; set; }

		public string? ShipRegion { get; set; }

		public int? ShipVia { get; set; }

	}
}
