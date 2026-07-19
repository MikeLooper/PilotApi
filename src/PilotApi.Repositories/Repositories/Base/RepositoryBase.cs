using Dapper;
using Microsoft.Extensions.Logging;
using PilotApi.Domain.Contracts.DataSource;
using PilotApi.Repositories.Contracts.Repository.Base;
using PilotApi.Repositories.Models.Base;
using PilotApi.Shared.Exceptions;
using PilotApi.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PilotApi.Repositories.Repositories.Base
{
	/// <summary>
	/// A base class for repositories.
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
	{
		/// <summary>
		/// Instantiates a new instance of the RepositoryBase class with the specified logger factory and data source context.
		/// </summary>
		/// <param name="loggerFactory">
		/// A factory for creating logger instances. This is used for logging information, warnings, and errors.
		/// </param>
		/// <param name="dataStoreContext">
		/// A context that provides access to the data source, including the data source connection and other data-related operations.
		/// </param>
		/// <param name="sqlBuilder">
		/// A SQL builder object.
		/// </param>
		protected RepositoryBase(
			ILoggerFactory loggerFactory,
			IDataSourceContext dataStoreContext,
			ISqlBuilder sqlBuilder)
		{
			this.Logger = loggerFactory.CreateLogger(GetType());
			this.DataSourceContext = dataStoreContext;
			this.SqlBuilder = sqlBuilder;
		}

		/// <summary>
		/// Gets a list of the column names for the entity. 
		/// This property is used to construct SQL queries for inserting and updating records in the data source.
		/// </summary>
		protected abstract List<string> ColumnNames { get; }

		/// <summary>
		/// Gets the data source context, which provides access to the data source connection and other data-related operations.
		/// </summary>
		protected IDataSourceContext DataSourceContext { get; }

		/// <summary>
		/// Gets a list of the column names for the entity key(s).
		/// This property is used to construct SQL queries for deleting, getting, and updating records in the data source.
		/// If the current table uses more than one key column, this value should be a comma-separated-list of columns.
		/// </summary>
		protected abstract List<string> KeyColumnNames { get; }

		/// <summary>
		/// A flag that indicates whether the key in this table will auto-increment during insert.
		/// Default = True.
		/// </summary>
		protected bool KeyIsAutoIncrement { get; set; } = true;

		/// <summary>
		/// Gets the logger instance for logging information, warnings, and errors.
		/// </summary>
		protected ILogger Logger { get; }

		/// <summary>
		/// Gets a SQL builder object.
		/// </summary>
		protected ISqlBuilder SqlBuilder { get; }

		/// <summary>
		/// Gets the name of the data source table associated with the entity.
		/// </summary>
		protected abstract string TableName { get; }

		/// <summary>
		/// A flag that indicates whether this object has been validated.
		/// Default = False.
		/// </summary>
		protected bool WasValidated { get; set; }

		/// <inheritdoc/>>
		public override string ToString()
		{
			return $"{nameof(this.ColumnNames)}={this.ColumnNames}, " +
				$"{nameof(this.KeyColumnNames)}={this.KeyColumnNames}, " +
				$"{nameof(this.TableName)}={this.TableName}, " +
				$"{nameof(this.DataSourceContext)}={this.DataSourceContext}";
		}

		/// <summary>
		/// Build and return a parameter object that would be supplied to a Dapper command, based upon the key columns property.
		/// </summary>
		/// <param name="keyColumnNames">
		/// A list of the column names for the source entity key(s).
		/// </param>
		/// <param name="ids">
		/// A list of Id values, which should be in the same order as the key columns property.
		/// </param>
		/// <returns>
		/// A <see cref="DynamicParameters"/> object.
		/// </returns>
		public DynamicParameters BuildParameters<TType>(List<string> keyColumnNames, params TType[] ids)
		{
			if (keyColumnNames == null ||
				keyColumnNames.Count == 0)
			{
				throw new ArgumentException(
					$"The {nameof(keyColumnNames)} argument cannot be null or empty ({this.GetType().Name})");
			}

			if (keyColumnNames.Count != ids.Length)
			{
				throw new ArgumentException(
					$"The {nameof(keyColumnNames)} argument must have the same number of items as " + 
					$"the {nameof(ids)} argument: {nameof(keyColumnNames)}={keyColumnNames.Count}, {nameof(ids)}={ids.Length} " + 
					$"({this.GetType().Name})");
			}

			var dynamicParameters = new DynamicParameters();

			for (var keyIndex = 0; keyIndex < this.KeyColumnNames.Count; keyIndex++)
			{
				var columnKey = this.KeyColumnNames[keyIndex].Replace("[", "").Replace("]", "");
				var columnValue = ids[keyIndex];

				dynamicParameters.Add(columnKey, columnValue);
			}

			return dynamicParameters;
		}

		/// <inheritdoc/>>
		public virtual async Task<int> CountAllAsync()
		{
			this.Validate();

			// Construct the SQL query to select all records from the table.
			var queryString = this.SqlBuilder.BuildCount(this.TableName);

			// Open a data source connection.
			var connection = this.DataSourceContext.GetConnection();

			int result = -1;
			try
			{
				// Execute the query asynchronously and retrieve the results.
				result = await connection.ExecuteAsync(
					queryString,
					transaction: this.DataSourceContext.DataSourceTransaction);
			}
			catch (Exception exc)
			{
				this.Logger.LogError(exc, nameof(this.GetAllAsync));
				await this.DataSourceContext.Rollback();

				throw;
			}
			finally
			{
				// data source cleanup
				connection.Close();
			}

			// Return the retrieved count.
			return result;
		}

		/// <inheritdoc/>>
		public virtual async Task<bool> DeleteAsync<TType>(params TType[] ids)
		{
			this.Validate();

			if (ids.Length < 1)
			{
				throw new ArgumentException($"The supplied ids list ({ids} must contain at least one item ({this.GetType().Name})");
			}

			if (this.KeyColumnNames.Contains(","))
			{
				throw new InvalidOperationException($"This method should not be used for multi-key tables ({this.GetType().Name})");
			}

			// Construct the SQL query to delete the record from the table.
			var querySql = this.SqlBuilder.BuildDelete(this.TableName, this.KeyColumnNames);
			var queryParameters = this.BuildParameters(this.KeyColumnNames, ids);

			// Open a data source connection.
			var connection = this.DataSourceContext.GetConnection();

			var success = false;
			try
			{
				// Execute the query asynchronously and retrieve the result.
				var result = await connection.ExecuteAsync(
					querySql, 
					queryParameters,
					transaction: this.DataSourceContext.DataSourceTransaction);
				success = result > 0;
				if (success)
				{
					await this.DataSourceContext.Commit();
				}
				else
				{
					await this.DataSourceContext.Rollback();
				}
			}
			catch (Exception exc)
			{
				this.Logger.LogError(exc, nameof(this.DeleteAsync));
				await this.DataSourceContext.Rollback();

				throw;
			}
			finally
			{
				// data source cleanup
				connection.Close();
			}

			// Return true if at least one record was affected; otherwise, return false.
			return success;
		}

		/// <inheritdoc/>>
		public virtual async Task<List<TEntity>?> GetAllAsync()
		{
			this.Validate();

			// Construct the SQL query to select all records from the table.
			var queryString = this.SqlBuilder.BuildSelect(this.TableName, this.ColumnNames);

			// Open a data source connection.
			var connection = this.DataSourceContext.GetConnection();

			IEnumerable<TEntity>? result = null;
			try
			{
				// Execute the query asynchronously and retrieve the results.
				result = await connection.QueryAsync<TEntity>(
					queryString,
					transaction: this.DataSourceContext.DataSourceTransaction);
			}
			catch (Exception exc)
			{
				this.Logger.LogError(exc, nameof(this.GetAllAsync));
				await this.DataSourceContext.Rollback();

				throw;
			}
			finally
			{
				// data source cleanup
				connection.Close();
			}

			// Return the retrieved entities.
			return result?.ToList();
		}

		/// <inheritdoc/>>
		public virtual async Task<TEntity?> GetAsync<TType>(params TType[] ids)
		{
			this.Validate();

			if (ids.Length < 1)
			{
				throw new ArgumentException($"The supplied ids list ({ids} must contain at least one item ({this.GetType().Name})");
			}

			// Construct the SQL query to select a record by its ID from the table.
			var querySql = this.SqlBuilder.BuildSelect(this.TableName, this.ColumnNames, this.KeyColumnNames);
			var queryParameters = this.BuildParameters(this.KeyColumnNames, ids);

			// Open a data source connection.
			var connection = this.DataSourceContext.GetConnection();

			TEntity? result = null;
			try
			{
				// Execute the query asynchronously and retrieve the result.
				result = await connection.QuerySingleOrDefaultAsync<TEntity>(
					querySql, 
					queryParameters,
					transaction: this.DataSourceContext.DataSourceTransaction);

			}
			catch (Exception exc)
			{
				this.Logger.LogError(exc, nameof(this.GetAsync));
				await this.DataSourceContext.Rollback();

				throw;
			}
			finally
			{
				// data source cleanup
				connection.Close();
			}

			// Return the retrieved entity (or null if not found).
			return result;
		}

		/// <inheritdoc/>>
		public virtual async Task<int> InsertAsync(TEntity model)
		{
			this.Validate();

			if (model == null)
			{
				throw new ArgumentException($"Invalid argument: {nameof(model)} ({this.GetType().Name})");
			}

			if (this.KeyColumnNames.Contains(","))
			{
				throw new InvalidOperationException($"This method should not be used for multi-key tables ({this.GetType().Name})");
			}

#pragma warning disable CS8602 // Dereference of a possibly null reference.
			// Construct the SQL query to insert a new record into the table.
			var querySql = this.SqlBuilder.BuildInsert(
				this.TableName, 
				this.ColumnNames, 
				this.KeyColumnNames,
				this.DataSourceContext.DataConnectionConfiguration.DataSourceEnum,
				this.KeyIsAutoIncrement);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

			// Open a data source connection.
			var connection = this.DataSourceContext.GetConnection();

			int id = -01;
			var success = false;
			try
			{
				// Execute the query asynchronously and retrieve the inserted ID.
				id = await connection.QueryFirstOrDefaultAsync<int>(
					querySql, 
					model,
					transaction: this.DataSourceContext.DataSourceTransaction);

				success = id > 0;
				if (success)
				{
					await this.DataSourceContext.Commit();
				}
				else
				{
					await this.DataSourceContext.Rollback();
				}
			}
			catch (Exception exc)
			{
				this.Logger.LogError(exc, nameof(this.InsertAsync));
				await this.DataSourceContext.Rollback();

				throw;
			}
			finally
			{
				// data source cleanup
				connection.Close();
			}

			// Return the inserted ID.
			return id;
		}

		/// <inheritdoc/>>
		public virtual async Task<IEnumerable<TEntity>?> QueryAsync(string query, object? parameters = null)
		{
			this.Validate();

			if (string.IsNullOrWhiteSpace(query))
			{
				throw new ArgumentException($"Invalid argument: {nameof(query)} ({this.GetType().Name})");
			}

			// Open a data source connection.
			var connection = this.DataSourceContext.GetConnection();

			List<TEntity>? result = null;
			try
			{
				// Execute the query asynchronously
				var taskResult = await connection.QueryAsync<TEntity>(
					query, 
					parameters,
					transaction: this.DataSourceContext.DataSourceTransaction);
				result = taskResult.ToList();
			}
			catch (Exception exc)
			{
				this.Logger.LogError(exc, nameof(this.QueryAsync));
				await this.DataSourceContext.Rollback();

				throw;
			}
			finally
			{
				// data source cleanup
				connection.Close();
			}

			return result;
		}

		/// <inheritdoc/>>
		public virtual async Task<TEntity?> QueryFirstAsync(string query, object? parameters = null)
		{
			this.Validate();

			if (string.IsNullOrWhiteSpace(query))
			{
				throw new ArgumentException($"Invalid argument: {nameof(query)} ({this.GetType().Name})");
			}

			// Open a data source connection.
			var connection = this.DataSourceContext.GetConnection();

			TEntity? result = null;
			try
			{
				// Execute the query asynchronously
				result = await connection.QueryFirstAsync<TEntity>(
					query, 
					parameters,
					transaction: this.DataSourceContext.DataSourceTransaction);
			}
			catch (Exception exc)
			{
				this.Logger.LogError(exc, nameof(this.QueryFirstAsync));
				await this.DataSourceContext.Rollback();

				throw;
			}
			finally
			{
				// data source cleanup
				connection.Close();
			}

			return result;
		}

		/// <inheritdoc/>>
		public virtual async Task<TEntity?> QuerySingleAsync(string query, object? parameters = null)
		{
			this.Validate();

			if (string.IsNullOrWhiteSpace(query))
			{
				throw new ArgumentException($"Invalid argument: {nameof(query)} ({this.GetType().Name})");
			}

			// Open a data source connection.
			var connection = this.DataSourceContext.GetConnection();

			TEntity? result = null;
			try
			{
				// Execute the query asynchronously
				result = await connection.QuerySingleAsync<TEntity>(
					query, 
					parameters,
					transaction: this.DataSourceContext.DataSourceTransaction);
			}
			catch (Exception exc)
			{
				this.Logger.LogError(exc, nameof(this.QuerySingleAsync));
				await this.DataSourceContext.Rollback();

				throw;
			}
			finally
			{
				// data source cleanup
				connection.Close();
			}

			return result;
		}

		/// <inheritdoc/>>
		public virtual async Task<bool> UpdateAsync(TEntity model)
		{
			this.Validate();

			if (model == null)
			{
				throw new ArgumentException($"Invalid argument: {nameof(model)} ({this.GetType().Name})");
			}

			// Construct the SQL query to update the record in the table.
			var querySql = this.SqlBuilder.BuildUpdate(
				this.TableName, 
				this.ColumnNames, 
				this.KeyColumnNames,
				this.KeyIsAutoIncrement);

			// Open a data source connection.
			var connection = this.DataSourceContext.GetConnection();

			var success = false;
			try
			{
				// Execute the query asynchronously and retrieve the result.
				var result = await connection.ExecuteAsync(
					querySql, 
					model,
					transaction: this.DataSourceContext.DataSourceTransaction);

				success = result > 0;
				if (success)
				{
					await this.DataSourceContext.Commit();
				}
				else
				{
					await this.DataSourceContext.Rollback();
				}
			}
			catch (Exception exc)
			{
				this.Logger.LogError(exc, nameof(this.UpdateAsync));
				await this.DataSourceContext.Rollback();

				throw;
			}
			finally
			{
				// data source cleanup
				connection.Close();
			}

			// Return true if at least one record was affected; otherwise, return false.
			return success;
		}

		/// <summary>
		/// Validate the properties on this object.
		/// </summary>
		protected void Validate()
		{
			if (this.WasValidated)
			{
				return;
			}

			if (this.ColumnNames == null ||
				this.ColumnNames.Count == 0)
			{
				throw new ConfigurationException(
					$"The {nameof(this.ColumnNames)} property is required and cannot be null or empty ({this.GetType().Name})");
			}

			if (this.KeyColumnNames == null ||
				this.KeyColumnNames.Count == 0)
			{
				throw new ConfigurationException(
					$"The {nameof(this.KeyColumnNames)} property is required and cannot be null or empty ({this.GetType().Name})");
			}

			if (string.IsNullOrWhiteSpace(this.TableName))
			{
				throw new ConfigurationException(
					$"The {nameof(this.TableName)} property is required and cannot be null or empty ({this.GetType().Name})");
			}

			this.WasValidated = true;
		}
	}
}
