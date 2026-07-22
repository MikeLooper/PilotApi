using Newtonsoft.Json;
using PilotApi.Shared.Configuration.Base;
using PilotApi.Shared.Constants;
using PilotApi.Shared.Exceptions;
using PilotApi.Shared.Utilities;
using System;
using System.Collections.Generic;

namespace PilotApi.Shared.Configuration
{
	/// <inheritdoc/>>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	
	public class DataSourceConfiguration : ConfigurationBase, IDataSourceConfiguration
	{
		/// <inheritdoc/>>
		[JsonProperty]
		public string? DataSource { get; set; }

		/// <inheritdoc/>>
		public DataSourceTypes DataSourceEnum { get; set; } = DataSourceTypes.Unrecognized;

		/// <inheritdoc/>>
		[JsonProperty]
		public string? DataSourceName { get; set; }

		/// <inheritdoc/>>
		[JsonProperty]
		public string? DataSourceType { get; set; }

		/// <inheritdoc/>>
		[JsonProperty]
		public string? Schema { get; set; }

		/// <inheritdoc/>>
		public override string ToString()
		{
			return $"{nameof(this.Active)}={this.Active}, " +
				$"{nameof(this.DataSourceName)}={this.DataSourceName}, " +
				$"{nameof(this.DataSource)}={this.DataSource}, " +
				$"{nameof(this.DataSourceEnum)}={this.DataSourceEnum}, " +
				$"{nameof(this.DataSourceType)}={this.DataSourceType}, " +
				$"{nameof(this.Schema)}={this.Schema}";
		}

		/// <inheritdoc/>>
		public override void Validate(ref List<Exception> exceptions)
		{
			if (exceptions == null)
			{
				throw new ArgumentException($"The {nameof(exceptions)} argument is invalid ({this.GetType().Name})");
			}

			if (string.IsNullOrWhiteSpace(this.DataSource))
			{
				throw new ConfigurationException($"The {nameof(this.DataSource)} value is required and cannot be null or empty ({this.GetType().Name})");
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
				if (this.DataSourceEnum == DataSourceTypes.Unrecognized)
				{
					throw new ConfigurationException($"The {nameof(this.DataSourceType)} value is not valid.  " +
						$"Valid values include: {DataSourceUtilities.GetAvailableDataSourcesList()} ({this.GetType().Name})");
				}
			}

			if (string.IsNullOrWhiteSpace(this.Schema))
			{
				throw new ConfigurationException($"The {nameof(this.Schema)} value is required and cannot be null or empty ({this.GetType().Name})");
			}
		}
	}
}
