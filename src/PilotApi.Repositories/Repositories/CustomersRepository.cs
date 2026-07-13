using Microsoft.Extensions.Logging;
using PilotApi.Domain.Contracts.DataStore;
using PilotApi.Domain.Contracts.Entities;
using PilotApi.Domain.Contracts.Repository;
using PilotApi.Repositories.Base;
using System.Collections.Generic;

namespace PilotApi.Repositories.Repositories
{
	public class CustomersRepository : RepositoryBase<ICustomersEntity>, ICustomersRepository
	{
		public CustomersRepository(
			ILoggerFactory loggerFactory,
			IDataStoreContext dataStoreContext)
			: base(loggerFactory, dataStoreContext)
		{
		}

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

		protected override string TableName
		{
			get
			{
				return "Customers";
			}
		}
	}
}
