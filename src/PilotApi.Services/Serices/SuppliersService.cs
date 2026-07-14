using Microsoft.Extensions.Logging;
using PilotApi.Domain.Contracts.Entities;
using PilotApi.Domain.Contracts.Repository;
using PilotApi.Domain.Contracts.Services;
using PilotApi.Domain.Models.Dto;
using PilotApi.Services.Base;
using PilotApi.Services.Contracts;

namespace PilotApi.Services.Serices
{
	/// <summary>
	/// A service for accessing and manipulating Suppliers data in the data store.
	/// </summary>
	public class SuppliersService : ServiceBase<SuppliersDto, ISuppliersEntity>, ISuppliersService
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
