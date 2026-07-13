using PilotApi.Domain.Contracts.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PilotApi.Repositories.Models.Base
{
	[Table("Shippers", Schema = "dbo")]
	public class ShippersEntity : EntityBase, IShippersEntity
	{
		public string CompanyName { get; set; }

		public string? Phone { get; set; }

		[Key]
		public int ShipperID { get; set; }
	}
}
