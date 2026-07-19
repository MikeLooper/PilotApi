using PilotApi.Shared.Configuration;
using PilotApi.Shared.Contracts.Configuration.Base;

namespace PilotApi.Shared.Contracts.Configuration
{
	/// <summary>
	/// Configuration for OpenApi settings.
	/// </summary>
	/// <example>
	/// Example configuration:
	/// <code>
	/// {
	///		"Contact": {
	///			"Email": "MikelLooper@gmail.com",
	///			"Name": "Michael Looper",
	///			"URL": "https://github.com/MikeLooper/PilotApi"
	///		},
	///		"Description": "A proof of concept API to explore best-practices and new ideas",
	///		"License": "MIT",
	///		"Summary": "Proof of concept API",
	///		"Title": "PilotApi",
	///		"Version":  "0.1.1"
	/// }
	/// </code>
	/// </example>
	public interface IOpenApiConfiguration : IConfigurationBase
	{
		/// <summary>
		/// Gets or sets a Contact object.
		/// </summary>
		OpenApiContactConfiguration? Contact { get; set; }

		/// <summary>
		/// Gets or sets the OpenAPI Description.
		/// </summary>
		string? Description { get; set; }

		/// <summary>
		/// Gets or sets the OpenAPI License.
		/// </summary>
		string? License { get; set; }

		/// <summary>
		/// Gets or sets the OpenAPI Summary.
		/// </summary>
		string? Summary { get; set; }

		/// <summary>
		/// Gets or sets the OpenAPI Title.
		/// </summary>
		string? Title { get; set; }

		/// <summary>
		/// Gets or sets the OpenAPI Version.
		/// </summary>
		string? Version { get; set; }
	}
}
