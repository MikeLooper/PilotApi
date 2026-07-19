using PilotApi.Domain.Contracts.Entities.Base;
using System;

namespace PilotApi.Domain.Contracts.Entities
{
	/// <summary>
	/// The interface for the OrderDetails entity, which represents the details of an order in the system.
	/// </summary>
	public interface IOrderDetailsEntity : IEntityBase
	{
		/// <summary>
		/// Gets or sets the discount applied to the order details.
		/// </summary>
		Single Discount { get; set; }

		/// <summary>
		/// Gets or sets the ID of the order associated with the order details.
		/// </summary>
		int OrderID { get; set; }

		/// <summary>
		/// Gets or sets the ID of the product associated with the order details.
		/// </summary>
		int ProductID { get; set; }

		/// <summary>
		/// Gets or sets the quantity of the product ordered in the order details.
		/// </summary>
		short Quantity { get; set; }

		/// <summary>
		/// Gets or sets the unit price of the product in the order details.
		/// </summary>
		decimal UnitPrice { get; set; }
	}
}
