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
	/// A contrller for accessing and manipulating Suppliers data in the data store.
	/// </summary>
	[ApiVersion("1.0")]
	[Route("suppliers")]

	public class SuppliersController : SimpleControllerBase
	{
		/// <summary>
		/// Instantiate a <see cref="SuppliersController"/> object.
		/// </summary>
		/// <param name="service">
		/// A service object.
		/// </param>
		public SuppliersController(ISuppliersService service)
		{
			this.Service = service;
		}

		/// <summary>
		/// Gets the service that implements CRUD operations for the given DTO type.
		/// </summary>
		protected ISuppliersService Service { get; }

		/// <summary>
		/// Gets all DTO objects from the supplier table.
		/// </summary>
		/// <returns>
		/// A read only list of all DTO objects from the supplier table, or null if no objects exist.
		/// </returns>
		[HttpGet]
		[Route("get-all")]
		[ProducesResponseType<IList<SuppliersDto>>(StatusCodes.Status200OK)]
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
		/// Gets a DTO object of the supplier record by its ID.
		/// </summary>
		/// <param name="supplierId">
		/// The ID of the supplier record to retrieve.
		/// </param>
		/// <returns>
		/// A DTO object of the supplier record with the specified ID, or null if no such object exists.
		/// </returns>
		[HttpGet]
		[Route("get/{supplierId}")]
		[ProducesResponseType<SuppliersDto>(StatusCodes.Status200OK)]
		public async Task<IActionResult?> GetById(
			[Required][FromRoute] int supplierId)
		{
			var retrieveResponse = await this.Service.GetByIdAsync(supplierId);
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
		/// Adds a new supplier record.
		/// </summary>
		/// <param name="model">
		/// A DTO object of the supplier record to add.
		/// </param>
		/// <returns>
		/// </returns>
		[HttpPost]
		[Route("add")]
		[ProducesResponseType<AddResponseInt>(StatusCodes.Status200OK)]
		public async Task<IActionResult> Add(
			[Required][FromBody] SuppliersDto model)
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
		/// Updates an existing supplier record.
		/// </summary>
		/// <param name="model">
		/// A DTO object of the supplier record to update.
		/// </param>
		/// <returns>
		/// </returns>
		[HttpPut]
		[Route("update")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Update(
			[Required][FromBody] SuppliersDto model)
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
		/// Deletes a supplier record by its ID.
		/// </summary>
		/// <param name="supplierId">
		/// An integer representing the ID of the supplier record to delete.
		/// </param>
		/// <returns>
		/// </returns>
		[HttpDelete]
		[Route("delete/{supplierId}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Delete(
			[Required][FromRoute] int supplierId)
		{
			var retrieveResponse = await this.Service.DeleteAsync(supplierId);
			if (retrieveResponse.IsError)
			{
				this.Response.Headers["Warning"] = retrieveResponse.ErrorMessage;
				return this.BadRequest();
			}

			return this.NoContent();
		}
	}
}
