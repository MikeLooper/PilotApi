using PilotApi.Domain.Contracts.Entities;
using PilotApi.Repositories.Contracts.Repository.Base;
using PilotApi.Repositories.Models.Entities;

namespace PilotApi.Repositories.Contracts.Repository
{
	/// <summary>
	/// An interface for a repository that implements CRUD operations for the <see cref="IProductsEntity"/> type.
	/// </summary>
	public interface IProductsRepository: IRepositoryBase<ProductsEntity>
	{
	}
}
