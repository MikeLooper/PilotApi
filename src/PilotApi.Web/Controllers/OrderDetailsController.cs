using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PilotApi.Domain.Contracts.Services;
using PilotApi.Domain.Models.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PilotApi.Web.Controllers
{
	/// <summary>
	/// A controller for accessing and manipulating OrderDetails data in the data store.
	/// </summary>
	[ApiVersion("1.0")]
	[Route("order-details")]

	public class OrderDetailsController : SimpleControllerBase
	{
		/// <summary>
		/// Instantiate a <see cref="OrderDetailsController"/> object.
		/// </summary>
		/// <param name="service">
		/// A service object.
		/// </param>
		public OrderDetailsController(IOrderDetailsService service)
		{
			this.Service = service;
		}

		/// <summary>
		/// Gets the service that implements CRUD operations for the given DTO type.
		/// </summary>
		protected IOrderDetailsService Service { get; }

		/// <summary>
		/// Gets all DTO objects from the orderdetails table.
		/// </summary>
		/// <returns>
		/// A read only list of all DTO objects from the orderdetails table, or null if no objects exist.
		/// </returns>
		[HttpGet]
		[Route("get-all")]
		[ProducesResponseType<IList<OrderDetailsDto>>(StatusCodes.Status200OK)]
		public async Task<IActionResult?> GetAll()
		{
			var retrieveResponse = await this.Service.GetAllAsync();
			if (retrieveResponse.IsError)
			{
				this.Response.Headers["Warning"] = retrieveResponse.ErrorMessage;
				return this.BadRequest();
			}

			if (retrieveResponse.Result == null)
			{
				return this.NotFound();
			}

			return this.Ok(retrieveResponse.Result
				.ToList()
				.AsReadOnly());
		}

		/// <summary>
		/// Gets a DTO object of the orderdetails record by its IDs.
		/// </summary>
		/// <param name="productId">
		/// An integer representing the Product ID of the orderdetails record to delete.
		/// </param>
		/// <param name="orderId">
		/// An integer representing the Order ID of the orderdetails record to delete.
		/// </param>
		/// <returns>
		/// A DTO object of the given type with the specified ID, or null if no such object exists.
		/// </returns>
		[HttpGet]
		[Route("get/product/{productId}/order/{orderId}")]
		[ProducesResponseType<OrderDetailsDto>(StatusCodes.Status200OK)]
		public async Task<IActionResult?> GetById(
			[Required][FromRoute] int productId,
			[Required][FromRoute] int orderId)
		{
			var retrieveResponse = await this.Service.GetByIdAsync(productId, orderId);
			if (retrieveResponse.IsError)
			{
				this.Response.Headers["Warning"] = retrieveResponse.ErrorMessage;
				return this.BadRequest();
			}

			if (retrieveResponse.Result == null)
			{
				return this.NotFound();
			}

			return this.Ok(retrieveResponse.Result);
		}

		/// <summary>
		/// Adds a new orderdetails record.
		/// </summary>
		/// <param name="model">
		/// A DTO object of the orderdetails record to add.
		/// </param>
		/// <returns>
		/// </returns>
		[HttpPost]
		[Route("add")]
		[ProducesResponseType<AddResponseInt>(StatusCodes.Status200OK)]
		public async Task<IActionResult> Add(
			[Required][FromBody] OrderDetailsDto model)
		{
			var retrieveResponse = await this.Service.InsertAsync<int>(model);
			if (retrieveResponse.IsError)
			{
				this.Response.Headers["Warning"] = retrieveResponse.ErrorMessage;
				return this.BadRequest();
			}

			if (retrieveResponse.Result <= 0)
			{
				return this.BadRequest();
			}

			return this.Ok(new AddResponseInt(retrieveResponse.Result));
		}

		/// <summary>
		/// Updates an existing orderdetails record.
		/// </summary>
		/// <param name="model">
		/// A DTO object of the orderdetails record to update.
		/// </param>
		/// <returns>
		/// </returns>
		[HttpPut]
		[Route("update")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Update(
			[Required][FromBody] OrderDetailsDto model)
		{
			var retrieveResponse = await this.Service.UpdateAsync(model);
			if (retrieveResponse.IsError)
			{
				this.Response.Headers["Warning"] = retrieveResponse.ErrorMessage;
				return this.BadRequest();
			}

			return this.NoContent();
		}

		/// <summary>
		/// Deletes a orderdetails record of the given type by its IDs.
		/// </summary>
		/// <param name="productId">
		/// An integer representing the Product ID of the orderdetails record to delete.
		/// </param>
		/// <param name="orderId">
		/// An integer representing the Order ID of the orderdetails record to delete.
		/// </param>
		/// <returns>
		/// </returns>
		[HttpDelete]
		[Route("delete/product/{productId}/order/{orderId}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Delete(
			[Required][FromRoute] int productId,
			[Required][FromRoute] int orderId)
		{
			var retrieveResponse = await this.Service.DeleteAsync(productId, orderId);
			if (retrieveResponse.IsError)
			{
				this.Response.Headers["Warning"] = retrieveResponse.ErrorMessage;
				return this.BadRequest();
			}

			return this.NoContent();
		}
	}
}
