using Microsoft.AspNetCore.Mvc;
using PilotApi.Domain.Contracts.Services;
using PilotApi.Domain.Models.Dto;

namespace PilotApi.Web.Controllers
{
	[Route("Shippers")]

	public class ShippersController : ControllerBase<ShippersDto>
	{
		public ShippersController(IShippersService service)
			: base(service)
		{
		}
	}
}
