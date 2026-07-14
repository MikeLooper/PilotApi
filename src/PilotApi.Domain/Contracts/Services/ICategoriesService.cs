using PilotApi.Domain.Contracts.Base;
using PilotApi.Domain.Models.Dto;

namespace PilotApi.Domain.Contracts.Services
{
	/// <summary>
	/// An interface for a service that implements CRUD operations for the <see cref="CategoriesDto"/> type.
	/// </summary>
	public interface ICategoriesService : IServiceBase<CategoriesDto>
	{
	}
}
