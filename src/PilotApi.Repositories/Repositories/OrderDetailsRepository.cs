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
	/// A repository for accessing and manipulating order details data in the data store.
	/// </summary>
	public class OrderDetailsRepository : RepositoryBase<OrderDetailsEntity>, IOrderDetailsRepository
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
		/// <param name="sqlBuilder">
		/// A SQL builder object.
		/// </param>
		/// <remarks>
		/// The source table contains a two-column key: ProductID, OrderID.
		/// The KeyColumnNames property lists the two columns in that order.
		/// So, the GetById and Delete methods must handle IDs in that order.
		/// </remarks>
		public OrderDetailsRepository(
			ILoggerFactory loggerFactory,
			IDataSourceContext dataStoreContext,
			ISqlBuilder sqlBuilder)
			: base(loggerFactory, dataStoreContext, sqlBuilder)
		{
			this.KeyIsAutoIncrement = false;
		}

		/// <inheritdoc/>
		protected override List<string> ColumnNames
		{
			get
			{
				return new List<string>
				{
					"[Discount]",
					"[OrderID]",
					"[ProductID]",
					"[Quantity]",
					"[UnitPrice]"
				};
			}
		}

		/// <inheritdoc/>
		protected override List<string> KeyColumnNames
		{
			get
			{
				return new List<string>
				{
					"[ProductID]",
					"[OrderID]"
				};
			}
		}

		/// <inheritdoc/>
		protected override string TableName
		{
			get
			{
				return "[dbo].[Order Details]";
			}
		}
	}
}
