using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Npgsql;
using PilotApi.Domain.Contracts.DataSource;
using PilotApi.Shared.Constants;
using PilotApi.Shared.Contracts.Configuration;
using PilotApi.Shared.Exceptions;
using PilotApi.Shared.Utilities;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PilotApi.Repositories.DataSource
{
	/// <summary>
	/// The datastore context.
	/// The connection information for this context will be read from the first active ApplicationConfiguration.DataConnections settings.
	/// If the connection object in this object is open when this object is disposed, 
	/// it will automatically be closed with a rollback of any pending activity.
	/// Commits of pending activity must be explicitly executed by the calling code.
	/// </summary>
	public class DataSourceContext : IDataSourceContext
	{
		/// <summary>
		/// Instantiate a <see cref="DataSourceContext"/> object.
		/// </summary>
		/// <param name="loggerFactory"></param>
		/// <param name="applicationConfiguration"></param>
		/// <exception cref="ConfigurationException"></exception>
		public DataSourceContext(
			ILoggerFactory loggerFactory,
			IApplicationConfiguration applicationConfiguration)
		{
			this.Logger = loggerFactory.CreateLogger(GetType());
			this.ApplicationConfiguration = applicationConfiguration;
#pragma warning disable CS8604 // Possible null reference argument.
			this.DataConnectionConfiguration = applicationConfiguration.DataConnections
				.First(f => f.Active);
#pragma warning restore CS8604 // Possible null reference argument.

			if (this.DataConnectionConfiguration == null)
			{
				throw new ConfigurationException(
					$"The {nameof(IApplicationConfiguration)}.{nameof(applicationConfiguration.DataConnections)} " + 
					$"section should have at least one active setting ({this.GetType().Name})");
			}
		}

		/// <inheritdoc/>>
		protected IApplicationConfiguration? ApplicationConfiguration { get; }

		/// <summary>
		/// Gets a data source connection string.
		/// </summary>
		protected string? ConnectionString { get; private set; }

		/// <summary>
		/// Gets or sets a data source connection string.
		/// </summary>
		public string? ConnectionStringClean { get; private set; }

		/// <inheritdoc/>>
		public IDataConnectionConfiguration? DataConnectionConfiguration { get; }

		/// <inheritdoc/>>
		public IDbTransaction? DataSourceTransaction { get; set; }

		/// <summary>
		/// Gets or sets a <see cref="IDbConnection"/> object.
		/// This is the storage propert for the data source connection object.
		/// </summary>
		protected IDbConnection? DataSourceConnectionInternal { get; set; }

		/// <summary>
		/// Gets the logger instance for logging information, warnings, and errors.
		/// </summary>
		protected ILogger Logger { get; }

		/// <inheritdoc/>>
		public async Task Commit()
		{
			if (this.DataSourceTransaction != null)
			{
				this.DataSourceTransaction.Commit();
			}
		}

		/// <inheritdoc/>>
		public IDbConnection GetConnection(bool autoOpen = true)
		{
			if (this.DataSourceConnectionInternal == null)
			{

#pragma warning disable CS8602 // Dereference of a possibly null reference.
				if (this.DataConnectionConfiguration.DataSourceEnum == DataSources.SqlServer)
				{
					// MS SQL Sever
					var dataSource = this.DataConnectionConfiguration.Host;
					if (this.DataConnectionConfiguration.Port != null)
					{
						dataSource += "," + this.DataConnectionConfiguration.Port.ToString();
					}

					this.ConnectionString = $"Data Source={dataSource};Initial Catalog={this.DataConnectionConfiguration.DataSourceName};" +
						$"User Id={this.DataConnectionConfiguration.UserName};Password={this.DataConnectionConfiguration.Password};" +
						$"Connect Timeout={this.DataConnectionConfiguration.ConnectTimeout};Trust Server Certificate=True;" +
						$"Application Name={this.ApplicationConfiguration.OpenApi.Title}";
					this.DataSourceConnectionInternal = new SqlConnection(this.ConnectionString);
				}
				else
				{
					// PostGreSQL
					this.ConnectionString = $"Host={this.DataConnectionConfiguration.Host};Database={this.DataConnectionConfiguration.DataSourceName};" +
						$"Username={this.DataConnectionConfiguration.UserName};Password={this.DataConnectionConfiguration.Password};" +
						$"Timeout={this.DataConnectionConfiguration.ConnectTimeout};SslMode=VerifyFull;TrustServerCertificate=true;" +
						$"Application Name={this.ApplicationConfiguration.OpenApi.Title}";
					if (this.DataConnectionConfiguration.Port != null)
					{
						this.ConnectionString += $";Port={this.DataConnectionConfiguration.Port}";
					}

					this.DataSourceConnectionInternal = new NpgsqlConnection(this.ConnectionString);
				}
#pragma warning restore CS8602 // Dereference of a possibly null reference.

				this.ConnectionStringClean = SecurityUtilities.ConnectionStringClean(this.ConnectionString);
			}

			if (autoOpen)
			{
				if (this.DataSourceConnectionInternal.State != ConnectionState.Open)
				{
					this.DataSourceConnectionInternal.Open();
				}
			}

			if (this.DataSourceConnectionInternal.State == ConnectionState.Open)
			{
				this.DataSourceTransaction = this.DataSourceConnectionInternal.BeginTransaction();
			}

			return this.DataSourceConnectionInternal;
		}

		/// <inheritdoc/>>
		public async Task Rollback()
		{
			if (this.DataSourceTransaction != null)
			{
				this.DataSourceTransaction.Rollback();
			}
		}

		/// <inheritdoc/>>
		public override string ToString()
		{
			return $"{nameof(this.ConnectionString)}={this.ConnectionStringClean}, " +
				$"{nameof(this.DataConnectionConfiguration)}={this.DataConnectionConfiguration}, " +
				$"{nameof(this.DataSourceTransaction)}={(this.DataSourceTransaction == null ? StringConstants.LogNull : StringConstants.HasContents)}";
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
			{
				if (disposing)
				{
					if (this.DataSourceConnectionInternal != null)
					{
						if (this.DataSourceConnectionInternal.State == ConnectionState.Open)
						{
							this.DataSourceConnectionInternal.Close();
						}

						this.DataSourceConnectionInternal.Dispose();
					}
				}
			}

			disposed = true;
		}
		
		#endregion Dispose
	}
}
