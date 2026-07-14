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
	public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : IEntityBase
	{
		/// <summary>
		/// Instantiates a new instance of the RepositoryBase class with the specified logger factory and data store context.
		/// </summary>
		/// <param name="loggerFactory">
		/// A factory for creating logger instances. This is used for logging information, warnings, and errors.
		/// </param>
		/// <param name="dataStoreContext">
		/// A context that provides access to the data store, including the database connection and other data-related operations.
		/// </param>
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
		/// Gets a list of the column names for the entity key.
		/// This property is used to construct SQL queries for deleting, getting, and updating records in the database.
		/// </summary>
		protected abstract string KeyColumnName { get; }

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

		/// <inheritdoc/>>
		public async Task<bool> DeleteAsync(int id)
		{
			if (id <= 0)
			{
				throw new ArgumentException($"The supplied id ({id} is invalid ({this.GetType().Name})");
			}

			// Construct the SQL query to delete the record from the table.
			var query = $"DELETE FROM {this.TableName} WHERE {this.KeyColumnName} = @Id";

			// Open a database connection.
			using (var connection = this.DataStoreContext.DbConnection)
			{
				// Execute the query asynchronously and retrieve the result.
				var result = await connection.ExecuteAsync(query, new { Id = id });

				// Return true if at least one record was affected; otherwise, return false.
				return result > 0;
			}
		}

		/// <inheritdoc/>>
		public async Task<IEnumerable<TEntity>?> GetAllAsync()
		{
			// Construct the SQL query to select all records from the table.
			var query = $"SELECT * FROM {this.TableName}";

			// Open a database connection.
			using (var connection = this.DataStoreContext.DbConnection)
			{
				// Execute the query asynchronously and retrieve the results.
				var result = await connection.QueryAsync<TEntity>(query);

				// Return the retrieved entities.
				return result;
			}
		}

		/// <inheritdoc/>>
		public async Task<TEntity?> GetAsync(int id)
		{
			if (id <= 0)
			{
				throw new ArgumentException($"The supplied id ({id} is invalid ({this.GetType().Name})");
			}

			// Construct the SQL query to select a record by its ID from the table.
			var query = $"SELECT * FROM {this.TableName} WHERE {this.KeyColumnName} = @Id";

			// Open a database connection.
			using (var connection = this.DataStoreContext.DbConnection)
			{
				// Execute the query asynchronously and retrieve the result.
				var result = await connection.QuerySingleOrDefaultAsync<TEntity>(query, new { Id = id });

				// Return the retrieved entity (or null if not found).
				return result;
			}
		}

		/// <inheritdoc/>>
		public async Task<int> InsertAsync(TEntity model)
		{
			if (model == null)
			{
				throw new ArgumentException($"Invalid argument: {nameof(model)} ({this.GetType().Name})");
			}

			if (this.KeyColumnName.Contains(","))
			{
				throw new InvalidOperationException($"This method should not be used for multi-key tables ({this.GetType().Name})");
			}

			// Construct the SQL query to insert a new record into the table.
			var insertableColumns = this.ColumnNames
				.Where(w => !w.Equals(this.KeyColumnName))
				.ToList();

			var query = $"INSERT INTO {this.TableName} ({string.Join(',', insertableColumns)}) VALUES (@{string.Join(", @", insertableColumns)});";

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

		/// <inheritdoc/>>
		public async Task<IEnumerable<TEntity>?> QueryAsync(string query, object? parameters = null)
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				throw new ArgumentException($"Invalid argument: {nameof(query)} ({this.GetType().Name})");
			}

			try
			{
				var result = this.DataStoreContext.DbConnection.Query<TEntity>(query, parameters).ToList();
				return result;
			}
			catch (Exception ex)
			{
				this.Logger.LogError(ex, nameof(this.QueryAsync));
				return new List<TEntity>();
			}
		}

		/// <inheritdoc/>>
		public async Task<TEntity?> QueryFirstAsync(string query, object? parameters = null)
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				throw new ArgumentException($"Invalid argument: {nameof(query)} ({this.GetType().Name})");
			}

			try
			{
				var result = this.DataStoreContext.DbConnection.QueryFirst<TEntity>(query, parameters);
				return result;
			}
			catch (Exception ex)
			{
				this.Logger.LogError(ex, nameof(this.QueryAsync));
				return default(TEntity);
			}
		}

		/// <inheritdoc/>>
		public async Task<TEntity?> QuerySingleAsync(string query, object? parameters = null)
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				throw new ArgumentException($"Invalid argument: {nameof(query)} ({this.GetType().Name})");
			}

			try
			{
				var result = this.DataStoreContext.DbConnection.QuerySingle<TEntity>(query, parameters);
				return result;
			}
			catch (Exception ex)
			{
				this.Logger.LogError(ex, nameof(this.QueryAsync));
				return default(TEntity);
			}
		}

		/// <inheritdoc/>>
		public async Task<bool> UpdateAsync(TEntity model)
		{
			if (model == null)
			{
				throw new ArgumentException($"Invalid argument: {nameof(model)} ({this.GetType().Name})");
			}

			if (this.KeyColumnName.Contains(","))
			{
				throw new InvalidOperationException($"This method should not be used for multi-key tables ({this.GetType().Name})");
			}

			// Generate SET clause for the SQL query based on column names.
			var setValues = this.ColumnNames.Select(prop => $"{prop} = @{prop}");

			// Construct the SQL query to update the record in the table.
			var query = $"UPDATE {this.TableName} SET {string.Join(", ", setValues)} WHERE {this.KeyColumnName} = @{this.KeyColumnName}";

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
