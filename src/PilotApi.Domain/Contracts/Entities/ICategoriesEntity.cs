using PilotApi.Domain.Contracts.Base;

namespace PilotApi.Domain.Contracts.Entities
{
	public interface ICategoriesEntity : IEntityBase
	{
		public int CategoryID { get; set; }

		public string CategoryName { get; set; }

		public string? Description { get; set; }

		public byte[] Picture { get; set; }
	}
}
