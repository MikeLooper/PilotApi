using Newtonsoft.Json;
using PilotApi.Domain.Contracts.Configuration;
using PilotApi.Domain.Exceptions;
using System.Text.Json.Serialization;

namespace PilotApi.Domain.Models.Dto
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
	///		"Active": true,
	///		"ConnectTimeout": 0,
	///		"DatabaseName": "SampleDatabase",
	///		"DatabaseType": "SqlServer",
	///		"Host": "localhost",
	///		"Password": "sedrt^FLKNR434",
	///		"Port": 0,
	///		"UserName": "SampleUser"
	/// }
	/// </example>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	
	public class DataConnectionConfiguration : IDataConnectionConfiguration
	{
		/// <summary>
		/// Gets or sets a flag that indicates whether this data connection configuration is active. Only one data connection configuration should be active at a time.
		/// </summary>
		[JsonProperty]
		public bool Active { get; set; } = true;

		/// <summary>
		/// Gets or sets the connection timeout in seconds. A value of 0 indicates no timeout.
		/// </summary>
		[JsonProperty]
		public int ConnectTimeout { get; set; } = 0;

		/// <summary>
		/// Gets or sets the database name.
		/// </summary>
		[JsonProperty]
		public string? DatabaseName { get; set; }

		/// <summary>
		/// Gets or sets the database type (e.g., "SqlServer", "PostgreSQL").
		/// </summary>
		[JsonProperty]
		public string? DatabaseType { get; set; }

		/// <summary>
		/// Gets or sets the database host (e.g., "localhost")
		/// </summary>
		[JsonProperty]
		public string? Host { get; set; }

		/// <summary>
		/// Gets or sets the database password.
		/// </summary>
		[JsonProperty]
		public string? Password { get; set; }

		/// <summary>
		/// Gets or sets the database port number. A value of null indicates the default port for the specified database type.
		/// </summary>
		[JsonProperty]
		public int? Port { get; set; }

		/// <summary>
		/// Gets or sets the database user name.
		/// </summary>
		[JsonProperty]
		public string? UserName { get; set; }

		public void Validate()
		{
			if (string.IsNullOrWhiteSpace(this.DatabaseName))
			{
				throw new ConfigurationException($"The {nameof(this.DatabaseName)} value is required and cannot be null or empty.");
			}

			if (string.IsNullOrWhiteSpace(this.DatabaseType))
			{
				throw new ConfigurationException($"The {nameof(this.DatabaseType)} value is required and cannot be null or empty.");
			}
			else if (!this.DatabaseType.Equals("SqlServer") && !this.DatabaseType.Equals("PostgreSQL"))
			{
				throw new ConfigurationException($"The {nameof(this.DatabaseType)} value is not valid.  Valid values include: 'SqlServer' and 'PostgreSQL'.");
			}

			if (string.IsNullOrWhiteSpace(this.Host))
			{
				throw new ConfigurationException($"The {nameof(this.Host)} value is required and cannot be null or empty.");
			}

			if (string.IsNullOrWhiteSpace(this.Password))
			{
				throw new ConfigurationException($"The {nameof(this.Password)} value is required and cannot be null or empty.");
			}

			if (string.IsNullOrWhiteSpace(this.UserName))
			{
				throw new ConfigurationException($"The {nameof(this.UserName)} value is required and cannot be null or empty.");
			}
		}
	}
}
