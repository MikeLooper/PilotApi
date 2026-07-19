using Microsoft.Extensions.Logging;
using PilotApi.Domain.Contracts.Services;
using PilotApi.Domain.Models.Dto;
using PilotApi.Repositories.Contracts.Repository;
using PilotApi.Repositories.Models.Base;
using PilotApi.Services.Contracts;
using PilotApi.Services.Services.Base;

namespace PilotApi.Services.Services
{
	/// <summary>
	/// A service for accessing and manipulating Shippers data in the data store.
	/// </summary>
	public class ShippersService : ServiceBase<ShippersDto, ShippersEntity>, IShippersService
	{

		/// <summary>
		/// Instantiate a <see cref="ShippersService"/> object.
		/// </summary>
		/// <param name="loggerFactory">
		/// A logger factory object.
		/// </param>
		/// <param name="repository">
		/// A repository object.
		/// </param>
		/// <param name="dataMapperHandler">
		/// A data mapper handler object.
		/// </param>
		public ShippersService(
			ILoggerFactory loggerFactory,
			IShippersRepository repository,
			IDataMapperHandler dataMapperHandler)
			: base(loggerFactory, repository, dataMapperHandler)
		{
		}
	}
}
