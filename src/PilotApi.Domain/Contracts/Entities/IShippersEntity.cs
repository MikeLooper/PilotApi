using PilotApi.Domain.Contracts.Base;

namespace PilotApi.Domain.Contracts.Entities
{
	public interface IShippersEntity : IEntityBase
	{
		public string CompanyName { get; set; }

		public string? Phone { get; set; }

		public int ShipperID { get; set; }
	}
}
