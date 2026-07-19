using PilotApi.Shared.Constants;
using System.Collections.Generic;

namespace PilotApi.Shared.Handlers
{
	/// <summary>
	/// An interface for the handler for SQL building operations.
	/// </summary>
	public interface ISqlBuilder
	{
		/// <summary>
		/// Build and return a Count(*) string.
		/// </summary>
		/// <param name="tableName">
		/// The name of the current table.
		/// </param>
		/// <returns>
		/// A COUNT string.
		/// </returns>
		string BuildCount(string tableName);

		/// <summary>
		/// Build and return a DELETE string, based upon the supplied table name and key columns property.
		/// The key columns will be included in the WHERE clasue of the DELETE string as parameter substitutions in order of the keyColumnNames list.
		/// </summary>
		/// <param name="tableName">
		/// The name of the current table.
		/// </param>
		/// <param name="keyColumnNames">
		/// A list of the column names for the source entity key(s).
		/// </param>
		/// <returns>
		/// A DELETE string.
		/// </returns>
		string BuildDelete(string tableName, List<string> keyColumnNames);

		/// <summary>
		/// Build and return an INSERT string.
		/// </summary>
		/// <param name="tableName">
		/// The name of the current table.
		/// </param>
		/// <param name="columnNames">
		/// A list of the column names for the source entity.
		/// </param>
		/// <param name="keyColumnNames">
		/// A list of the column names for the source entity key(s), to be used in the WHERE clause.
		/// </param>
		/// <param name="dataSourceType">
		/// The data of data source in use.
		/// </param>
		/// <param name="keyIsAutoIncrement">
		/// A flag that indicates whether the key in the supplied table will auto-increment during insert.
		/// Default = True.
		/// </param>
		/// <returns>
		/// An INSERT string.
		/// </returns>
		string BuildInsert(
			string tableName, 
			List<string> columnNames, 
			List<string> keyColumnNames,
			DataSources dataSourceType,
			bool keyIsAutoIncrement = true);

		/// <summary>
		/// Build and return a SELECT string.
		/// </summary>
		/// <param name="tableName">
		/// The name of the current table.
		/// </param>
		/// <param name="columnNames">
		/// A list of the column names for the source entity.
		/// </param>
		/// <param name="keyColumnNames">
		/// A list of the column names for the source entity key(s), to be used in the WHERE clause.
		/// If this list is null or empty, no WHERE clause will be included.
		/// Default = Null.
		/// </param>
		/// <returns>
		/// A SELECT string.
		/// </returns>
		string BuildSelect(string tableName, List<string> columnNames, List<string>? keyColumnNames = null);

		/// <summary>
		/// Build and return an UPDATE string.
		/// </summary>
		/// <param name="tableName">
		/// The name of the current table.
		/// </param>
		/// <param name="columnNames">
		/// A list of the column names for the source entity.
		/// </param>
		/// <param name="keyColumnNames">
		/// A list of the column names for the source entity key(s), to be used in the WHERE clause.
		/// </param>
		/// <param name="keyIsAutoIncrement">
		/// A flag that indicates whether the key in the supplied table will auto-increment during insert.
		/// Default = True.
		/// </param>
		/// <returns>
		/// An UPDATE string.
		/// </returns>
		string BuildUpdate(
			string tableName, 
			List<string> columnNames,
			List<string> keyColumnNames,
			bool keyIsAutoIncrement = true);

		/// <summary>
		/// Build and return a WHERE clause, based upon the supplied key columns property.
		/// The key columns will be included in the where string as parameter substitutions in order of the keyColumnNames list.
		/// </summary>
		/// <param name="keyColumnNames">
		/// A list of the column names for the source entity key(s).
		/// </param>
		/// <returns>
		/// A WHERE clause string.
		/// </returns>
		string BuildWhereClause(List<string> keyColumnNames);
	}
}
