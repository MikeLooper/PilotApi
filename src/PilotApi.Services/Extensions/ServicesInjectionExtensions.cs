using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PilotApi.Domain.Contracts.Configuration;
using PilotApi.Domain.Contracts.DataStore;
using PilotApi.Domain.Contracts.Repository;
using PilotApi.Domain.Contracts.Services;
using PilotApi.Domain.Models.Dto;
using PilotApi.Repositories.Repositories;
using PilotApi.Services.Contracts;
using PilotApi.Services.DataStore;
using PilotApi.Services.Handlers;
using PilotApi.Services.Serices;
using System;

namespace PilotApi.Services.Extensions
{
	/// <summary>
	/// Extension methods for the services layer.
	/// </summary>
	public static class ServicesInjectionExtensions
	{
		/// <summary>
		/// Register injection objects.
		/// </summary>
		/// <param name="builder">
		/// A <see cref="WebApplicationBuilder"/> object.
		/// </param>
		/// <example>
		/// Example usage:
		/// <code>
		/// // app: create
		/// var webAppBuilder = WebApplication.CreateBuilder(args);
		/// 
		/// // custom: setup
		/// webAppBuilder.Services.ServicesRegistration();
		/// </code>
		/// </example>
		public static void ServicesRegistration(this WebApplicationBuilder builder)
		{
			if (builder == null)
			{
				throw new ArgumentException($"Invalid argument : {nameof(builder)}. "
					+ $"A valid object type of: '{typeof(WebApplicationBuilder)}' is needed to continue. ({nameof(ServicesInjectionExtensions)})");
			}

			// read configuration
			var applicationSettings = new ApplicationConfiguration();
			builder.Configuration.GetSection("Application").Bind(applicationSettings);
			applicationSettings.Validate();
			builder.Services.AddSingleton<IApplicationConfiguration>(applicationSettings);

			// register services
			builder.Services.AddSingleton<IDataStoreContext, DataStoreContext>();
			builder.Services.AddSingleton<IDataMapperHandler, DataMapperHandler>();

			builder.Services.AddTransient<ICategoriesRepository, CategoriesRepository>();
			builder.Services.AddTransient<ICustomersRepository, CustomersRepository>();
			builder.Services.AddTransient<IEmployeesRepository, EmployeesRepository>();
			builder.Services.AddTransient<IOrderDetailsRepository, OrderDetailsRepository>();
			builder.Services.AddTransient<IOrdersRepository, OrdersRepository>();
			builder.Services.AddTransient<IProductsRepository, ProductsRepository>();
			builder.Services.AddTransient<IShippersRepository, ShippersRepository>();
			builder.Services.AddTransient<ISuppliersRepository, SuppliersRepository>();

			builder.Services.AddTransient<ICategoriesService, CategoriesService>();
			builder.Services.AddTransient<ICustomersService, CustomersService>();
			builder.Services.AddTransient<IEmployeesService, EmployeesService>();
			builder.Services.AddTransient<IOrderDetailsService, OrderDetailsService>();
			builder.Services.AddTransient<IOrdersService, OrdersService>();
			builder.Services.AddTransient<IProductsService, ProductsService>();
			builder.Services.AddTransient<IShippersService, ShippersService>();
			builder.Services.AddTransient<ISuppliersService, SuppliersService>();
		}
	}
}
