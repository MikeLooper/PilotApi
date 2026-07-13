using PilotApi.Domain.Contracts.Entities;
using PilotApi.Repositories.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PilotApi.Repositories.Models.Entities
{
	[Table("Employees", Schema = "dbo")]
	public class EmployeesEntity : EntityBase, IEmployeesEntity
	{
		public string? Address { get; set; }

		public DateTime? BirthDate { get; set; }

		public string? City { get; set; }

		public string? Country { get; set; }

		[Key]
		public int EmployeeID { get; set; }

		public string? Extension { get; set; }

		public string FirstName { get; set; }

		public DateTime? HireDate { get; set; }

		public string? HomePhone { get; set; }

		public string LastName { get; set; }

		public string? Notes { get; set; }

		public byte[] Photo { get; set; }

		public string? PhotoPath { get; set; }

		public string? PostalCode { get; set; }

		public string? Region { get; set; }

		public int? ReportsTo { get; set; }

		public string? Title { get; set; }

		public string? TitleOfCourtesy { get; set; }
	}
}
