using PilotApi.Domain.Contracts.Entities.Base;

namespace PilotApi.Domain.Contracts.Entities
{
	/// <summary>
	/// An interface that defines the properties of a customer entity.
	/// </summary>
	public interface ICustomersEntity : IEntityBase
	{
		/// <summary>
		/// Gets or sets the address of the customer.
		/// </summary>
		string? Address { get; set; }

		/// <summary>
		/// Gets or sets the city of the customer.
		/// </summary>
		string? City { get; set; }

		/// <summary>
		/// Gets or sets the company name of the customer.
		/// </summary>
		string? CompanyName { get; set; }

		/// <summary>
		/// Gets or sets the contact name of the customer.
		/// </summary>
		string? ContactName { get; set; }

		/// <summary>
		/// Gets or sets the contact title of the customer.
		/// </summary>
		string? ContactTitle { get; set; }

		/// <summary>
		/// Gets or sets the country of the customer.
		/// </summary>
		string? Country { get; set; }

		/// <summary>
		/// Gets or sets the customer ID of the customer.
		/// </summary>
		string? CustomerID { get; set; }

		/// <summary>
		/// Gets or sets the fax number of the customer.
		/// </summary>
		string? Fax { get; set; }

		/// <summary>
		/// Gets or sets the phone number of the customer.
		/// </summary>
		string? Phone { get; set; }

		/// <summary>
		/// Gets or sets the postal code of the customer.
		/// </summary>
		string? PostalCode { get; set; }

		/// <summary>
		/// Gets or sets the region of the customer.
		/// </summary>
		string? Region { get; set; }
	}
}
