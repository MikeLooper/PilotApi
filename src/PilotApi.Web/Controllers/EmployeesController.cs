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
	/// A contrller for accessing and manipulating Employees data in the data store.
	/// </summary>
	[ApiVersion("1.0")]
	[Route("employees")]

	public class EmployeesController : SimpleControllerBase
	{
		/// <summary>
		/// Instantiate a <see cref="EmployeesController"/> object.
		/// </summary>
		/// <param name="service">
		/// A service object.
		/// </param>
		public EmployeesController(IEmployeesService service)
		{
			this.Service = service;
		}

		/// <summary>
		/// Gets the service that implements CRUD operations for the given DTO type.
		/// </summary>
		protected IEmployeesService Service { get; }

		/// <summary>
		/// Gets all DTO objects from the employee table.
		/// </summary>
		/// <returns>
		/// A read only list of all DTO objects from the employee table, or null if no objects exist.
		/// </returns>
		[HttpGet]
		[Route("get-all")]
		[ProducesResponseType<IList<EmployeesDto>>(StatusCodes.Status200OK)]
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
		/// Gets an employee record by its ID.
		/// </summary>
		/// <param name="employeeId">
		/// The ID of the employee record to retrieve.
		/// </param>
		/// <returns>
		/// A DTO object of the employee record with the specified ID, or null if no such object exists.
		/// </returns>
		[HttpGet]
		[Route("get/{employeeId}")]
		[ProducesResponseType<EmployeesDto>(StatusCodes.Status200OK)]
		public async Task<IActionResult?> GetById(
			[Required][FromRoute] int employeeId)
		{
			var result = await this.Service.GetByIdAsync(employeeId);
			if (result == null)
			{
				return this.NotFound();
			}

			return this.Ok(result);
		}

		/// <summary>
		/// Adds a new employee record.
		/// </summary>
		/// <param name="model">
		/// A DTO object of the employee record to add.
		/// </param>
		/// <returns>
		/// </returns>
		[HttpPost]
		[Route("add")]
		[ProducesResponseType<AddResponse>(StatusCodes.Status200OK)]
		public async Task<IActionResult> Add(
			[Required][FromBody] EmployeesDto model)
		{
			var result = await this.Service.InsertAsync(model);
			if (result <= 0)
			{
				return this.BadRequest();
			}

			return this.Ok(new AddResponse(result));
		}

		/// <summary>
		/// Updates an existing employee record.
		/// </summary>
		/// <param name="model">
		/// A DTO object of the employee record to update.
		/// </param>
		/// <returns>
		/// </returns>
		[HttpPut]
		[Route("update")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Update(
			[Required][FromBody] EmployeesDto model)
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
		/// Deletes an employee record by its ID.
		/// </summary>
		/// <param name="employeeId">
		/// An integer representing the ID of the employee record to delete.
		/// </param>
		/// <returns>
		/// </returns>
		[HttpDelete]
		[Route("delete/{employeeId}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Delete(
			[Required][FromRoute] int employeeId)
		{
			var result = await this.Service.DeleteAsync(employeeId);
			if (!result)
			{
				this.Response.Headers["Warning"] = "Delete attempt failed in the database";
				return this.BadRequest();
			}

			return this.NoContent();
		}
	}
}
