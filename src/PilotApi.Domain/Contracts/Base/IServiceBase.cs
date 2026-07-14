using System.Collections.Generic;
using System.Threading.Tasks;

namespace PilotApi.Domain.Contracts.Base
{
	/// <summary>
	/// An interface for the base class for the service layer that provides CRUD operations for a given DTO type.
	/// </summary>
	/// <typeparam name="TDto"></typeparam>
	public interface IServiceBase<TDto> where TDto : IDtoBase
	{
		/// <summary>
		/// Deletes a DTO object of the given type by its ID.
		/// </summary>
		/// <param name="id">
		/// An integer representing the ID of the DTO object to delete.
		/// </param>
		/// <returns>
		/// A flag indicating whether the deletion was successful or not.
		/// </returns>
		Task<bool> DeleteAsync(int id);

		/// <summary>
		/// Gets all DTO objects of the given type.
		/// </summary>
		/// <returns>
		/// A collection of DTO objects of the given type, or null if no objects were found.
		/// </returns>
		Task<IEnumerable<TDto>?> GetAllAsync();

		/// <summary>
		/// Gets a DTO object of the given type by its ID.
		/// </summary>
		/// <param name="id">
		/// The ID of the DTO object to retrieve.
		/// </param>
		/// <returns>
		/// A DTO object of the given type, or null if no object was found with the specified ID.
		/// </returns>
		Task<TDto?> GetByIdAsync(int id);

		/// <summary>
		/// Inserts a new DTO object of the given type into the data store.
		/// </summary>
		/// <param name="model">
		/// A DTO object of the given type to insert into the data store.
		/// </param>
		/// <returns>
		/// The ID of the newly inserted DTO object, or 0 if the insertion failed.
		/// </returns>
		Task<int> InsertAsync(TDto model);

		/// <summary>
		/// Executes a query against the data store and returns a collection of DTO objects of the given type that match the query criteria.
		/// </summary>
		/// <param name="query">
		/// The query string to execute against the data store.
		/// </param>
		/// <param name="parameters">
		/// An optional object containing parameters to pass to the query.
		/// </param>
		/// <returns>
		/// A collection of DTO objects of the given type that match the query criteria, or null if no objects were found.
		/// </returns>
		Task<IEnumerable<TDto>?> QueryAsync(string query, object? parameters = null);

		/// <summary>
		/// Executes a query against the data store and returns the first DTO object of the given type that matches the query criteria.
		/// </summary>
		/// <param name="query">
		/// The query string to execute against the data store.
		/// </param>
		/// <param name="parameters">
		/// An optional object containing parameters to pass to the query.
		/// </param>
		/// <returns>
		/// A DTO object of the given type that matches the query criteria, or null if no object was found.
		/// </returns>
		Task<TDto?> QueryFirstAsync(string query, object? parameters = null);

		/// <summary>
		/// Executes a query against the data store and returns a single DTO object of the given type that matches the query criteria.
		/// </summary>
		/// <param name="query">
		/// The query string to execute against the data store.
		/// </param>
		/// <param name="parameters">
		/// An optional object containing parameters to pass to the query.
		/// </param>
		/// <returns>
		/// A DTO object of the given type that matches the query criteria, or null if no object was found.
		/// </returns>
		Task<TDto?> QuerySingleAsync(string query, object? parameters = null);

		/// <summary>
		/// Updates an existing DTO object of the given type in the data store.
		/// </summary>
		/// <param name="model">
		/// A DTO object of the given type to update in the data store.
		/// </param>
		/// <returns>
		/// A flag indicating whether the update was successful or not.
		/// </returns>
		Task<bool> UpdateAsync(TDto model);
	}
}
