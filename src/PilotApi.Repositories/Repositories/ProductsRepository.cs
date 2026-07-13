using Microsoft.Extensions.Logging;
using PilotApi.Domain.Contracts.DataStore;
using PilotApi.Domain.Contracts.Entities;
using PilotApi.Domain.Contracts.Repository;
using PilotApi.Repositories.Base;
using System.Collections.Generic;

namespace PilotApi.Repositories.Repositories
{
	public class ProductsRepository : RepositoryBase<IProductsEntity>, IProductsRepository
	{
		public ProductsRepository(
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
					"ProductID",
					"ProductName",
					"SupplierID",
					"CategoryID",
					"QuantityPerUnit",
					"UnitPrice",
					"UnitsInStock",
					"UnitsOnOrder",
					"ReorderLevel",
					"Discontinued"
				};
			}
		}

		protected override string TableName
		{
			get
			{
				return "Products";
			}
		}
	}
}
