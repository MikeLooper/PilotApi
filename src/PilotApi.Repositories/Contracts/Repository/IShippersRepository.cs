using PilotApi.Domain.Contracts.Entities;
using PilotApi.Repositories.Contracts.Repository.Base;
using PilotApi.Repositories.Models.Base;

namespace PilotApi.Repositories.Contracts.Repository
{
	/// <summary>
	/// An interface for a repository that implements CRUD operations for the <see cref="IShippersEntity"/> type.
	/// </summary>
	public interface IShippersRepository: IRepositoryBase<ShippersEntity>
	{
	}
}
