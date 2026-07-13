using PilotApi.Domain.Contracts.Base;

namespace PilotApi.Domain.Models.Dto
{
	public class ShippersDto : IDtoBase
	{
		public string CompanyName { get; set; }

		public string? Phone { get; set; }

		public int ShipperID { get; set; }
	}
}
