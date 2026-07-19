using Newtonsoft.Json;
using PilotApi.Shared.Configuration.Base;
using PilotApi.Shared.Contracts.Configuration;
using PilotApi.Shared.Exceptions;
using System;
using System.Collections.Generic;

namespace PilotApi.Shared.Configuration
{
	/// <inheritdoc/>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class OpenApiContactConfiguration : ConfigurationBase, IOpenApiContactConfiguration
	{
		/// <inheritdoc/>
		[JsonProperty]
		public string? Email { get; set; }

		/// <inheritdoc/>
		[JsonProperty]
		public string? Name { get; set; }

		/// <inheritdoc/>
		[JsonProperty]
		public string? URL { get; set; }

		/// <inheritdoc/>>
		public override string ToString()
		{
			return $"{nameof(this.Active)}={this.Active}, " +
				$"{nameof(this.Email)}={this.Email}, " +
				$"{nameof(this.Name)}={this.Name}, " +
				$"{nameof(this.URL)}={this.URL}";
		}

		/// <inheritdoc/>
		public override void Validate(ref List<Exception> exceptions)
		{
			if (exceptions == null)
			{
				throw new ArgumentException($"The {nameof(exceptions)} argument is invalid ({this.GetType().Name})");
			}

			if (string.IsNullOrWhiteSpace(this.Email))
			{
				exceptions.Add(
					new ConfigurationException($"The {nameof(this.Email)} value is required and cannot be null or empty ({this.GetType().Name})"));
			}

			if (string.IsNullOrWhiteSpace(this.Name))
			{
				exceptions.Add(
					new ConfigurationException($"The {nameof(this.Name)} value is required and cannot be null or empty ({this.GetType().Name})"));
			}

			if (string.IsNullOrWhiteSpace(this.URL))
			{
				exceptions.Add(
					new ConfigurationException($"The {nameof(this.URL)} value is required and cannot be null or empty ({this.GetType().Name})"));
			}

		}
	}
}
