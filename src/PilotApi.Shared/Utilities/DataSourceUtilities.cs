using PilotApi.Shared.Constants;
using System.Collections.Generic;

namespace PilotApi.Shared.Utilities
{
	/// <summary>
	/// Utility methods used for working with data sources.
	/// </summary>
	public static class DataSourceUtilities
	{
		/// <summary>
		/// Return the available <see cref="DataSources"/> items, as a comma-separated-list.
		/// </summary>
		/// <returns>
		///  A comma-sepataed-list.
		/// </returns>
		public static string GetAvailableDataSourcesList()
		{
			var availableReturn = new List<string>
			{
				DataSources.PostgreSQL.ToString(),
				DataSources.SqlServer.ToString()
			};

			return string.Join(",", availableReturn);
		}

		/// <summary>
		/// Resolve a <see cref="DataSources"/> option, based upon the supplied data source type.	
		/// </summary>
		/// <param name="dataSourceType">
		/// A string representation of a data source type.
		/// </param>
		/// <returns>
		/// A <see cref="DataSources"/> option.
		/// </returns>
		public static DataSources ResolveDataSources(string dataSourceType)
		{
			var returnDataSources = DataSources.Unrecognized;
			if (dataSourceType.Equals("PostgreSQL", System.StringComparison.InvariantCultureIgnoreCase))
			{
				returnDataSources = DataSources.PostgreSQL;
			}
			else if (dataSourceType.Equals("SqlServer", System.StringComparison.InvariantCultureIgnoreCase))
			{
				returnDataSources = DataSources.SqlServer;
			}

			return returnDataSources;
		}
	}
}
