using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PilotApi.Web.Controllers
{
	/// <summary>
	/// A controller for system processing.
	/// </summary>
	[ApiVersionNeutral]

	public class SystemController : SimpleControllerBase
	{
		/// <summary>
		/// Return an OK.
		/// </summary>
		/// <returns>
		/// A read only list of all DTO objects from the category table, or null if no objects exist.
		/// </returns>
		[HttpGet]
		[Route("healthcheck")]
		[ProducesResponseType<string>(StatusCodes.Status200OK)]
		public async Task<IActionResult?> GetAll()
		{
			return this.Ok("OK");
		}
	}
}
