using PilotApi.Domain.Contracts.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PilotApi.Services.Contracts
{
	public interface IDataMapperHandler
	{
		Task<IEnumerable<Dto>?> MapEntityToDtoList<Dto, Entity>(IEnumerable<Entity>? entities) where Dto : IDtoBase where Entity : IEntityBase;

		Task<Dto?> MapEntityToDto<Dto, Entity>(Entity? entity) where Dto : IDtoBase where Entity : IEntityBase;

		Task<Entity?> MapDtoToEntity<Dto, Entity>(Dto? dto) where Dto : IDtoBase where Entity : IEntityBase;
	}
}
