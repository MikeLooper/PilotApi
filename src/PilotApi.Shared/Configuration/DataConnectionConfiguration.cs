using Newtonsoft.Json;
using PilotApi.Shared.Configuration.Base;
using PilotApi.Shared.Constants;
using PilotApi.Shared.Contracts.Configuration;
using PilotApi.Shared.Exceptions;
using PilotApi.Shared.Utilities;
using System;
using System.Collections.Generic;

namespace PilotApi.Shared.Configuration
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
	///		"Active": true,
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
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	
	public class DataConnectionConfiguration : ConfigurationBase, IDataConnectionConfiguration
	{
		/// <inheritdoc/>>
		[JsonProperty]
		public int ConnectTimeout { get; set; } = 0;

		/// <inheritdoc/>>
		public DataSources DataSourceEnum { get; set; } = DataSources.Unrecognized;

		/// <inheritdoc/>>
		[JsonProperty]
		public string? DataSourceName { get; set; }

		/// <inheritdoc/>>
		[JsonProperty]
		public string? DataSourceType { get; set; }

		/// <inheritdoc/>>
		[JsonProperty]
		public string? Host { get; set; }

		/// <inheritdoc/>>
		[JsonProperty]
		public string? Password { get; set; }

		/// <inheritdoc/>>
		[JsonProperty]
		public int? Port { get; set; }

		/// <inheritdoc/>>
		[JsonProperty]
		public string? UserName { get; set; }

		/// <inheritdoc/>>
		public override string ToString()
		{
			return $"{nameof(this.Active)}={this.Active}, " +
				$"{nameof(this.ConnectTimeout)}={this.ConnectTimeout}, " +
				$"{nameof(this.DataSourceEnum)}={this.DataSourceEnum}, " +
				$"{nameof(this.DataSourceName)}={this.DataSourceName}, " +
				$"{nameof(this.DataSourceType)}={this.DataSourceType}, " +
				$"{nameof(this.Host)}={this.Host}, " +
				$"{nameof(this.Password)}={(string.IsNullOrWhiteSpace(Password) ? StringConstants.LogEmpty : StringConstants.Redacted)}, " +
				$"{nameof(this.Port)}={this.Port}, " +
				$"{nameof(this.UserName)}={this.UserName}";
		}

		/// <inheritdoc/>>
		public override void Validate(ref List<Exception> exceptions)
		{
			if (exceptions == null)
			{
				throw new ArgumentException($"The {nameof(exceptions)} argument is invalid ({this.GetType().Name})");
			}

			if (string.IsNullOrWhiteSpace(this.DataSourceName))
			{
				throw new ConfigurationException($"The {nameof(this.DataSourceName)} value is required and cannot be null or empty ({this.GetType().Name})");
			}

			if (string.IsNullOrWhiteSpace(this.DataSourceType))
			{
				throw new ConfigurationException($"The {nameof(this.DataSourceType)} value is required and cannot be null or empty ({this.GetType().Name})");
			}
			else
			{
				this.DataSourceEnum = DataSourceUtilities.ResolveDataSources(this.DataSourceType);
				if (this.DataSourceEnum == DataSources.Unrecognized)
				{
					throw new ConfigurationException($"The {nameof(this.DataSourceType)} value is not valid.  " +
						$"Valid values include: {DataSourceUtilities.GetAvailableDataSourcesList()} ({this.GetType().Name})");
				}
			}

			if (string.IsNullOrWhiteSpace(this.Host))
			{
				throw new ConfigurationException($"The {nameof(this.Host)} value is required and cannot be null or empty ({this.GetType().Name})");
			}

			if (string.IsNullOrWhiteSpace(this.Password))
			{
				throw new ConfigurationException($"The {nameof(this.Password)} value is required and cannot be null or empty ({this.GetType().Name})");
			}

			if (string.IsNullOrWhiteSpace(this.UserName))
			{
				throw new ConfigurationException($"The {nameof(this.UserName)} value is required and cannot be null or empty ({this.GetType().Name})");
			}
		}
	}
}
