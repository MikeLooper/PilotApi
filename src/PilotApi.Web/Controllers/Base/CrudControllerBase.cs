using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PilotApi.Domain.Contracts.Base;
using PilotApi.Domain.Contracts.Services.Base;
using PilotApi.Domain.Models.Dto;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PilotApi.Web.Controllers
{
	/// <summary>
	/// A base for API controllers that implement CRUD operations for a given DTO type.
	/// </summary>
	/// <typeparam name="Dto">
	/// A DTO object.
	/// </typeparam>
	/// <example>
	/// Example usage:
	/// <code>
	///	[ApiVersion("1.0")]
	///	[Route("Categories")]
	///	public class CategoriesController : ControllerBase&lt;CategoriesDto&gt;
	///	{
	///		public CategoriesController(ICategoriesService service)
	///			: base(service)
	///		{
	///		}
	/// </code>
	/// </example>	[ApiController]
	[Produces("application/json")]
	[Consumes("application/json")]
	public class CrudControllerBase<Dto> : Controller where Dto : IDtoBase
	{
		/// <summary>
		/// Instantiates a new instance of the <see cref="CrudControllerBase{Dto}"/> class.
		/// </summary>
		/// <param name="service">
		/// A service that implements CRUD operations for the given DTO type.
		/// </param>
		public CrudControllerBase(IServiceBase<Dto> service)
		{
			this.Service = service;
		}

		/// <summary>
		/// Gets or sets the API version to apply to an operation.
		/// </summary>
		[FromHeader(Name = "ApiVersion")]
		public string? ApiVersion { get; set; }

		/// <summary>
		/// Gets the service that implements CRUD operations for the given DTO type.
		/// </summary>
		protected IServiceBase<Dto> Service { get; }

		/// <summary>
		/// Gets all DTO objects of the given type.
		/// </summary>
		/// <returns>
		/// A read only list of all DTO objects of the given type, or null if no objects exist.
		/// </returns>
		[HttpGet]
		[Route("get-all")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult?> GetAll()
		{
			var retrieveResponse = await this.Service.GetAllAsync();
			if (retrieveResponse.IsError)
			{
				this.Response.Headers["Warning"] = retrieveResponse.ErrorMessage;
				return this.BadRequest();
			}

			return this.Ok(retrieveResponse.Result
				.ToList()
				.AsReadOnly());
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
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult?> GetById(
			[Required][FromRoute] int id)
		{
			var retrieveResponse = await this.Service.GetByIdAsync(id);			
			if (retrieveResponse.IsError)
			{
				this.Response.Headers["Warning"] = retrieveResponse.ErrorMessage;
				return this.BadRequest();
			}

			return this.Ok(retrieveResponse.Result);
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
		[ProducesResponseType<AddResponseInt>(StatusCodes.Status200OK)]
		public async Task<IActionResult> Add<TReturn>(
			[Required][FromBody] Dto model)
		{
			var retrieveResponse = await this.Service.InsertAsync<TReturn>(model);
			if (retrieveResponse.IsError)
			{
				this.Response.Headers["Warning"] = retrieveResponse.ErrorMessage;
				return this.BadRequest();
			}

			var success = false;
			string? resultResponse = null;
			if (retrieveResponse.Result is int)
			{
				var changedInt = Convert.ToInt32(retrieveResponse.Result);
				success = changedInt > 0;
				resultResponse = changedInt.ToString();
			}
			else if (retrieveResponse.Result is string)
			{
				resultResponse = retrieveResponse.Result.ToString();
				success = !string.IsNullOrEmpty(resultResponse);
			}
			else
			{
				throw new InvalidOperationException(
							$"The generic datatype ('{typeof(TReturn).Name}') was not handled: Method='{nameof(this.Add)}' " + 
							$"({this.GetType().Name})");

			}

			if (!success)
			{
				this.Response.Headers["Warning"] = "Update attempt failed in the database";
				return this.BadRequest();
			}

			return this.Ok(new AddResponseString(resultResponse));
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
			[Required][FromBody] Dto model)
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
		public async Task<IActionResult> Delete(
			[Required][FromRoute] int id)
		{
			var retrieveResponse = await this.Service.DeleteAsync(id);
			
			if (retrieveResponse.IsError)
			{
				this.Response.Headers["Warning"] = retrieveResponse.ErrorMessage;
				return this.BadRequest();
			}

			return this.NoContent();
		}
	}
}
