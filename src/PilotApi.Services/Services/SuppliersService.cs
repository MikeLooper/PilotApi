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
	/// A service for accessing and manipulating Suppliers data in the data store.
	/// </summary>
	public class SuppliersService : ServiceBase<SuppliersDto, SuppliersEntity>, ISuppliersService
	{

		/// <summary>
		/// Instantiate a <see cref="SuppliersService"/> object.
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
		public SuppliersService(
			ILoggerFactory loggerFactory,
			ISuppliersRepository repository,
			IDataMapperHandler dataMapperHandler)
			: base(loggerFactory, repository, dataMapperHandler)
		{
		}
	}
}
