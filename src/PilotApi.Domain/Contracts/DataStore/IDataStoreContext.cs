using PilotApi.Domain.Contracts.Configuration;
using System;
using System.Data;

namespace PilotApi.Domain.Contracts.DataStore
{
	/// <summary>
	/// Contract for the datastore context.
	/// </summary>
	public interface IDataStoreContext : IDisposable
	{
		IDataConnectionConfiguration? DataConnection { get; }

		IDbConnection DbConnection { get; }
	}
}
