namespace PilotApi.Domain.Contracts.Base
{
	public interface IConfigurationBase
	{
		/// <summary>
		/// Gets or sets a flag that indicates whether this settigs object is active.
		/// </summary>
		bool Active { get; set; }

		void Validate();
	}
}
