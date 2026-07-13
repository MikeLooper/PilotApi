using Microsoft.Extensions.Logging;
using PilotApi.Domain.Contracts.DataStore;
using PilotApi.Domain.Contracts.Entities;
using PilotApi.Domain.Contracts.Repository;
using PilotApi.Repositories.Base;
using System.Collections.Generic;

namespace PilotApi.Repositories.Repositories
{
	public class SuppliersRepository : RepositoryBase<ISuppliersEntity>, ISuppliersRepository
	{
		public SuppliersRepository(
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
					"SupplierID",
					"CompanyName",
					"ContactName",
					"ContactTitle",
					"Address",
					"City",
					"Region",
					"PostalCode",
					"Country",
					"Phone",
					"Fax",
					"HomePage"
				};
			}
		}

		protected override string TableName
		{
			get
			{
				return "Suppliers";
			}
		}
	}
}
