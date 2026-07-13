using PilotApi.Domain.Contracts.Entities;
using PilotApi.Repositories.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PilotApi.Repositories.Models.Entities
{
	[Table("Customers", Schema = "dbo")]
	public class CustomersEntity : EntityBase, ICustomersEntity
	{
		public string? Address { get; set; }

		public string? City { get; set; }

		public string CompanyName { get; set; }

		public string? ContactName { get; set; }

		public string? ContactTitle { get; set; }

		public string? Country { get; set; }

		[Key]
		public string CustomerID { get; set; }

		public string? Fax { get; set; }

		public string? Phone { get; set; }

		public string? PostalCode { get; set; }

		public string? Region { get; set; }
	}
}
