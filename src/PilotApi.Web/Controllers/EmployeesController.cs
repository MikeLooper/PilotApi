using Microsoft.AspNetCore.Mvc;
using PilotApi.Domain.Contracts.Services;
using PilotApi.Domain.Models.Dto;

namespace PilotApi.Web.Controllers
{
	[Route("Employees")]

	public class EmployeesController : ControllerBase<EmployeesDto>
	{
		public EmployeesController(IEmployeesService service)
			: base(service)
		{
		}
	}
}
