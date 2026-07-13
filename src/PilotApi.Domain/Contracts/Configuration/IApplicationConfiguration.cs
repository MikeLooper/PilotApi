using PilotApi.Domain.Contracts.Base;
using PilotApi.Domain.Models.Dto;
using System.Collections.Generic;

namespace PilotApi.Domain.Contracts.Configuration
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
	///				"DatabaseName": "SampleDatabase",
	///				"DatabaseType": "SqlServer",
	///				"Host": "localhost",
	///				"Password": "sedrt^FLKNR434",
	///				"Port": 0,
	///				"UserName": "SampleUser"
	/// 		}
	///		]
	/// }
	/// </code>
	/// </example>
	public interface IApplicationConfiguration : IConfigurationBase
	{
		/// <summary>
		/// Gets or sets the list of data connection configurations for the application.
		/// </summary>
		List<DataConnectionConfiguration>? DataConnections { get; set; }
	}
}
