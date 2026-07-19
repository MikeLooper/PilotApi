using PilotApi.Domain.Contracts.Services.Base;
using PilotApi.Domain.Models.Dto;

namespace PilotApi.Domain.Contracts.Services
{
	/// <summary>
	/// An interface for a service that implements CRUD operations for the <see cref="SuppliersDto"/> type.
	/// </summary>
	public interface ISuppliersService : IServiceBase<SuppliersDto>
	{
	}
}
