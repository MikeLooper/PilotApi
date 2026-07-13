using Microsoft.Extensions.Logging;
using PilotApi.Domain.Contracts.Base;
using PilotApi.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PilotApi.Services.Base
{
	public abstract class ServiceBase<Dto, Entity> : IServiceBase<Dto> where Dto : IDtoBase where Entity : IEntityBase
	{
		protected ServiceBase(
			ILoggerFactory loggerFactory,
			IRepositoryBase<Entity> repository,
			IDataMapperHandler dataMapperHandler)
		{
			this.Logger = loggerFactory.CreateLogger(GetType());
			this.Repository = repository;
			this.DataMapperHandler = dataMapperHandler;
		}

		/// <summary>
		/// Gets the data mapper handler for mapping between DTOs and entities.
		/// </summary>
		protected IDataMapperHandler DataMapperHandler { get; }

		/// <summary>
		/// Gets the logger for logging information and errors.
		/// </summary>
		protected ILogger Logger { get; }

		/// <summary>
		/// Gets the repository for performing CRUD operations on entities.
		/// </summary>
		protected IRepositoryBase<Entity> Repository { get; }

		public async Task<bool> DeleteAsync(int id)
		{
			return await this.Repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<Dto>?> GetAllAsync()
		{
			var entities = await this.Repository.GetAllAsync();
			var mapped = await this.DataMapperHandler.MapEntityToDtoList<Dto, Entity>(entities);
			return mapped;
		}

		public async Task<Dto?> GetAsync(int id)
		{
			var entity = await this.Repository.GetAsync(id);
			var mapped = await this.DataMapperHandler.MapEntityToDto<Dto, Entity>(entity);
			return mapped;
		}

		public async Task<int> InsertAsync(Dto model)
		{
			if (model == null)
			{
				throw new ArgumentException($"Invalid argument: {nameof(model)}");
			}

			var mapped = await this.DataMapperHandler.MapDtoToEntity<Dto, Entity>(model);
			var result = await this.Repository.InsertAsync(mapped);
			return result;
		}

		public async Task<IEnumerable<Dto>?> QueryAsync(string query, object? parameters = null)
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				throw new ArgumentException($"Invalid argument: {nameof(query)}");
			}

			var entities = await this.Repository.QueryAsync(query, parameters);
			var mapped = await this.DataMapperHandler.MapEntityToDtoList<Dto, Entity>(entities);
			return mapped;
		}

		public async Task<Dto?> QueryFirstAsync(string query, object? parameters = null)
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				throw new ArgumentException($"Invalid argument: {nameof(query)}");
			}

			var entity = await this.Repository.QueryFirstAsync(query, parameters);
			var mapped = await this.DataMapperHandler.MapEntityToDto<Dto, Entity>(entity);
			return mapped;
		}

		public async Task<Dto?> QuerySingleAsync(string query, object? parameters = null)
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				throw new ArgumentException($"Invalid argument: {nameof(query)}");
			}

			var entity = await this.Repository.QuerySingleAsync(query, parameters);
			var mapped = await this.DataMapperHandler.MapEntityToDto<Dto, Entity>(entity);
			return mapped;
		}

		public async Task<bool> UpdateAsync(Dto model)
		{
			if (model == null)
			{
				throw new ArgumentException($"Invalid argument: {nameof(model)}");
			}

			var mapped = await this.DataMapperHandler.MapDtoToEntity<Dto, Entity>(model);
			var result = await this.Repository.UpdateAsync(mapped);
			return result;
		}
	}
}
