using Microsoft.AspNetCore.Mvc;
using PilotApi.Domain.Contracts.Services;
using PilotApi.Domain.Models.Dto;

namespace PilotApi.Web.Controllers
{
	[Route("Customers")]

	public class CustomersController : ControllerBase<CustomersDto>
	{
		public CustomersController(ICustomersService service)
			: base(service)
		{
		}
	}
}
