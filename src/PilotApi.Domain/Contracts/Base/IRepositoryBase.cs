using System.Collections.Generic;
using System.Threading.Tasks;

namespace PilotApi.Domain.Contracts.Base
{
	public interface IRepositoryBase<TEntity> where TEntity : IEntityBase
	{
		/// <summary>
		/// Deletes a record from the database table based on the specified ID.
		/// </summary>
		/// <param name="id">
		/// An integer representing the ID of the record to be deleted from the database table.
		/// </param>
		/// <returns>
		/// A boolean value indicating whether the deletion was successful.
		/// Returns true if at least one record was affected (deleted); otherwise, returns false.
		/// </returns>
		Task<bool> DeleteAsync(int id);

		/// <summary>
		/// Gets all records from the database table.
		/// </summary>
		/// <returns>
		/// An IEnumerable<T> containing all records from the database table.
		/// </returns>
		Task<IEnumerable<TEntity>?> GetAllAsync();

		/// <summary>
		/// Gets a record from the database table based on the specified ID.
		/// </summary>
		/// <param name="id">
		/// An integer representing the ID of the record to be retrieved from the database table.
		/// </param>
		/// <returns>
		/// A Task<T?> representing the record retrieved from the database table.
		/// </returns>
		Task<TEntity?> GetAsync(int id);

		/// <summary>
		/// Inserts a new record into the database table based on the provided model.
		/// </summary>
		/// <param name="model">
		/// An entity representing the new record to be inserted into the database table.
		/// </param>
		/// <returns>
		/// The ID of the newly inserted record in the database table.
		/// </returns>
		Task<int> InsertAsync(TEntity model);

		/// <summary>
		/// Executes a custom SQL query against the database and returns the results as an IEnumerable<T>.
		/// </summary>
		/// <param name="query">
		/// A string representing the custom SQL query to be executed against the database.
		/// </param>
		/// <param name="parameters">
		/// An optional object containing parameters to be used in the SQL query. This can be null if no parameters are needed.
		/// </param>
		/// <returns>
		/// A list of entities retrieved from the database table.
		/// </returns>
		Task<IEnumerable<TEntity>?> QueryAsync(string query, object? parameters = null);

		/// <summary>
		/// Executes a custom SQL query against the database and returns the first result as a single instance of T.
		/// </summary>
		/// <param name="query">
		/// A string representing the custom SQL query to be executed against the database.
		/// </param>
		/// <param name="parameters">
		/// An optional object containing parameters to be used in the SQL query. This can be null if no parameters are needed.
		/// </param>
		/// <returns>
		/// An entity retrieved from the database table.
		/// </returns>
		Task<TEntity?> QueryFirstAsync(string query, object? parameters = null);

		/// <summary>
		/// Executes a custom SQL query against the database and returns a single result as an instance of T.
		/// </summary>
		/// <param name="query">
		/// A string representing the custom SQL query to be executed against the database.
		/// </param>
		/// <param name="parameters">
		/// An optional object containing parameters to be used in the SQL query. This can be null if no parameters are needed.
		/// </param>
		/// <returns>
		/// An entity retrieved from the database table.
		/// </returns>
		Task<TEntity?> QuerySingleAsync(string query, object? parameters = null);

		/// <summary>
		/// Updates an existing record in the database table based on the provided model.
		/// </summary>
		/// <param name="model">
		/// An entoty of the updated record to be saved in the database table.
		/// </param>
		/// <returns>
		/// A boolean value indicating whether the update was successful.
		/// </returns>
		Task<bool> UpdateAsync(TEntity model);
	}
}
