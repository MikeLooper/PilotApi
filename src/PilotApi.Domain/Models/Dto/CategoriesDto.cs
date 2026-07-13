using PilotApi.Domain.Contracts.Base;

namespace PilotApi.Domain.Models.Dto
{
	public class CategoriesDto : IDtoBase
	{
		public int CategoryID { get; set; }

		public string CategoryName { get; set; }

		public string? Description { get; set; }

		public byte[] Picture { get; set; }
	}
}
