using PilotApi.Domain.Contracts.Configuration;
using System;
using System.Data;

namespace PilotApi.Domain.Contracts.DataStore
{
	/// <summary>
	/// Interface for the datastore context.
	/// </summary>
	public interface IDataStoreContext : IDisposable
	{

		/// <summary>
		/// The configuration for the data connection, which may be null if no configuration is provided.
		/// </summary>
		IDataConnectionConfiguration? DataConnection { get; }

		/// <summary>
		/// An open database connection for the datastore context.
		/// </summary>
		IDbConnection DbConnection { get; }
	}
}
