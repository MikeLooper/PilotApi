using Microsoft.AspNetCore.DataProtection.KeyManagement;
using PilotApi.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace PilotApi.Shared.Handlers
{
	/// <summary>
	/// A handler for SQL building operations.
	/// </summary>
	public class SqlBuilder : ISqlBuilder
	{
		/// <inheritdoc/>>
		public string BuildCount(string tableName)
		{
			if (string.IsNullOrWhiteSpace(tableName))
			{
				throw new ArgumentException(
					$"The {nameof(tableName)} argument cannot be null or empty ({this.GetType().Name})");
			}

			var returnClause = new StringBuilder("SELECT COUNT(*) FROM ");
			returnClause.Append(tableName);

			return returnClause.ToString();
		}

		/// <inheritdoc/>>
		public string BuildDelete(string tableName, List<string> keyColumnNames)
		{
			if (string.IsNullOrWhiteSpace(tableName))
			{
				throw new ArgumentException(
					$"The {nameof(tableName)} argument cannot be null or empty ({this.GetType().Name})");
			}

			if (keyColumnNames == null ||
				keyColumnNames.Count == 0)
			{
				throw new ArgumentException(
					$"The {nameof(keyColumnNames)} argument cannot be null or empty ({this.GetType().Name})");
			}

			var returnClause = new StringBuilder("DELETE FROM ");
			returnClause.Append(tableName);

			returnClause.Append(" ");

			var whereClause = this.BuildWhereClause(keyColumnNames);
			returnClause.Append(whereClause);

			return returnClause.ToString();
		}

		/// <inheritdoc/>>
		public string BuildInsert(
			string tableName, 
			List<string> columnNames, 
			List<string> keyColumnNames,
			DataSources dataSourceType,
			bool keyIsAutoIncrement = true)
		{
			if (string.IsNullOrWhiteSpace(tableName))
			{
				throw new ArgumentException(
					$"The {nameof(tableName)} argument cannot be null or empty ({this.GetType().Name})");
			}

			if (columnNames == null ||
				columnNames.Count == 0)
			{
				throw new ArgumentException(
					$"The {nameof(columnNames)} argument cannot be null or empty ({this.GetType().Name})");
			}

			if (keyColumnNames == null ||
				keyColumnNames.Count == 0)
			{
				throw new ArgumentException(
					$"The {nameof(keyColumnNames)} argument cannot be null or empty ({this.GetType().Name})");
			}

			var returnClause = new StringBuilder("INSERT INTO ");
			returnClause.Append(tableName);
			returnClause.Append(" (");

			var columnsString = new StringBuilder();
			foreach (var columnName in columnNames)
			{
				if (keyIsAutoIncrement && keyColumnNames.Contains(columnName))
				{
					// don't include key columns in update set, when autoincrement is active
					continue;
				}

				if (columnsString.Length > 0)
				{
					columnsString.Append(",");
				}

				columnsString.Append(columnName);
			}

			returnClause.Append(columnsString);
			returnClause.Append(") VALUES (");

			columnsString.Clear();
			foreach (var columnName in columnNames)
			{
				if (keyIsAutoIncrement && keyColumnNames.Contains(columnName))
				{
					// don't include key columns in values, when autoincrement is active
					continue;
				}

				if (columnsString.Length > 0)
				{
					columnsString.Append(",");
				}

				var simpleColumn = columnName.Replace("[", "").Replace("]", "");
				columnsString.Append($"@{simpleColumn}");
			}

			returnClause.Append(columnsString);
			returnClause.Append(") ");

			if (dataSourceType == DataSources.SqlServer)
			{
				if (keyColumnNames.Count == 1 && keyIsAutoIncrement)
				{
					// Use SCOPE_IDENTITY() in SQL Server to retrieve the latest generated identity value.
					// This is used to get the auto-incremented identity value after an INSERT operation.
					returnClause.Append("; SELECT CAST(SCOPE_IDENTITY() as int);");
				}
				else
				{
					// composite key - cannot return newly created composite ids: so, return a zero.
					// If you need the details about the new row, execute this:
					//	string sql = "INSERT INTO [dbo].[Order Details] ([Discount],[OrderID],[ProductID],[Quantity],[UnitPrice]) " +
					//			 "OUTPUT INSERTED.* " +
					//			 "VALUES (@Discount,@OrderID,@ProductID,@Quantity,@UnitPrice);";

					//	// Returns the full populated OrderDetailsEntity
					//	var result = await connection.QueryFirstOrDefaultAsync<OrderDetailsEntity>(sql, orderDetailsEntity);
					returnClause.Append("; SELECT 1 as id;");
				}
			}

			return returnClause.ToString();
		}

		/// <inheritdoc/>>
		public string BuildSelect(string tableName, List<string> columnNames, List<string>? keyColumnNames = null)
		{
			if (string.IsNullOrWhiteSpace(tableName))
			{
				throw new ArgumentException(
					$"The {nameof(tableName)} argument cannot be null or empty ({this.GetType().Name})");
			}

			if (columnNames == null ||
				columnNames.Count == 0)
			{
				throw new ArgumentException(
					$"The {nameof(columnNames)} argument cannot be null or empty ({this.GetType().Name})");
			}

			var returnClause = new StringBuilder("SELECT ");
			foreach (var columnName in columnNames)
			{
				if (returnClause.Length > 7)
				{
					returnClause.Append(",");
				}

				returnClause.Append(columnName);
			}

			returnClause.Append(" FROM ");
			returnClause.Append(tableName);

			if (keyColumnNames != null && 
				keyColumnNames.Count > 0)
			{
				returnClause.Append(" ");

				var whereClause = this.BuildWhereClause(keyColumnNames);
				returnClause.Append(whereClause);
			}

			return returnClause.ToString();
		}

		/// <inheritdoc/>>
		public string BuildUpdate(
			string tableName, 
			List<string> columnNames, 
			List<string> keyColumnNames,
			bool keyIsAutoIncrement = true)
		{
			if (string.IsNullOrWhiteSpace(tableName))
			{
				throw new ArgumentException(
					$"The {nameof(tableName)} argument cannot be null or empty ({this.GetType().Name})");
			}

			if (columnNames == null ||
				columnNames.Count == 0)
			{
				throw new ArgumentException(
					$"The {nameof(columnNames)} argument cannot be null or empty ({this.GetType().Name})");
			}

			if (keyColumnNames == null ||
				keyColumnNames.Count == 0)
			{
				throw new ArgumentException(
					$"The {nameof(keyColumnNames)} argument cannot be null or empty ({this.GetType().Name})");
			}

			var returnClause = new StringBuilder("UPDATE ");
			returnClause.Append(tableName);
			returnClause.Append(" SET ");

			var setString = new StringBuilder();
			foreach (var columnName in columnNames)
			{
				if (keyIsAutoIncrement && keyColumnNames.Contains(columnName))
				{
					// don't include key columns in update set, when autoincrement is active
					continue;
				}

				if (setString.Length > 0)
				{
					setString.Append(",");
				}

				var simpleColumn = columnName.Replace("[", "").Replace("]", "");
				setString.Append($"{columnName} = @{simpleColumn}");
			}

			returnClause.Append(setString);
			returnClause.Append(" ");

			var whereClause = this.BuildWhereClause(keyColumnNames);
			returnClause.Append(whereClause);

			return returnClause.ToString();
		}

		/// <inheritdoc/>>
		public string BuildWhereClause(List<string> keyColumnNames)
		{
			if (keyColumnNames == null ||
				keyColumnNames.Count == 0)
			{
				throw new ArgumentException(
					$"The {nameof(keyColumnNames)} argument cannot be null or empty ({this.GetType().Name})");
			}

			var returnClause = new StringBuilder("WHERE ");
			foreach (var key in keyColumnNames)
			{
				if (returnClause.Length > 6)
				{
					returnClause.Append(" AND ");
				}

				var simpleKey = key.Replace("[", "").Replace("]", "");
				returnClause.Append($"{key} = @{simpleKey}");
			}

			return returnClause.ToString();
		}
	}
}
