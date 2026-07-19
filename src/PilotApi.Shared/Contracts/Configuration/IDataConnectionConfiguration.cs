using PilotApi.Shared.Constants;
using PilotApi.Shared.Contracts.Configuration.Base;

namespace PilotApi.Shared.Contracts.Configuration
{
	/// <summary>
	/// Configuration for a data source connection.
	/// </summary>
	/// <example>
	/// Example SQL Server connection string:
	/// <code>
	/// Data Source=localhost;Initial Catalog=SampleDatabase;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;
	/// </code>
	/// Example PostGreSQL connection string:
	/// <code>
	/// Host=localhost;Port=5432;Database=eCommerceUsers;Username=postgres;Password=admin;
	/// </code>
	/// Example configuration:
	/// <code>
	/// {
	///		"ConnectTimeout": 0,
	///		"DataSourceName": "SampleDatabase",
	///		"DataSourceType": "SqlServer",
	///		"Host": "localhost",
	///		"Password": "sedrt^FLKNR434",
	///		"Port": 0,
	///		"UserName": "SampleUser"
	/// }
	/// </code>
	/// </example>
	public interface IDataConnectionConfiguration : IConfigurationBase
	{
		/// <summary>
		/// Gets or sets the connection timeout in seconds. A value of 0 indicates no timeout.
		/// </summary>
		int ConnectTimeout { get; set; }

		/// <summary>
		/// Gets or sets the data source type (e.g., "SqlServer", "PostgreSQL") as an enum.
		/// This will one of the <see cref="DataSources"/> options.
		/// </summary>
		DataSources DataSourceEnum { get; set; }

		/// <summary>
		/// Gets or sets the data source name.
		/// </summary>
		string? DataSourceName { get; set; }

		/// <summary>
		/// Gets or sets the data source type (e.g., "SqlServer", "PostgreSQL").
		/// </summary>
		string? DataSourceType { get; set; }

		/// <summary>
		/// Gets or sets the data source host (e.g., "localhost")
		/// </summary>
		string? Host { get; set; }

		/// <summary>
		/// Gets or sets the data source user password.
		/// </summary>
		string? Password { get; set; }

		/// <summary>
		/// Gets or sets the data source port number. A value of null indicates the default port for the specified data source type.
		/// </summary>
		int? Port { get; set; }

		/// <summary>
		/// Gets or sets the data source user name.
		/// </summary>
		string? UserName { get; set; }
	}
}
