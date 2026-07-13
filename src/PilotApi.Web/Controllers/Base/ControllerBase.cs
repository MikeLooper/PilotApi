using Microsoft.AspNetCore.Mvc;
using PilotApi.Domain.Contracts.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PilotApi.Web.Controllers
{
	[ApiController]
	public class ControllerBase<Dto> : Controller where Dto : IDtoBase
	{
		public ControllerBase(IServiceBase<Dto> service)
		{
			this.Service = service;
		}

		protected IServiceBase<Dto> Service { get; }

		[HttpGet]
		[Route("get-all")]
		public async Task<IReadOnlyList<Dto>?> GetAll()
		{
			var result = await this.Service.GetAllAsync();
			return result?.ToList().AsReadOnly();
		}

		[HttpGet]
		[Route("get")]
		public async Task<Dto?> Get(int id)
		{
			return await this.Service.GetAsync(id);
		}

		[HttpPost]
		[Route("add")]
		public async Task Add(Dto model)
		{
			await this.Service.InsertAsync(model);
		}

		[HttpPost]
		[Route("update")]
		public async Task Update(Dto entity)
		{
			await this.Service.UpdateAsync(entity);
		}

		[HttpPost]
		[Route("delete")]
		public async Task Delete(int id)
		{
			await this.Service.DeleteAsync(id);
		}
	}
}
