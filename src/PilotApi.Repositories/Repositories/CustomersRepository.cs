using Microsoft.Extensions.Logging;
using PilotApi.Domain.Contracts.DataStore;
using PilotApi.Domain.Contracts.Entities;
using PilotApi.Domain.Contracts.Repository;
using PilotApi.Repositories.Base;
using System.Collections.Generic;

namespace PilotApi.Repositories.Repositories
{
	/// <summary>
	/// A repository for accessing and manipulating customer data in the data store.
	/// </summary>
	public class CustomersRepository : RepositoryBase<ICustomersEntity>, ICustomersRepository
	{
		/// <summary>
		/// Instantiates a new instance of the <see cref="CustomersRepository"/> class.
		/// </summary>
		/// <param name="loggerFactory">
		/// A logger factory used to create loggers for logging information, warnings, and errors.
		/// </param>
		/// <param name="dataStoreContext">
		/// A data store context that provides access to the underlying data store for performing CRUD operations.
		/// </param>
		public CustomersRepository(
			ILoggerFactory loggerFactory,
			IDataStoreContext dataStoreContext)
			: base(loggerFactory, dataStoreContext)
		{
		}

		/// <inheritdoc/>>
		protected override List<string> ColumnNames
		{
			get
			{
				return new List<string>
				{
					"CustomerID",
					"CompanyName",
					"ContactName",
					"ContactTitle",
					"Address",
					"City",
					"Region",
					"PostalCode",
					"Country",
					"Phone",
					"Fax"
				};
			}
		}

		/// <inheritdoc/>>
		protected override string KeyColumnName
		{
			get
			{
				return "CustomerID";
			}
		}

		/// <inheritdoc/>>
		protected override string TableName
		{
			get
			{
				return "Customers";
			}
		}
	}
}
