using PilotApi.Shared.Contracts.Configuration.Base;

namespace PilotApi.Shared.Contracts.Configuration
{
	/// <summary>
	/// Configuration for OpenApi Contact settings.
	/// </summary>
	/// <example>
	/// Example configuration:
	/// <code>
	/// {
	///		"Email": "MikelLooper@gmail.com",
	///		"Name": "Michael Looper",
	///		"URL": "https://github.com/MikeLooper/PilotApi"
	/// }
	/// </code>
	/// </example>
	public interface IOpenApiContactConfiguration : IConfigurationBase
	{
		/// <summary>
		/// Gets or sets an contactEmail.
		/// </summary>
		string? Email { get; set; }

		/// <summary>
		/// Gets or sets the contact Name.
		/// </summary>
		string? Name { get; set; }

		/// <summary>
		/// Gets or sets the URL for the contact.
		/// </summary>
		string? URL { get; set; }
	}
}
