using Microsoft.AspNetCore.Mvc;
using PilotApi.Domain.Contracts.Services;
using PilotApi.Domain.Models.Dto;

namespace PilotApi.Web.Controllers
{
	[Route("Categories")]

	public class CategoriesController : ControllerBase<CategoriesDto>
	{
		public CategoriesController(ICategoriesService service)
			: base(service)
		{
		}
	}
}
