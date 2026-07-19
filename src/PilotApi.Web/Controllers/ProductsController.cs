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
	/// A contrller for accessing and manipulating Products data in the data store.
	/// </summary>
	[ApiVersion("1.0")]
	[Route("products")]

	public class ProductsController : SimpleControllerBase
	{
		/// <summary>
		/// Instantiate a <see cref="ProductsController"/> object.
		/// </summary>
		/// <param name="service">
		/// A service object.
		/// </param>
		public ProductsController(IProductsService service)
		{
			this.Service = service;
		}

		/// <summary>
		/// Gets the service that implements CRUD operations for the given DTO type.
		/// </summary>
		protected IProductsService Service { get; }

		/// <summary>
		/// Gets all DTO objects from the product table.
		/// </summary>
		/// <returns>
		/// A read only list of all DTO objects from the product table, or null if no objects exist.
		/// </returns>
		[HttpGet]
		[Route("get-all")]
		[ProducesResponseType<IList<ProductsDto>>(StatusCodes.Status200OK)]
		public async Task<IActionResult?> GetAll()
		{
			var result = await this.Service.GetAllAsync();
			if (result == null)
			{
				return this.NotFound();
			}

			return this.Ok(result.ToList().AsReadOnly());
		}

		/// <summary>
		/// Gets a DTO object of the product record by its ID.
		/// </summary>
		/// <param name="productId">
		/// The ID of the product record to retrieve.
		/// </param>
		/// <returns>
		/// A DTO object of the product record with the specified ID, or null if no such object exists.
		/// </returns>
		[HttpGet]
		[Route("get/{productId}")]
		[ProducesResponseType<ProductsDto>(StatusCodes.Status200OK)]
		public async Task<IActionResult?> GetById(
			[Required][FromRoute] int productId)
		{
			var result = await this.Service.GetByIdAsync(productId);
			if (result == null)
			{
				return this.NotFound();
			}

			return this.Ok(result);
		}

		/// <summary>
		/// Adds a new product record.
		/// </summary>
		/// <param name="model">
		/// A DTO object of the product record to add.
		/// </param>
		/// <returns>
		/// </returns>
		[HttpPost]
		[Route("add")]
		[ProducesResponseType<AddResponse>(StatusCodes.Status200OK)]
		public async Task<IActionResult> Add(
			[Required][FromBody] ProductsDto model)
		{
			var result = await this.Service.InsertAsync(model);
			if (result <= 0)
			{
				return this.BadRequest();
			}

			return this.Ok(new AddResponse(result));
		}

		/// <summary>
		/// Updates an existing product record.
		/// </summary>
		/// <param name="model">
		/// A DTO object of the product record to update.
		/// </param>
		/// <returns>
		/// </returns>
		[HttpPut]
		[Route("update")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Update(
			[Required][FromBody] ProductsDto model)
		{
			var result = await this.Service.UpdateAsync(model);
			if (!result)
			{
				this.Response.Headers["Warning"] = "Update attempt failed in the database";
				return this.BadRequest();
			}

			return this.NoContent();
		}

		/// <summary>
		/// Deletes a product record by its ID.
		/// </summary>
		/// <param name="productId">
		/// An integer representing the ID of the product record to delete.
		/// </param>
		/// <returns>
		/// </returns>
		[HttpDelete]
		[Route("delete/{productId}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Delete(
			[Required][FromRoute] int productId)
		{
			var result = await this.Service.DeleteAsync(productId);
			if (!result)
			{
				this.Response.Headers["Warning"] = "Delete attempt failed in the database";
				return this.BadRequest();
			}

			return this.NoContent();
		}
	}
}
