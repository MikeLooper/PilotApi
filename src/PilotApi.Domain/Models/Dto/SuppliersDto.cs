
using PilotApi.Domain.Contracts.Base;
using System.ComponentModel.DataAnnotations;

namespace PilotApi.Domain.Models.Dto
{
	/// <summary>
	///  A DTO for the Suppliers table in the Northwind database.
	/// </summary>
	public class SuppliersDto : IDtoBase
	{
		/// <summary>
		/// Gets or sets the address of the supplier.
		/// </summary>
		public string? Address { get; set; }

		/// <summary>
		/// Gets or sets the city of the supplier.
		/// </summary>
		public string? City { get; set; }

		/// <summary>
		/// Gets or sets the company name of the supplier.
		/// </summary>
		[Required]
		public string CompanyName { get; set; }

		/// <summary>
		/// Gets or sets the contact name of the supplier.
		/// </summary>
		public string? ContactName { get; set; }

		/// <summary>
		/// Gets or sets the contact title of the supplier.
		/// </summary>
		public string? ContactTitle { get; set; }

		/// <summary>
		/// Gets or sets the country of the supplier.
		/// </summary>
		public string? Country { get; set; }

		/// <summary>
		/// Gets or sets the fax number of the supplier.
		/// </summary>
		public string? Fax { get; set; }

		/// <summary>
		/// Gets or sets the homepage URL of the supplier.
		/// </summary>
		public string? HomePage { get; set; }

		/// <summary>
		/// Gets or sets the phone number of the supplier.
		/// </summary>
		public string? Phone { get; set; }

		/// <summary>
		/// Gets or sets the postal code of the supplier.
		/// </summary>
		public string? PostalCode { get; set; }

		/// <summary>
		/// Gets or sets the region of the supplier.
		/// </summary>
		public string? Region { get; set; }

		/// <summary>
		/// Gets or sets the unique identifier of the supplier.
		/// </summary>
		[Required]
		public int SupplierID { get; set; }
	}
}
