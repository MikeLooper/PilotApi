using Dapper;
using Microsoft.Extensions.Logging;
using PilotApi.Domain.Contracts.Base;
using PilotApi.Domain.Contracts.DataStore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PilotApi.Repositories.Base
{
	public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : IEntityBase
	{
		protected RepositoryBase(
			ILoggerFactory loggerFactory,
			IDataStoreContext dataStoreContext)
		{
			this.Logger = loggerFactory.CreateLogger(GetType());
			this.DataStoreContext = dataStoreContext;
		}

		/// <summary>
		/// Gets a list of the column names for the entity. 
		/// This property is used to construct SQL queries for inserting and updating records in the database.
		/// </summary>
		protected abstract List<string> ColumnNames { get; }

		/// <summary>
		/// Gets the logger instance for logging information, warnings, and errors.
		/// </summary>
		protected ILogger Logger { get; }

		/// <summary>
		/// Gets the name of the database table associated with the entity.
		/// </summary>
		protected abstract string TableName { get; }

		/// <summary>
		/// Gets the data store context, which provides access to the database connection and other data-related operations.
		/// </summary>
		private IDataStoreContext DataStoreContext { get; }

		public async Task<bool> DeleteAsync(int id)
		{
			// Construct the SQL query to delete the record from the table.
			var query = $"DELETE FROM {this.TableName} WHERE id = @Id";

			// Open a database connection.
			using (var connection = this.DataStoreContext.DbConnection)
			{
				// Execute the query asynchronously and retrieve the result.
				var result = await connection.ExecuteAsync(query, new { Id = id });

				// Return true if at least one record was affected; otherwise, return false.
				return result > 0;
			}
		}

		public async Task<IEnumerable<T>?> GetAllAsync()
		{
			// Construct the SQL query to select all records from the table.
			var query = $"SELECT * FROM {this.TableName}";

			// Open a database connection.
			using (var connection = this.DataStoreContext.DbConnection)
			{
				// Execute the query asynchronously and retrieve the results.
				var result = await connection.QueryAsync<T>(query);

				// Return the retrieved entities.
				return result;
			}
		}

		public async Task<T?> GetAsync(int id)
		{
			// Construct the SQL query to select a record by its ID from the table.
			var query = $"SELECT * FROM {this.TableName} WHERE id = @Id";

			// Open a database connection.
			using (var connection = this.DataStoreContext.DbConnection)
			{
				// Execute the query asynchronously and retrieve the result.
				var result = await connection.QuerySingleOrDefaultAsync<T>(query, new { Id = id });

				// Return the retrieved entity (or null if not found).
				return result;
			}
		}

		public async Task<int> InsertAsync(T model)
		{
			if (model == null)
			{
				throw new ArgumentException($"Invalid argument: {nameof(model)}");
			}

			// Construct the SQL query to insert a new record into the table.
			var query = $"INSERT INTO {this.TableName} ({string.Join(',', this.ColumnNames)}) VALUES (@{string.Join(", @", this.ColumnNames)});";

			if (this.DataStoreContext.DataConnection.DatabaseType == "SqlServer")
			{
				// Use SCOPE_IDENTITY() in SQL Server to retrieve the latest generated identity value.
				// This is used to get the auto-incremented identity value after an INSERT operation.
				query += "SELECT CAST(SCOPE_IDENTITY() as int);";
			}

			// Open a database connection.
			using (var connection = this.DataStoreContext.DbConnection)
			{
				// Execute the query asynchronously and retrieve the inserted ID.
				var id = await connection.QueryFirstOrDefaultAsync<int>(query, model);

				// Return the inserted ID.
				return id;
			}
		}

		public async Task<IEnumerable<T>?> QueryAsync(string query, object? parameters = null)
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				throw new ArgumentException($"Invalid argument: {nameof(query)}");
			}

			try
			{
				var result = this.DataStoreContext.DbConnection.Query<T>(query, parameters).ToList();
				return result;
			}
			catch (Exception ex)
			{
				this.Logger.LogError(ex, nameof(this.QueryAsync));
				return new List<T>();
			}
		}

		public async Task<T?> QueryFirstAsync(string query, object? parameters = null)
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				throw new ArgumentException($"Invalid argument: {nameof(query)}");
			}

			try
			{
				var result = this.DataStoreContext.DbConnection.QueryFirst<T>(query, parameters);
				return result;
			}
			catch (Exception ex)
			{
				this.Logger.LogError(ex, nameof(this.QueryAsync));
				return default(T);
			}
		}

		public async Task<T?> QuerySingleAsync(string query, object? parameters = null)
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				throw new ArgumentException($"Invalid argument: {nameof(query)}");
			}

			try
			{
				var result = this.DataStoreContext.DbConnection.QuerySingle<T>(query, parameters);
				return result;
			}
			catch (Exception ex)
			{
				this.Logger.LogError(ex, nameof(this.QueryAsync));
				return default(T);
			}
		}

		public async Task<bool> UpdateAsync(T model)
		{
			if (model == null)
			{
				throw new ArgumentException($"Invalid argument: {nameof(model)}");
			}

			// Generate SET clause for the SQL query based on column names.
			var setValues = this.ColumnNames.Select(prop => $"{prop} = @{prop}");

			// Construct the SQL query to update the record in the table.
			var query = $"UPDATE {this.TableName} SET {string.Join(", ", setValues)} WHERE id = @Id";

			// Open a database connection.
			using (var connection = this.DataStoreContext.DbConnection)
			{
				// Execute the query asynchronously and retrieve the result.
				var result = await connection.ExecuteAsync(query, model);

				// Return true if at least one record was affected; otherwise, return false.
				return result > 0;
			}
		}
	}
}
