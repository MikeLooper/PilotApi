using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PilotApi.Domain.Contracts.Services;
using PilotApi.Domain.Models.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PilotApi.Web.Controllers
{
	/// <summary>
	/// A contrller for accessing and manipulating Categories data in the data store.
	/// </summary>
	[ApiVersion("1.0")]
	[Route("Categories")]

	public class CategoriesController : SimpleControllerBase
	{
		/// <summary>
		/// Instantiate a <see cref="CategoriesController"/> object.
		/// </summary>
		/// <param name="service">
		/// A service object.
		/// </param>
		public CategoriesController(ICategoriesService service)
		{
			this.Service = service;
		}

		/// <summary>
		/// Gets the service that implements CRUD operations for the given DTO type.
		/// </summary>
		protected ICategoriesService Service { get; }

		/// <summary>
		/// Gets all DTO objects of the given type.
		/// </summary>
		/// <returns>
		/// A read only list of all DTO objects of the given type, or null if no objects exist.
		/// </returns>
		[HttpGet]
		[Route("get-all")]
		[ProducesResponseType<IList<CategoriesDto>>(StatusCodes.Status200OK)]
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
		/// Gets a DTO object of the given type by its ID.
		/// </summary>
		/// <param name="id">
		/// The ID of the DTO object to retrieve.
		/// </param>
		/// <returns>
		/// A DTO object of the given type with the specified ID, or null if no such object exists.
		/// </returns>
		[HttpGet]
		[Route("get/{id:int}")]
		[ProducesResponseType<CategoriesDto>(StatusCodes.Status200OK)]
		public async Task<IActionResult?> GetById(
			[Required][FromRoute] int id)
		{
			var result = await this.Service.GetByIdAsync(id);
			if (result == null)
			{
				return this.NotFound();
			}

			return this.Ok(result);
		}

		/// <summary>
		/// Adds a new DTO object of the given type.
		/// </summary>
		/// <param name="model">
		/// A DTO object of the given type to add.
		/// </param>
		/// <returns>
		/// </returns>
		[HttpPost]
		[Route("add")]
		[ProducesResponseType<AddResponse>(StatusCodes.Status200OK)]
		public async Task<IActionResult> Add(
			[Required][FromBody] CategoriesDto model)
		{
			var result = await this.Service.InsertAsync(model);
			if (result <= 0)
			{
				return this.BadRequest();
			}

			return this.Ok();
		}

		/// <summary>
		/// Updates an existing DTO object of the given type.
		/// </summary>
		/// <param name="model">
		/// A DTO object of the given type to update.
		/// </param>
		/// <returns>
		/// </returns>
		[HttpPost]
		[Route("update")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Update(
			[Required][FromBody] CategoriesDto model)
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
		/// Deletes a DTO object of the given type by its ID.
		/// </summary>
		/// <param name="id">
		/// An integer representing the ID of the DTO object to delete.
		/// </param>
		/// <returns>
		/// </returns>
		[HttpPost]
		[Route("delete/{id:int}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Delete(
			[Required][FromRoute] int id)
		{
			var result = await this.Service.DeleteAsync(id);
			if (!result)
			{
				this.Response.Headers["Warning"] = "Delete attempt failed in the database";
				return this.BadRequest();
			}

			return this.NoContent();
		}
	}
}
