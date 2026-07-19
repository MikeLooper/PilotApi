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
	/// A repository for accessing and manipulating order data in the data store.
	/// </summary>
	public class OrdersRepository : RepositoryBase<OrdersEntity>, IOrdersRepository
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
		/// <param name="sqlBuilder">
		/// A SQL builder object.
		/// </param>
		public OrdersRepository(
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
					"[CustomerID]",
					"[EmployeeID]",
					"[Freight]",
					"[OrderDate]",
					"[OrderID]",
					"[RequiredDate]",
					"[ShipAddress]",
					"[ShipCity]",
					"[ShipCountry]",
					"[ShipName]",
					"[ShippedDate]",
					"[ShipPostalCode]",
					"[ShipRegion]",
					"[ShipVia]"
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
					"[OrderID]"
				};
			}
		}

		/// <inheritdoc/>>
		protected override string TableName
		{
			get
			{
				return "[dbo].[Orders]";
			}
		}
	}
}
