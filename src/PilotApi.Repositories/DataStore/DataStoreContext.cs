using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Npgsql;
using PilotApi.Domain.Contracts.Configuration;
using PilotApi.Domain.Contracts.DataStore;
using System;
using System.Data;
using System.Linq;

namespace PilotApi.Services.DataStore
{
	/// <summary>
	/// The datastore context.
	/// </summary>
	public class DataStoreContext : IDataStoreContext
	{
		public DataStoreContext(
			ILoggerFactory loggerFactory,
			IApplicationConfiguration applicationConfiguration)
		{
			this.Logger = loggerFactory.CreateLogger(GetType());
			this.DataConnection = applicationConfiguration.DataConnections
				.First(f => f.Active);
		}

		public IDataConnectionConfiguration? DataConnection { get; }

		public IDbConnection DbConnection
		{
			get
			{
				return this.GetConnection();
			}
		}

		/// <summary>
		/// Gets the logger instance for logging information, warnings, and errors.
		/// </summary>
		protected ILogger Logger { get; }

		private IDbConnection DatabaseConnection { get; set; }

		private IDbConnection GetConnection()
		{
			if (this.DatabaseConnection == null)
			{

				if (this.DataConnection.DatabaseType == "SqlServer")
				{
					var dataSource = this.DataConnection.Host;
					if (this.DataConnection.Port != null)
					{
						dataSource += "," + this.DataConnection.Port.ToString();
					}

					var connectionString = $"Data Source={dataSource};Initial Catalog={this.DataConnection.DatabaseName};" + 
						$"User Id={this.DataConnection.UserName};Password={this.DataConnection.Password};" + 
						$"Connect Timeout={this.DataConnection.ConnectTimeout};";
					this.DatabaseConnection = new SqlConnection(connectionString);
				}
				else
				{
					var connectionString = $"Host={this.DataConnection.Host};Database={this.DataConnection.DatabaseName};" + 
						$"Username={this.DataConnection.UserName};Password={this.DataConnection.Password};" + 
						$"Timeout={this.DataConnection.ConnectTimeout};";
					if (this.DataConnection.Port != null)
					{
						connectionString += $";Port={this.DataConnection.Port}";
					}

					this.DatabaseConnection = new NpgsqlConnection(connectionString);
				}
			}

			return this.DatabaseConnection;
		}

		#region Dispose

		private bool disposed;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
				if (disposing)
					DatabaseConnection.Dispose();
			disposed = true;
		}
		
		#endregion Dispose
	}
}
