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
	/// A repository for accessing and manipulating supplier data in the data store.
	/// </summary>
	public class SuppliersRepository : RepositoryBase<SuppliersEntity>, ISuppliersRepository
	{
		/// <summary>
		/// Instantiates a new instance of the <see cref="SuppliersRepository"/> class.
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
		public SuppliersRepository(
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
					"[City]",
					"[CompanyName]",
					"[ContactName]",
					"[ContactTitle]",
					"[Country]",
					"[Fax]",
					"[HomePage]",
					"[Phone]",
					"[PostalCode]",
					"[Region]",
					"[SupplierID]"
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
					"[SupplierID]"
				};
			}
		}

		/// <inheritdoc/>>
		protected override string TableName
		{
			get
			{
				return "[dbo].[Suppliers]";
			}
		}
	}
}
