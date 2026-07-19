using Dapper;
using PilotApi.Repositories.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PilotApi.Repositories.Contracts.Repository.Base
{
	/// <summary>
	/// An interface for the repository base.
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public interface IRepositoryBase<TEntity> where TEntity : EntityBase
	{
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
		DynamicParameters BuildParameters<TType>(List<string> keyColumnNames, params TType[] ids);

		/// <summary>
		/// Return a count of all the records from the data source table.
		/// </summary>
		/// <returns>
		/// The number of records in the data source table.
		/// </returns>
		Task<int> CountAllAsync();

		/// <summary>
		/// Deletes a record from the data source table based on the specified ID.
		/// </summary>
		/// <param name="ids">
		/// A list of Id values, which should be in the same order as the key columns property.
		/// </param>
		/// <returns>
		/// A boolean value indicating whether the deletion was successful.
		/// Returns true if at least one record was affected (deleted); otherwise, returns false.
		/// </returns>
		Task<bool> DeleteAsync<TType>(params TType[] ids);

		/// <summary>
		/// Gets all records from the data source table.
		/// </summary>
		/// <returns>
		/// An List&lt;T&gt; containing all records from the data source table.
		/// </returns>
		Task<List<TEntity>?> GetAllAsync();

		/// <summary>
		/// Gets a record from the data source table based on the specified ID.
		/// </summary>
		/// <param name="ids">
		/// A list of Id values, which should be in the same order as the key columns property.
		/// </param>
		/// <returns>
		/// A Task&lt;T?&gt; representing the record retrieved from the data source table.
		/// </returns>
		Task<TEntity?> GetAsync<TType>(params TType[] ids);

		/// <summary>
		/// Inserts a new record into the data source table based on the provided model.
		/// </summary>
		/// <param name="model">
		/// An entity representing the new record to be inserted into the data source table.
		/// </param>
		/// <returns>
		/// The ID of the newly inserted record in the data source table.
		/// </returns>
		Task<int> InsertAsync(TEntity model);

		/// <summary>
		/// Executes a custom SQL query against the data source and returns the results as an IEnumerable&lt;T&gt;.
		/// </summary>
		/// <param name="query">
		/// A string representing the custom SQL query to be executed against the data source.
		/// </param>
		/// <param name="parameters">
		/// An optional object containing parameters to be used in the SQL query. This can be null if no parameters are needed.
		/// </param>
		/// <returns>
		/// A list of entities retrieved from the data source table.
		/// </returns>
		Task<IEnumerable<TEntity>?> QueryAsync(string query, object? parameters = null);

		/// <summary>
		/// Executes a custom SQL query against the data source and returns the first result as a single instance of T.
		/// </summary>
		/// <param name="query">
		/// A string representing the custom SQL query to be executed against the data source.
		/// </param>
		/// <param name="parameters">
		/// An optional object containing parameters to be used in the SQL query. This can be null if no parameters are needed.
		/// </param>
		/// <returns>
		/// An entity retrieved from the data source table.
		/// </returns>
		Task<TEntity?> QueryFirstAsync(string query, object? parameters = null);

		/// <summary>
		/// Executes a custom SQL query against the data source and returns a single result as an instance of T.
		/// </summary>
		/// <param name="query">
		/// A string representing the custom SQL query to be executed against the data source.
		/// </param>
		/// <param name="parameters">
		/// An optional object containing parameters to be used in the SQL query. This can be null if no parameters are needed.
		/// </param>
		/// <returns>
		/// An entity retrieved from the data source table.
		/// </returns>
		Task<TEntity?> QuerySingleAsync(string query, object? parameters = null);

		/// <summary>
		/// Updates an existing record in the data source table based on the provided model.
		/// </summary>
		/// <param name="model">
		/// An entity of the updated record to be saved in the data source table.
		/// </param>
		/// <returns>
		/// A boolean value indicating whether the update was successful.
		/// </returns>
		Task<bool> UpdateAsync(TEntity model);
	}
}
