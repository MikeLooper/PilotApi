using Newtonsoft.Json;
using PilotApi.Domain.Contracts.Configuration;
using PilotApi.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace PilotApi.Domain.Models.Dto
{
	/// <summary>
	/// Configuration for the application.
	/// </summary>
	/// <example>
	/// Example configuration:
	/// <code>
	/// {
	///		"Active": true,
	///		"DataConnections": [
	///			{
	///				"Active": true,
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
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class ApplicationConfiguration : IApplicationConfiguration
	{
		public ApplicationConfiguration()
		{
			this.DataConnections = new List<DataConnectionConfiguration>();
		}

		public bool Active { get; set; } = true;

		/// <summary>
		/// Gets or sets the list of data connection configurations for the application.
		/// </summary>
		[JsonProperty]
		public List<DataConnectionConfiguration>? DataConnections { get; set; }

		public void Validate()
		{
			if (this.DataConnections == null ||
				this.DataConnections.Count == 0)
			{
				throw new ConfigurationException($"The {nameof(this.DataConnections)} property is required and cannot be null or empty.");
			}

			foreach (var dataConnection in this.DataConnections)
			{
				dataConnection.Validate();
			}

			var activeCount = this.DataConnections
				.Where(w => w.Active)
				.Count();
			if (activeCount != 1)
			{
				throw new ConfigurationException($"The {nameof(this.DataConnections)} property should have one active item.");
			}
		}
	}
}
