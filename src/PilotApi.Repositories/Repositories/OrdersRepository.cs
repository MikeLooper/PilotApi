using Microsoft.Extensions.Logging;
using PilotApi.Domain.Contracts.DataStore;
using PilotApi.Domain.Contracts.Entities;
using PilotApi.Domain.Contracts.Repository;
using PilotApi.Repositories.Base;
using System.Collections.Generic;

namespace PilotApi.Repositories.Repositories
{
	public class OrdersRepository : RepositoryBase<IOrdersEntity>, IOrdersRepository
	{
		public OrdersRepository(
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
					"OrderID",
					"CustomerID",
					"EmployeeID",
					"OrderDate",
					"RequiredDate",
					"ShippedDate",
					"ShipVia",
					"Freight",
					"ShipName",
					"ShipAddress",
					"ShipCity",
					"ShipRegion",
					"ShipPostalCode",
					"ShipCountry"
				};
			}
		}

		protected override string TableName
		{
			get
			{
				return "Orders";
			}
		}
	}
}
