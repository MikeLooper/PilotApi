using Microsoft.Extensions.Logging;
using PilotApi.Domain.Contracts.Services;
using PilotApi.Domain.Models.Dto;
using PilotApi.Repositories.Contracts.Repository;
using PilotApi.Repositories.Models.Entities;
using PilotApi.Services.Contracts;
using PilotApi.Services.Services.Base;

namespace PilotApi.Services.Services
{
	/// <summary>
	/// A service for accessing and manipulating Orders data in the data store.
	/// </summary>
	public class OrdersService : ServiceBase<OrdersDto, OrdersEntity>, IOrdersService
	{

		/// <summary>
		/// Instantiate a <see cref="OrdersService"/> object.
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
		public OrdersService(
			ILoggerFactory loggerFactory,
			IOrdersRepository repository,
			IDataMapperHandler dataMapperHandler)
			: base(loggerFactory, repository, dataMapperHandler)
		{
		}
	}
}
