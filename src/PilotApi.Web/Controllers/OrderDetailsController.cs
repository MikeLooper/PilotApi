using Microsoft.AspNetCore.Mvc;
using PilotApi.Domain.Contracts.Services;
using PilotApi.Domain.Models.Dto;

namespace PilotApi.Web.Controllers
{
	[Route("OrderDetails")]

	public class OrderDetailsController : ControllerBase<OrderDetailsDto>
	{
		public OrderDetailsController(IOrderDetailsService service)
			: base(service)
		{
		}
	}
}
