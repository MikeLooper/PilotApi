using Microsoft.AspNetCore.Mvc;
using PilotApi.Domain.Contracts.Services;
using PilotApi.Domain.Models.Dto;

namespace PilotApi.Web.Controllers
{
	[Route("Products")]

	public class ProductsController : ControllerBase<ProductsDto>
	{
		public ProductsController(IProductsService service)
			: base(service)
		{
		}
	}
}
