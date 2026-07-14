using Microsoft.Extensions.Logging;
using PilotApi.Domain.Contracts.DataStore;
using PilotApi.Domain.Contracts.Entities;
using PilotApi.Domain.Contracts.Repository;
using PilotApi.Repositories.Base;
using System.Collections.Generic;

namespace PilotApi.Repositories.Repositories
{
	/// <summary>
	/// A repository for accessing and manipulating order data in the data store.
	/// </summary>
	public class OrdersRepository : RepositoryBase<IOrdersEntity>, IOrdersRepository
	{
		/// <summary>
		/// Instantiates a new instance of the <see cref="OrdersRepository"/> class.
		/// </summary>
		/// <param name="loggerFactory">
		/// A logger factory used to create loggers for logging information, warnings, and errors.
		/// </param>
		/// <param name="dataStoreContext">
		/// A data store context that provides access to the underlying data store for performing CRUD operations.
		/// </param>
		public OrdersRepository(
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

		/// <inheritdoc/>>
		protected override string KeyColumnName
		{
			get
			{
				return "OrderID";
			}
		}

		/// <inheritdoc/>>
		protected override string TableName
		{
			get
			{
				return "Orders";
			}
		}
	}
}
