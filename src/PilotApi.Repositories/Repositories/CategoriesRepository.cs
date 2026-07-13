using Microsoft.Extensions.Logging;
using PilotApi.Domain.Contracts.DataStore;
using PilotApi.Domain.Contracts.Entities;
using PilotApi.Domain.Contracts.Repository;
using PilotApi.Repositories.Base;
using System.Collections.Generic;

namespace PilotApi.Repositories.Repositories
{
	public class CategoriesRepository : RepositoryBase<ICategoriesEntity>, ICategoriesRepository
	{
		public CategoriesRepository(
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
					"CategoryID",
					"CategoryName",
					"Description",
					"Picture"
				};
			}
		}

		protected override string TableName
		{
			get
			{
				return "Categories";
			}
		}
	}
}
