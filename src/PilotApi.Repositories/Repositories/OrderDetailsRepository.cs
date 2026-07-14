using Microsoft.Extensions.Logging;
using PilotApi.Domain.Contracts.DataStore;
using PilotApi.Domain.Contracts.Entities;
using PilotApi.Domain.Contracts.Repository;
using PilotApi.Repositories.Base;
using System.Collections.Generic;

namespace PilotApi.Repositories.Repositories
{
	/// <summary>
	/// A repository for accessing and manipulating order details data in the data store.
	/// </summary>
	public class OrderDetailsRepository : RepositoryBase<IOrderDetailsEntity>, IOrderDetailsRepository
	{
		/// <summary>
		/// Instantiates a new instance of the <see cref="OrderDetailsRepository"/> class.
		/// </summary>
		/// <param name="loggerFactory">
		/// A logger factory used to create loggers for logging information, warnings, and errors.
		/// </param>
		/// <param name="dataStoreContext">
		/// A data store context that provides access to the underlying data store for performing CRUD operations.
		/// </param>
		public OrderDetailsRepository(
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
					"ProductID",
					"UnitPrice",
					"Quantity",
					"Discount"
				};
			}
		}

		/// <inheritdoc/>>
		protected override string KeyColumnName
		{
			get
			{
				return "OrderID, ProductID";
			}
		}

		/// <inheritdoc/>>
		protected override string TableName
		{
			get
			{
				return "OrderDetails";
			}
		}
	}
}
