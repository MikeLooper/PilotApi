using PilotApi.Shared.Configuration;
using PilotApi.Shared.Contracts.Configuration.Base;
using System.Collections.Generic;

namespace PilotApi.Shared.Contracts.Configuration
{
	/// <summary>
	/// Configuration for the application.
	/// </summary>
	/// <example>
	/// Example configuration:
	/// <code>
	/// {
	///		"DataConnections": [
	///			{
	///				"ConnectTimeout": 0,
	///				"DataSourceName": "SampleDatabase",
	///				"DataSourceType": "SqlServer",
	///				"Host": "localhost",
	///				"Password": "sedrt^FLKNR434",
	///				"Port": 0,
	///				"UserName": "SampleUser"
	/// 		}
	///		],
	///		"OpenApi": {
	///			"Title": "PilotApi",
	///			"Contact": {
	///				"Email": "MikelLooper@gmail.com",
	///				"Name": "Michael Looper",
	///				"URL": "https://github.com/MikeLooper/PilotApi"
	///			},
	///			"Description": "A proof of concept API to explore best-practices and new ideas",
	///			"License": "MIT",
	///			"Summary": "Proof of concept API",
	///			"Version":  "0.1.1"
	///		}
	/// }
	/// </code>
	/// </example>
	public interface IApplicationConfiguration : IConfigurationBase
	{
		/// <summary>
		/// Gets or sets the list of data connection configurations for the application.
		/// </summary>
		List<DataConnectionConfiguration>? DataConnections { get; set; }

		/// <summary>
		/// Gets or sets a Contact object.
		/// </summary>
		OpenApiConfiguration? OpenApi { get; set; }
	}
}
