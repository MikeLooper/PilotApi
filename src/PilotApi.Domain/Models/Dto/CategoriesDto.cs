using PilotApi.Domain.Contracts.Base;
using System.ComponentModel.DataAnnotations;

namespace PilotApi.Domain.Models.Dto
{
	/// <summary>
	/// A DTO for the Categories table in the Northwind database.
	/// </summary>
	public class CategoriesDto : IDtoBase
	{
		/// <summary>
		/// Gets or sets the ID of the category.
		/// </summary>
		[Required]
		public int CategoryID { get; set; }

		/// <summary>
		/// Gets or sets the name of the category.
		/// </summary>
		[Required]
		public string CategoryName { get; set; }

		/// <summary>
		/// Gets or sets the description of the category.
		/// </summary>
		public string? Description { get; set; }

		/// <summary>
		/// Gets or sets the picture of the category.
		/// </summary>
		public byte[] Picture { get; set; }
	}
}
