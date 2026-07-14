using PilotApi.Domain.Contracts.Entities;
using PilotApi.Repositories.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PilotApi.Repositories.Models.Entities
{
	/// <summary>
	/// An entity class that represents an employee in the database.
	/// </summary>
	[Table("Employees", Schema = "dbo")]
	public class EmployeesEntity : EntityBase, IEmployeesEntity
	{
		/// <summary>
		/// Gets or sets the address of the employee.
		/// </summary>
		public string? Address { get; set; }

		/// <summary>
		/// Gets or sets the birth date of the employee.
		/// </summary>
		public DateTime? BirthDate { get; set; }

		/// <summary>
		/// Gets or sets the city of the employee.
		/// </summary>
		public string? City { get; set; }

		/// <summary>
		/// Gets or sets the country of the employee.
		/// </summary>
		public string? Country { get; set; }

		/// <summary>
		/// Gets or sets the unique identifier of the employee.
		/// </summary>
		[Key]
		public int EmployeeID { get; set; }

		/// <summary>
		/// Gets or sets the extension number of the employee.
		/// </summary>
		public string? Extension { get; set; }

		/// <summary>
		/// Gets or sets the first name of the employee.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Gets or sets the hire date of the employee.
		/// </summary>
		public DateTime? HireDate { get; set; }

		/// <summary>
		/// Gets or sets the home phone number of the employee.
		/// </summary>
		public string? HomePhone { get; set; }

		/// <summary>
		/// Gets or sets the last name of the employee.
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Gets or sets the notes about the employee.
		/// </summary>
		public string? Notes { get; set; }

		/// <summary>
		/// Gets or sets the photo of the employee as a byte array.
		/// </summary>
		public byte[] Photo { get; set; }

		/// <summary>
		/// Gets or sets the path to the photo of the employee.
		/// </summary>
		public string? PhotoPath { get; set; }

		/// <summary>
		/// Gets or sets the postal code of the employee.
		/// </summary>
		public string? PostalCode { get; set; }

		/// <summary>
		/// Gets or sets the region of the employee.
		/// </summary>
		public string? Region { get; set; }

		/// <summary>
		/// Gets or sets the unique identifier of the employee's manager (the employee to whom this employee reports).
		/// </summary>
		public int? ReportsTo { get; set; }

		/// <summary>
		/// Gets or sets the title of the employee (e.g., "Sales Representative", "Manager").
		/// </summary>
		public string? Title { get; set; }

		/// <summary>
		/// Gets or sets the title of courtesy for the employee (e.g., "Mr.", "Ms.", "Dr.").
		/// </summary>
		public string? TitleOfCourtesy { get; set; }
	}
}
