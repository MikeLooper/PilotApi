using Microsoft.Extensions.Logging;
using PilotApi.Domain.Contracts.Base;
using PilotApi.Domain.Contracts.Services.Base;
using PilotApi.Repositories.Contracts.Repository.Base;
using PilotApi.Repositories.Models.Base;
using PilotApi.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PilotApi.Services.Services.Base
{
	public abstract class ServiceBase<TDto, TEntity> : IServiceBase<TDto> where TDto : IDtoBase where TEntity : EntityBase
	{
		/// <summary>
		/// Instantiates a new instance of the <see cref="ServiceBase{Dto, Entity}"/> class.
		/// </summary>
		/// <param name="loggerFactory">
		/// A logger factory for creating loggers.
		/// </param>
		/// <param name="repository">
		/// A repository for performing CRUD operations on entities.
		/// </param>
		/// <param name="dataMapperHandler">
		/// A data mapper handler for mapping between DTOs and entities.
		/// </param>
		protected ServiceBase(
			ILoggerFactory loggerFactory,
			IRepositoryBase<TEntity> repository,
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
		protected IRepositoryBase<TEntity> Repository { get; }

		/// <inheritdoc/>>
		public async Task<bool> DeleteAsync<TType>(params TType[] ids)
		{
			if (ids.Length < 1)
			{
				throw new ArgumentException($"The supplied ids list ({ids} must contain at least one item ({this.GetType().Name})");
			}

			return await this.Repository.DeleteAsync(ids);
		}

		/// <inheritdoc/>>
		public async Task<List<TDto>?> GetAllAsync()
		{
			var entities = await this.Repository.GetAllAsync();
			var mapped = await this.DataMapperHandler.MapEntityToDtoList<TDto, TEntity>(entities);
			return mapped?.ToList();
		}

		/// <inheritdoc/>>
		public async Task<TDto?> GetByIdAsync<TType>(params TType[] ids)
		{
			if (ids.Length < 1)
			{
				throw new ArgumentException($"The supplied ids list ({ids} must contain at least one item ({this.GetType().Name})");
			}

			var entity = await this.Repository.GetAsync(ids);
			var mapped = await this.DataMapperHandler.MapEntityToDto<TDto, TEntity>(entity);
			return mapped;
		}

		/// <inheritdoc/>>
		public async Task<int> InsertAsync(TDto model)
		{
			if (model == null)
			{
				throw new ArgumentException($"Invalid argument: {nameof(model)}");
			}

			var mapped = await this.DataMapperHandler.MapDtoToEntity<TDto, TEntity>(model);
			var result = await this.Repository.InsertAsync(mapped);
			return result;
		}

		/// <inheritdoc/>>
		public async Task<List<TDto>?> QueryAsync(string query, object? parameters = null)
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				throw new ArgumentException($"Invalid argument: {nameof(query)}");
			}

			var entities = await this.Repository.QueryAsync(query, parameters);
			var mapped = await this.DataMapperHandler.MapEntityToDtoList<TDto, TEntity>(entities);
			return mapped?.ToList();
		}

		/// <inheritdoc/>>
		public async Task<TDto?> QueryFirstAsync(string query, object? parameters = null)
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				throw new ArgumentException($"Invalid argument: {nameof(query)}");
			}

			var entity = await this.Repository.QueryFirstAsync(query, parameters);
			var mapped = await this.DataMapperHandler.MapEntityToDto<TDto, TEntity>(entity);
			return mapped;
		}

		/// <inheritdoc/>>
		public async Task<TDto?> QuerySingleAsync(string query, object? parameters = null)
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				throw new ArgumentException($"Invalid argument: {nameof(query)}");
			}

			var entity = await this.Repository.QuerySingleAsync(query, parameters);
			var mapped = await this.DataMapperHandler.MapEntityToDto<TDto, TEntity>(entity);
			return mapped;
		}

		/// <inheritdoc/>>
		public async Task<bool> UpdateAsync(TDto model)
		{
			if (model == null)
			{
				throw new ArgumentException($"Invalid argument: {nameof(model)}");
			}

			var mapped = await this.DataMapperHandler.MapDtoToEntity<TDto, TEntity>(model);
			var result = await this.Repository.UpdateAsync(mapped);
			return result;
		}
	}
}
