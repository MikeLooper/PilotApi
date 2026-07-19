using Newtonsoft.Json;
using PilotApi.Shared.Contracts.Configuration.Base;
using System;
using System.Collections.Generic;

namespace PilotApi.Shared.Configuration.Base
{
	/// <summary>
	/// A base class for configuration objects.
	/// </summary>
	public abstract class ConfigurationBase : IConfigurationBase
	{
		/// <inheritdoc/>
		[JsonProperty]
		public bool Active { get; set; } = true;

		/// <inheritdoc/>
		public abstract void Validate(ref List<Exception> exceptions);
	}
}
