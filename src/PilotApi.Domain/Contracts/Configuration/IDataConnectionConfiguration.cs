using PilotApi.Domain.Contracts.Base;

namespace PilotApi.Domain.Contracts.Configuration
{
	/// <summary>
	/// Configuration for a database connection.
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
	///		"DatabaseName": "SampleDatabase",
	///		"DatabaseType": "SqlServer",
	///		"Host": "localhost",
	///		"Password": "sedrt^FLKNR434",
	///		"Port": 0,
	///		"UserName": "SampleUser"
	/// }
	/// </example>
	public interface IDataConnectionConfiguration : IConfigurationBase
	{
		/// <summary>
		/// Gets or sets the connection timeout in seconds. A value of 0 indicates no timeout.
		/// </summary>
		int ConnectTimeout { get; set; }

		/// <summary>
		/// Gets or sets the database name.
		/// </summary>
		string? DatabaseName { get; set; }

		/// <summary>
		/// Gets or sets the database type (e.g., "SqlServer", "PostgreSQL").
		/// </summary>
		string? DatabaseType { get; set; }

		/// <summary>
		/// Gets or sets the database host (e.g., "localhost")
		/// </summary>
		string? Host { get; set; }

		/// <summary>
		/// Gets or sets the database password.
		/// </summary>
		string? Password { get; set; }

		/// <summary>
		/// Gets or sets the database port number. A value of null indicates the default port for the specified database type.
		/// </summary>
		int? Port { get; set; }

		/// <summary>
		/// Gets or sets the database user name.
		/// </summary>
		string? UserName { get; set; }
	}
}
