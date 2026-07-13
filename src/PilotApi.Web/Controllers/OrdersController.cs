using Microsoft.AspNetCore.Mvc;
using PilotApi.Domain.Contracts.Services;
using PilotApi.Domain.Models.Dto;

namespace PilotApi.Web.Controllers
{
	[Route("Orders")]

	public class OrdersController : ControllerBase<OrdersDto>
	{
		public OrdersController(IOrdersService service)
			: base(service)
		{
		}
	}
}
