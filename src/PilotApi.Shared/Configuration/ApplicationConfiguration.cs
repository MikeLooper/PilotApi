using Newtonsoft.Json;
using PilotApi.Shared.Configuration.Base;
using PilotApi.Shared.Constants;
using PilotApi.Shared.Contracts.Configuration;
using PilotApi.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PilotApi.Shared.Configuration
{
	/// <inheritdoc/>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class ApplicationConfiguration : ConfigurationBase, IApplicationConfiguration
	{
		/// <summary>
		/// Instatiate a <see cref="ApplicationConfiguration"/> object.
		/// </summary>
		public ApplicationConfiguration()
		{
			this.DataConnections = new List<DataConnectionConfiguration>();
			this.OpenApi = new OpenApiConfiguration();
		}

		/// <inheritdoc/>>
		[JsonProperty]
		public List<DataConnectionConfiguration>? DataConnections { get; set; }

		/// <summary>
		/// Gets or sets a Contact object.
		/// </summary>
		public OpenApiConfiguration? OpenApi { get; set; }

		/// <inheritdoc/>>
		public override string ToString()
		{
			return $"{nameof(this.Active)}={this.Active}, " +
				$"{nameof(this.DataConnections)}={this.DataConnections}, " +
				$"{nameof(this.OpenApi)}={this.OpenApi}";
		}

		/// <inheritdoc/>
		public void Validate()
		{
			var exceptions = new List<Exception>();

			if (this.DataConnections == null ||
				this.DataConnections.Count == 0)
			{
				exceptions.Add(
					new ConfigurationException(
						$"The {nameof(this.DataConnections)} property is required and cannot be null or empty ({this.GetType().Name})"));
			}
			else
			{
				foreach (var dataConnection in this.DataConnections)
				{
					dataConnection.Validate(ref exceptions);
				}

				var activeCount = this.DataConnections
					.Where(w => w.Active)
					.Count();
				if (activeCount != 1)
				{
					exceptions.Add(
						new ConfigurationException(
							$"The {nameof(this.DataConnections)} property should have one active item ({this.GetType().Name})"));
				}
			}

			if (this.OpenApi == null)
			{
				exceptions.Add(
					new ConfigurationException(
						$"The {nameof(this.OpenApi)} property is required and cannot be null or empty ({this.GetType().Name})"));
			}

			if (exceptions.Count == 1)
			{
				throw exceptions.First();
			}
			else if (exceptions.Count > 1)
			{
				throw new AggregateException(exceptions);
			}
		}

#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
		/// <inheritdoc/>
		[Obsolete("The Validate() method should be used with this class")]
		public override void Validate(ref List<Exception> exceptions)
		{
		}
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
	}
}
