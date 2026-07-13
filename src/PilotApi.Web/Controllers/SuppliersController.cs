using Microsoft.AspNetCore.Mvc;
using PilotApi.Domain.Contracts.Services;
using PilotApi.Domain.Models.Dto;

namespace PilotApi.Web.Controllers
{
	[Route("Suppliers")]

	public class SuppliersController : ControllerBase<SuppliersDto>
	{
		public SuppliersController(ISuppliersService service)
			: base(service)
		{
		}
	}
}
