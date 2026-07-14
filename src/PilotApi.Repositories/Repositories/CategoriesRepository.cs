using Microsoft.Extensions.Logging;
using PilotApi.Domain.Contracts.DataStore;
using PilotApi.Domain.Contracts.Entities;
using PilotApi.Domain.Contracts.Repository;
using PilotApi.Repositories.Base;
using System.Collections.Generic;

namespace PilotApi.Repositories.Repositories
{
	/// <summary>
	/// A repository for accessing and manipulating category data in the data store.
	/// </summary>
	public class CategoriesRepository : RepositoryBase<ICategoriesEntity>, ICategoriesRepository
	{
		/// <summary>
		/// Instantiates a new instance of the <see cref="CategoriesRepository"/> class.
		/// </summary>
		/// <param name="loggerFactory"></param>
		/// <param name="dataStoreContext"></param>
		public CategoriesRepository(
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
					"CategoryID",
					"CategoryName",
					"Description",
					"Picture"
				};
			}
		}

		/// <inheritdoc/>>
		protected override string KeyColumnName
		{
			get
			{
				return "CategoryID";
			}
		}

		/// <inheritdoc/>>
		protected override string TableName
		{
			get
			{
				return "Categories";
			}
		}
	}
}
