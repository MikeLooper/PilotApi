using PilotApi.Domain.Contracts.Entities;
using PilotApi.Repositories.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PilotApi.Repositories.Models.Entities
{
	[Table("Categories", Schema = "dbo")]
	public class CategoriesEntity : EntityBase, ICategoriesEntity
	{
		[Key]
		public int CategoryID { get; set; }

		public string CategoryName { get; set; }

		public string? Description { get; set; }

		public byte[] Picture { get; set; }
	}
}
