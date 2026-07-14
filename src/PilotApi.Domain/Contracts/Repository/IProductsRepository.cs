using PilotApi.Domain.Contracts.Base;
using PilotApi.Domain.Contracts.Entities;

namespace PilotApi.Domain.Contracts.Repository
{
	/// <summary>
	/// An interface for a repository that implements CRUD operations for the <see cref="IProductsEntity"/> type.
	/// </summary>
	public interface IProductsRepository: IRepositoryBase<IProductsEntity>
	{
	}
}
