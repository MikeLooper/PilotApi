using PilotApi.Domain.Contracts.Base;

namespace PilotApi.Domain.Models.Base
{
	public abstract class ConfigurationBase : IConfigurationBase
	{
		/// <summary>
		/// Gets or sets a flag that indicates whether this settigs object is active.
		/// </summary>
		public bool Active { get; set; } = true;

		public abstract void Validate();
	}
}
