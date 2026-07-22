using PilotApi.Repositories.Models.Base;
using System.Collections.Generic;

namespace PilotApi.Repositories.Handlers
{
	/// <summary>
	/// A handler for updating entity objects.
	/// </summary>
	public interface IEntityUpdateHandler
	{
		/// <summary>
		/// Update the supplied entity object, using the supplied dictionary.
		/// </summary>
		/// <typeparam name="TEntity">
		/// The type of entity of the supplied entity model.
		/// </typeparam>
		/// <param name="entity">
		/// An entity model.
		/// </param>
		/// <param name="nextIds">
		/// A dictionary containing the columns and values to update the entity model.
		/// </param>
		/// <returns>
		/// An updated entity model.
		/// </returns>
		TEntity? Update<TEntity>(TEntity? entity, Dictionary<string, object> nextIds) where TEntity : EntityBase;
	}
}
