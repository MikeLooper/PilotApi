using Microsoft.Extensions.Logging;
using PilotApi.Domain.Contracts.DataSource;
using PilotApi.Repositories.Contracts.Repository;
using PilotApi.Repositories.Models.Entities;
using PilotApi.Repositories.Repositories.Base;
using PilotApi.Shared.Handlers;
using System.Collections.Generic;

namespace PilotApi.Repositories.Repositories
{
	/// <summary>
	/// A repository for accessing and manipulating employee data in the data store.
	/// </summary>
	public class EmployeesRepository : RepositoryBase<EmployeesEntity>, IEmployeesRepository
	{
		/// <summary>
		/// Instantiates a new instance of the <see cref="EmployeesRepository"/> class.
		/// </summary>
		/// <param name="loggerFactory">
		/// A logger factory used to create loggers for logging information, warnings, and errors.
		/// </param>
		/// <param name="dataStoreContext">
		/// A data store context that provides access to the underlying data store for performing CRUD operations.
		/// </param>
		/// <param name="sqlBuilder">
		/// A SQL builder object.
		/// </param>
		public EmployeesRepository(
			ILoggerFactory loggerFactory,
			IDataSourceContext dataStoreContext,
			ISqlBuilder sqlBuilder)
			: base(loggerFactory, dataStoreContext, sqlBuilder)
		{
		}

		/// <inheritdoc/>>
		protected override List<string> ColumnNames
		{
			get
			{
				return new List<string>
				{
					"[Address]",
					"[BirthDate]",
					"[City]",
					"[Country]",
					"[EmployeeID]",
					"[Extension]",
					"[FirstName]",
					"[HireDate]",
					"[HomePhone]",
					"[LastName]",
					"[Notes]",
					"[Photo]",
					"[PhotoPath]",
					"[PostalCode]",
					"[Region]",
					"[ReportsTo]",
					"[Title]",
					"[TitleOfCourtesy]"
				};
			}
		}

		/// <inheritdoc/>>
		protected override List<string> KeyColumnNames
		{
			get
			{
				return new List<string>
				{
					"[EmployeeID]"
				};
			}
		}

		/// <inheritdoc/>>
		protected override string TableName
		{
			get
			{
				return "[dbo].[Employees]";
			}
		}
	}
}
