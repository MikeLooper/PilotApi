using PilotApi.Domain.Contracts.Entities;
using PilotApi.Repositories.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PilotApi.Repositories.Models.Entities
{
	/// <summary>
	/// A class that represents a category entity in the database.
	/// </summary>
	[Table("Categories", Schema = "dbo")]
	public class CategoriesEntity : EntityBase, ICategoriesEntity
	{
		/// <summary>
		/// Gets or sets the ID of the category.
		/// </summary>
		[Key]
		public int CategoryID { get; set; }

		/// <summary>
		/// Gets or sets the name of the category.
		/// </summary>
		public string CategoryName { get; set; }

		/// <summary>
		/// Gets or sets the description of the category.
		/// </summary>
		public string? Description { get; set; }

		/// <summary>
		/// Gets or sets the picture of the category as a byte array.
		/// </summary>
		public byte[] Picture { get; set; }
	}
}
