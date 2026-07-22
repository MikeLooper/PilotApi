using PilotApi.Shared.Constants;
using System;
using System.Collections.Generic;

namespace PilotApi.Shared.Utilities
{
	/// <summary>
	/// Utility methods used for working with data sources.
	/// </summary>
	public static class DataSourceUtilities
	{
		/// <summary>
		/// Return the supplied schema/table/column name after it has been surrounded by delimiters (e.g. [, ], "), if not already present.
		/// </summary>
		/// <param name="sourceName">
		/// The source name.
		/// </param>
		/// <param name="datasourceType">
		/// A <see cref="DataSourceTypes"/> value, to indicate the currernt type of data source.
		/// </param>
		/// <returns>
		///  A delmited name.
		/// </returns>
		public static string DelimitName(string sourceName, DataSourceTypes datasourceType)
		{
			if (string.IsNullOrWhiteSpace(sourceName))
			{
				throw new ArgumentException($"Invalid argument: {nameof(sourceName)} ({nameof(DataSourceUtilities)})");
			}

			if (datasourceType == DataSourceTypes.Unrecognized)
			{
				throw new ArgumentException($"Invalid argument: {nameof(datasourceType)} ({nameof(DataSourceUtilities)})");
			}

			if (!string.IsNullOrWhiteSpace(sourceName))
			{
				switch (datasourceType)
				{
					case DataSourceTypes.SqlServer:
						if (!sourceName.StartsWith("["))
						{
							sourceName = $"[{sourceName}";
						}

						if (!sourceName.EndsWith("]"))
						{
							sourceName = $"{sourceName}]";
						}

						break;
					case DataSourceTypes.PostgreSQL:
						if (!sourceName.StartsWith("\""))
						{
							sourceName = $"\"{sourceName}";
						}

						if (!sourceName.EndsWith("\""))
						{
							sourceName = $"{sourceName}\"";
						}

						break;
					default:
						throw new InvalidOperationException($"Unhandled data source type: '{datasourceType}' ({nameof(DataSourceUtilities)})");
				}
			}

			return sourceName;
		}

		/// <summary>
		/// Return the supplied schema/table/column list after each column has been surrounded by delimiters (e.g. [, ], "), where not already present.
		/// </summary>
		/// <param name="sourceNames">
		/// A source list of names.
		/// </param>
		/// <param name="datasourceType">
		/// A <see cref="DataSourceTypes"/> value, to indicate the currernt type of data source.
		/// </param>
		/// <returns>
		///  A delimited list.
		/// </returns>
		public static List<string> DelimitNames(List<string> sourceNames, DataSourceTypes datasourceType)
		{
			if (sourceNames == null)
			{
				throw new ArgumentException($"Invalid argument: {nameof(sourceNames)} ({nameof(DataSourceUtilities)})");
			}

			if (datasourceType == DataSourceTypes.Unrecognized)
			{
				throw new ArgumentException($"Invalid argument: {nameof(datasourceType)} ({nameof(DataSourceUtilities)})");
			}

			List<string> cleanedList = new List<string>();

			if (sourceNames.Count > 0)
			{
				foreach (var column in sourceNames)
				{
					cleanedList.Add(DelimitName(column, datasourceType));
				}
			}

			return cleanedList;
		}

		/// <summary>
		/// Return the available <see cref="DataSourceTypes"/> items, as a comma-separated-list.
		/// </summary>
		/// <returns>
		///  A comma-separataed-list.
		/// </returns>
		public static string GetAvailableDataSourcesList()
		{
			var availableReturn = new List<string>
			{
				DataSourceTypes.PostgreSQL.ToString(),
				DataSourceTypes.SqlServer.ToString()
			};

			return string.Join(",", availableReturn);
		}

		/// <summary>
		/// Return the supplied schema/table/column name after it has been cleaned of surrounding delimiters (e.g. [, ], ").
		/// </summary>
		/// <param name="sourceName">
		/// The source name.
		/// </param>
		/// <returns>
		///  A cleaned name.
		/// </returns>
		public static string MinimizeName(string sourceName)
		{
			if (string.IsNullOrWhiteSpace(sourceName))
			{
				throw new ArgumentException($"Invalid argument: {nameof(sourceName)} ({nameof(DataSourceUtilities)})");
			}

			if (!string.IsNullOrWhiteSpace(sourceName))
			{
				sourceName = sourceName
					.Replace("[", "")
					.Replace("]", "")
					.Replace("\"", "");
			}

			return sourceName;
		}

		/// <summary>
		/// Return the supplied schema/table/column list after each column has been cleaned of surrounding delimiters (e.g. [, ], ").
		/// </summary>
		/// <param name="sourceColumns">
		/// A source list of names.
		/// </param>
		/// <returns>
		///  A cleaned list.
		/// </returns>
		public static List<string> MinimizeNames(List<string> sourceColumns)
		{
			if (sourceColumns == null)
			{
				throw new ArgumentException($"Invalid argument: {nameof(sourceColumns)} ({nameof(DataSourceUtilities)})");
			}

			List<string> cleanedList = new List<string>();

			if (sourceColumns.Count > 0)
			{
				foreach (var column in sourceColumns)
				{
					cleanedList.Add(MinimizeName(column));
				}
			}

			return cleanedList;
		}

		/// <summary>
		/// Resolve a <see cref="DataSourceTypes"/> option, based upon the supplied data source type.	
		/// </summary>
		/// <param name="dataSourceType">
		/// A string representation of a data source type.
		/// </param>
		/// <returns>
		/// A <see cref="DataSourceTypes"/> option.
		/// </returns>
		public static DataSourceTypes ResolveDataSources(string dataSourceType)
		{
			if (string.IsNullOrWhiteSpace(dataSourceType))
			{
				throw new ArgumentException($"Invalid argument: {nameof(dataSourceType)} ({nameof(DataSourceUtilities)})");
			}

			var returnDataSources = DataSourceTypes.Unrecognized;
			if (dataSourceType.Equals("PostgreSQL", System.StringComparison.OrdinalIgnoreCase))
			{
				returnDataSources = DataSourceTypes.PostgreSQL;
			}
			else if (dataSourceType.Equals("SqlServer", System.StringComparison.OrdinalIgnoreCase))
			{
				returnDataSources = DataSourceTypes.SqlServer;
			}

			return returnDataSources;
		}
	}
}
