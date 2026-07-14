using PilotApi.Domain.Contracts.Base;
using PilotApi.Domain.Models.Dto;
using PilotApi.Repositories.Models.Base;
using PilotApi.Repositories.Models.Entities;
using PilotApi.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PilotApi.Services.Handlers
{
	public class DataMapperHandler : IDataMapperHandler
	{
		/// <inheritdoc/>>
		public async Task<TEntity?> MapDtoToEntity<TDto, TEntity>(TDto? dto)
			where TDto : IDtoBase
			where TEntity : IEntityBase
		{
			if (dto == null)
			{
				return default;
			}

			(bool convertSuccess, TEntity? value) = CategoriesDtoConverter<TDto, TEntity>(dto);
			if (convertSuccess)
			{
				return value;
			}

			(convertSuccess, value) = CustomersDtoConverter<TDto, TEntity>(dto);
			if (convertSuccess)
			{
				return value;
			}

			(convertSuccess, value) = EmployeesDtoConverter<TDto, TEntity>(dto);
			if (convertSuccess)
			{
				return value;
			}

			(convertSuccess, value) = OrderDetailsDtoConverter<TDto, TEntity>(dto);
			if (convertSuccess)
			{
				return value;
			}

			(convertSuccess, value) = OrdersDtoConverter<TDto, TEntity>(dto);
			if (convertSuccess)
			{
				return value;
			}

			(convertSuccess, value) = ProductsDtoConverter<TDto, TEntity>(dto);
			if (convertSuccess)
			{
				return value;
			}

			(convertSuccess, value) = ShippersDtoConverter<TDto, TEntity>(dto);
			if (convertSuccess)
			{
				return value;
			}

			(convertSuccess, value) = SuppliersDtoConverter<TDto, TEntity>(dto);
			if (convertSuccess)
			{
				return value;
			}

			return default;
		}

		/// <inheritdoc/>>
		public async Task<TDto?> MapEntityToDto<TDto, TEntity>(TEntity? entity)
			where TDto : IDtoBase
			where TEntity : IEntityBase
		{
			if (entity != null)
			{
				(bool convertSuccess, TDto? value) = CategoriesEntityConverter<TDto, TEntity>(entity);
				if (convertSuccess)
				{
					return value;
				}

				(convertSuccess, value) = CustomersEntityConverter<TDto, TEntity>(entity);
				if (convertSuccess)
				{
					return value;
				}

				(convertSuccess, value) = EmployeesEntityConverter<TDto, TEntity>(entity);
				if (convertSuccess)
				{
					return value;
				}

				(convertSuccess, value) = OrderDetailsEntityConverter<TDto, TEntity>(entity);
				if (convertSuccess)
				{
					return value;
				}

				(convertSuccess, value) = OrdersEntityConverter<TDto, TEntity>(entity);
				if (convertSuccess)
				{
					return value;
				}

				(convertSuccess, value) = ProductsEntityConverter<TDto, TEntity>(entity);
				if (convertSuccess)
				{
					return value;
				}

				(convertSuccess, value) = ShippersEntityConverter<TDto, TEntity>(entity);
				if (convertSuccess)
				{
					return value;
				}

				(convertSuccess, value) = SuppliersEntityConverter<TDto, TEntity>(entity);
				if (convertSuccess)
				{
					return value;
				}

				return default;
			}

			return default;
		}

		/// <inheritdoc/>>
		public async Task<IEnumerable<TDto>?> MapEntityToDtoList<TDto, TEntity>(IEnumerable<TEntity>? entities)
			where TDto : IDtoBase
			where TEntity : IEntityBase
		{
			if (entities == null)
			{
				return default;
			}

			var dtoList = new List<TDto>();
			foreach (var entity in entities)
			{
				var dto = await MapEntityToDto<TDto, TEntity>(entity);
				if (dto != null)
				{
					dtoList.Add(dto);
				}
			}

			return dtoList;
		}

		/// <summary>
		/// Converts a Dto to an Entity. Returns a tuple indicating success and the converted value.
		/// </summary>
		/// <typeparam name="Dto">
		/// 
		/// </typeparam>
		/// <typeparam name="Entity">
		/// 
		/// </typeparam>
		/// <param name="sourceDto">
		/// 
		/// </param>
		/// <returns>
		/// 
		/// </returns>
		protected (bool convertSuccess, TEntity? value) CategoriesDtoConverter<TDto, TEntity>(TDto sourceDto)
			where TDto : IDtoBase
			where TEntity : IEntityBase
		{
			var asCategories = sourceDto as CategoriesDto;
			if (asCategories != null)
			{
				var newEntity = new CategoriesEntity
				{
					CategoryID = asCategories.CategoryID,
					CategoryName = asCategories.CategoryName,
					Description = asCategories.Description,
					Picture = asCategories.Picture
				};

				return (convertSuccess: true, value: (TEntity)(dynamic)newEntity);
			}

			return (convertSuccess: false, value: default);
		}

		/// <summary>
		/// Converts an Entity to a Dto. Returns a tuple indicating success and the converted value.
		/// </summary>
		/// <typeparam name="Dto"></typeparam>
		/// <typeparam name="Entity"></typeparam>
		/// <param name="sourceEntity"></param>
		/// <returns></returns>
		protected (bool convertSuccess, TDto? value) CategoriesEntityConverter<TDto, TEntity>(TEntity sourceEntity)
			where TDto : IDtoBase
			where TEntity : IEntityBase
		{
			var asCategories = sourceEntity as CategoriesEntity;
			if (asCategories != null)
			{
				var newDto = new CategoriesDto
				{
					CategoryID = asCategories.CategoryID,
					CategoryName = asCategories.CategoryName,
					Description = asCategories.Description,
					Picture = asCategories.Picture
				};

				return (convertSuccess: true, value: (TDto)(dynamic)newDto);
			}

			return (convertSuccess: false, value: default);
		}

		/// <summary>
		/// Converts a Dto to an Entity. Returns a tuple indicating success and the converted value.
		/// </summary>
		/// <typeparam name="Dto"></typeparam>
		/// <typeparam name="Entity"></typeparam>
		/// <param name="sourceDto"></param>
		/// <returns></returns>
		protected (bool convertSuccess, TEntity? value) CustomersDtoConverter<TDto, TEntity>(TDto sourceDto)
					where TDto : IDtoBase
			where TEntity : IEntityBase
		{
			var asCustomers = sourceDto as CustomersDto;
			if (asCustomers != null)
			{
				var newEntity = new CustomersEntity
				{
					CustomerID = asCustomers.CustomerID,
					CompanyName = asCustomers.CompanyName,
					ContactName = asCustomers.ContactName,
					ContactTitle = asCustomers.ContactTitle,
					Address = asCustomers.Address,
					City = asCustomers.City,
					Region = asCustomers.Region,
					PostalCode = asCustomers.PostalCode,
					Country = asCustomers.Country,
					Phone = asCustomers.Phone,
					Fax = asCustomers.Fax
				};

				return (convertSuccess: true, value: (TEntity)(dynamic)newEntity);
			}

			return (convertSuccess: false, value: default);
		}

		/// <summary>
		/// Converts an Entity to a Dto. Returns a tuple indicating success and the converted value.
		/// </summary>
		/// <typeparam name="Dto"></typeparam>
		/// <typeparam name="Entity"></typeparam>
		/// <param name="sourceEntity"></param>
		/// <returns></returns>
		protected (bool convertSuccess, TDto? value) CustomersEntityConverter<TDto, TEntity>(TEntity sourceEntity)
			where TDto : IDtoBase
			where TEntity : IEntityBase
		{
			var asCustomers = sourceEntity as CustomersEntity;
			if (asCustomers != null)
			{
				var newDto = new CustomersDto
				{
					CustomerID = asCustomers.CustomerID,
					CompanyName = asCustomers.CompanyName,
					ContactName = asCustomers.ContactName,
					ContactTitle = asCustomers.ContactTitle,
					Address = asCustomers.Address,
					City = asCustomers.City,
					Region = asCustomers.Region,
					PostalCode = asCustomers.PostalCode,
					Country = asCustomers.Country,
					Phone = asCustomers.Phone,
					Fax = asCustomers.Fax
				};

				return (convertSuccess: true, value: (TDto)(dynamic)newDto);
			}

			return (convertSuccess: false, value: default);
		}

		/// <summary>
		/// Converts a Dto to an Entity. Returns a tuple indicating success and the converted value.
		/// </summary>
		/// <typeparam name="Dto"></typeparam>
		/// <typeparam name="Entity"></typeparam>
		/// <param name="sourceDto"></param>
		/// <returns></returns>
		protected (bool convertSuccess, TEntity? value) EmployeesDtoConverter<TDto, TEntity>(TDto sourceDto)
					where TDto : IDtoBase
			where TEntity : IEntityBase
		{
			var asEmployees = sourceDto as EmployeesDto;
			if (asEmployees != null)
			{
				var newEntity = new EmployeesEntity
				{
					Address = asEmployees.Address,
					BirthDate = asEmployees.BirthDate,
					City = asEmployees.City,
					Country = asEmployees.Country,
					EmployeeID = asEmployees.EmployeeID,
					Extension = asEmployees.Extension,
					FirstName = asEmployees.FirstName,
					HireDate = asEmployees.HireDate,
					HomePhone = asEmployees.HomePhone,
					LastName = asEmployees.LastName,
					Notes = asEmployees.Notes,
					Photo = asEmployees.Photo,
					PhotoPath = asEmployees.PhotoPath,
					PostalCode = asEmployees.PostalCode,
					Region = asEmployees.Region,
					ReportsTo = asEmployees.ReportsTo,
					Title = asEmployees.Title,
					TitleOfCourtesy = asEmployees.TitleOfCourtesy
				};

				return (convertSuccess: true, value: (TEntity)(dynamic)newEntity);
			}

			return (convertSuccess: false, value: default);
		}

		/// <summary>
		/// Converts an Entity to a Dto. Returns a tuple indicating success and the converted value.
		/// </summary>
		/// <typeparam name="Dto"></typeparam>
		/// <typeparam name="Entity"></typeparam>
		/// <param name="sourceEntity"></param>
		/// <returns></returns>
		protected (bool convertSuccess, TDto? value) EmployeesEntityConverter<TDto, TEntity>(TEntity sourceEntity)
			where TDto : IDtoBase
			where TEntity : IEntityBase
		{
			var asEmployees = sourceEntity as EmployeesEntity;
			if (asEmployees != null)
			{
				var newDto = new EmployeesDto
				{
					Address = asEmployees.Address,
					BirthDate = asEmployees.BirthDate,
					City = asEmployees.City,
					Country = asEmployees.Country,
					EmployeeID = asEmployees.EmployeeID,
					Extension = asEmployees.Extension,
					FirstName = asEmployees.FirstName,
					HireDate = asEmployees.HireDate,
					HomePhone = asEmployees.HomePhone,
					LastName = asEmployees.LastName,
					Notes = asEmployees.Notes,
					Photo = asEmployees.Photo,
					PhotoPath = asEmployees.PhotoPath,
					PostalCode = asEmployees.PostalCode,
					Region = asEmployees.Region,
					ReportsTo = asEmployees.ReportsTo,
					Title = asEmployees.Title,
					TitleOfCourtesy = asEmployees.TitleOfCourtesy
				};

				return (convertSuccess: true, value: (TDto)(dynamic)newDto);
			}

			return (convertSuccess: false, value: default);
		}

		/// <summary>
		/// Converts a Dto to an Entity. Returns a tuple indicating success and the converted value.
		/// </summary>
		/// <typeparam name="Dto"></typeparam>
		/// <typeparam name="Entity"></typeparam>
		/// <param name="sourceDto"></param>
		/// <returns></returns>
		protected (bool convertSuccess, TEntity? value) OrderDetailsDtoConverter<TDto, TEntity>(TDto sourceDto)
					where TDto : IDtoBase
			where TEntity : IEntityBase
		{
			var asOrderDetails = sourceDto as OrderDetailsDto;
			if (asOrderDetails != null)
			{
				var newEntity = new OrderDetailsEntity
				{
					OrderID = asOrderDetails.OrderID,
					ProductID = asOrderDetails.ProductID,
					UnitPrice = asOrderDetails.UnitPrice,
					Quantity = asOrderDetails.Quantity,
					Discount = asOrderDetails.Discount
				};

				return (convertSuccess: true, value: (TEntity)(dynamic)newEntity);
			}

			return (convertSuccess: false, value: default);
		}

		/// <summary>
		/// Converts an Entity to a Dto. Returns a tuple indicating success and the converted value.
		/// </summary>
		/// <typeparam name="Dto"></typeparam>
		/// <typeparam name="Entity"></typeparam>
		/// <param name="sourceEntity"></param>
		/// <returns></returns>
		protected (bool convertSuccess, TDto? value) OrderDetailsEntityConverter<TDto, TEntity>(TEntity sourceEntity)
			where TDto : IDtoBase
			where TEntity : IEntityBase
		{
			var asOrderDetails = sourceEntity as OrderDetailsEntity;
			if (asOrderDetails != null)
			{
				var newDto = new OrderDetailsDto
				{
					OrderID = asOrderDetails.OrderID,
					ProductID = asOrderDetails.ProductID,
					UnitPrice = asOrderDetails.UnitPrice,
					Quantity = asOrderDetails.Quantity,
					Discount = asOrderDetails.Discount
				};

				return (convertSuccess: true, value: (TDto)(dynamic)newDto);
			}

			return (convertSuccess: false, value: default);
		}

		/// <summary>
		/// Converts a Dto to an Entity. Returns a tuple indicating success and the converted value.
		/// </summary>
		/// <typeparam name="Dto"></typeparam>
		/// <typeparam name="Entity"></typeparam>
		/// <param name="sourceDto"></param>
		/// <returns></returns>
		protected (bool convertSuccess, TEntity? value) OrdersDtoConverter<TDto, TEntity>(TDto sourceDto)
					where TDto : IDtoBase
			where TEntity : IEntityBase
		{
			var asOrders = sourceDto as OrdersDto;
			if (asOrders != null)
			{
				var newEntity = new OrdersEntity
				{
					OrderID = asOrders.OrderID,
					CustomerID = asOrders.CustomerID,
					EmployeeID = asOrders.EmployeeID,
					OrderDate = asOrders.OrderDate,
					RequiredDate = asOrders.RequiredDate,
					ShippedDate = asOrders.ShippedDate,
					ShipVia = asOrders.ShipVia,
					Freight = asOrders.Freight,
					ShipName = asOrders.ShipName,
					ShipAddress = asOrders.ShipAddress,
					ShipCity = asOrders.ShipCity,
					ShipRegion = asOrders.ShipRegion,
					ShipPostalCode = asOrders.ShipPostalCode,
					ShipCountry = asOrders.ShipCountry
				};

				return (convertSuccess: true, value: (TEntity)(dynamic)newEntity);
			}

			return (convertSuccess: false, value: default);
		}

		/// <summary>
		/// Converts an Entity to a Dto. Returns a tuple indicating success and the converted value.
		/// </summary>
		/// <typeparam name="Dto"></typeparam>
		/// <typeparam name="Entity"></typeparam>
		/// <param name="sourceEntity"></param>
		/// <returns></returns>
		protected (bool convertSuccess, TDto? value) OrdersEntityConverter<TDto, TEntity>(TEntity sourceEntity)
			where TDto : IDtoBase
			where TEntity : IEntityBase
		{
			var asOrders = sourceEntity as OrdersEntity;
			if (asOrders != null)
			{
				var newDto = new OrdersDto
				{
					OrderID = asOrders.OrderID,
					CustomerID = asOrders.CustomerID,
					EmployeeID = asOrders.EmployeeID,
					OrderDate = asOrders.OrderDate,
					RequiredDate = asOrders.RequiredDate,
					ShippedDate = asOrders.ShippedDate,
					ShipVia = asOrders.ShipVia,
					Freight = asOrders.Freight,
					ShipName = asOrders.ShipName,
					ShipAddress = asOrders.ShipAddress,
					ShipCity = asOrders.ShipCity,
					ShipRegion = asOrders.ShipRegion,
					ShipPostalCode = asOrders.ShipPostalCode,
					ShipCountry = asOrders.ShipCountry
				};

				return (convertSuccess: true, value: (TDto)(dynamic)newDto);
			}

			return (convertSuccess: false, value: default);
		}

		/// <summary>
		/// Converts a Dto to an Entity. Returns a tuple indicating success and the converted value.
		/// </summary>
		/// <typeparam name="Dto"></typeparam>
		/// <typeparam name="Entity"></typeparam>
		/// <param name="sourceDto"></param>
		/// <returns></returns>
		protected (bool convertSuccess, TEntity? value) ProductsDtoConverter<TDto, TEntity>(TDto sourceDto)
					where TDto : IDtoBase
			where TEntity : IEntityBase
		{
			var asProducts = sourceDto as ProductsDto;
			if (asProducts != null)
			{
				var newEntity = new ProductsEntity
				{
					ProductID = asProducts.ProductID,
					ProductName = asProducts.ProductName,
					SupplierID = asProducts.SupplierID,
					CategoryID = asProducts.CategoryID,
					QuantityPerUnit = asProducts.QuantityPerUnit,
					UnitPrice = asProducts.UnitPrice,
					UnitsInStock = asProducts.UnitsInStock,
					UnitsOnOrder = asProducts.UnitsOnOrder,
					ReorderLevel = asProducts.ReorderLevel,
					Discontinued = asProducts.Discontinued
				};

				return (convertSuccess: true, value: (TEntity)(dynamic)newEntity);
			}

			return (convertSuccess: false, value: default);
		}

		/// <summary>
		/// Converts an Entity to a Dto. Returns a tuple indicating success and the converted value.
		/// </summary>
		/// <typeparam name="Dto"></typeparam>
		/// <typeparam name="Entity"></typeparam>
		/// <param name="sourceEntity"></param>
		/// <returns></returns>
		protected (bool convertSuccess, TDto? value) ProductsEntityConverter<TDto, TEntity>(TEntity sourceEntity)
			where TDto : IDtoBase
			where TEntity : IEntityBase
		{
			var asProducts = sourceEntity as ProductsDto;
			if (asProducts != null)
			{
				var newDto = new ProductsEntity
				{
					ProductID = asProducts.ProductID,
					ProductName = asProducts.ProductName,
					SupplierID = asProducts.SupplierID,
					CategoryID = asProducts.CategoryID,
					QuantityPerUnit = asProducts.QuantityPerUnit,
					UnitPrice = asProducts.UnitPrice,
					UnitsInStock = asProducts.UnitsInStock,
					UnitsOnOrder = asProducts.UnitsOnOrder,
					ReorderLevel = asProducts.ReorderLevel,
					Discontinued = asProducts.Discontinued
				};

				return (convertSuccess: true, value: (TDto)(dynamic)newDto);
			}

			return (convertSuccess: false, value: default);
		}

		/// <summary>
		/// Converts a Dto to an Entity. Returns a tuple indicating success and the converted value.
		/// </summary>
		/// <typeparam name="Dto"></typeparam>
		/// <typeparam name="Entity"></typeparam>
		/// <param name="sourceDto"></param>
		/// <returns></returns>
		protected (bool convertSuccess, TEntity? value) ShippersDtoConverter<TDto, TEntity>(TDto sourceDto)
					where TDto : IDtoBase
			where TEntity : IEntityBase
		{
			var asShippers = sourceDto as ShippersDto;
			if (asShippers != null)
			{
				var newEntity = new ShippersEntity
				{
					ShipperID = asShippers.ShipperID,
					CompanyName = asShippers.CompanyName,
					Phone = asShippers.Phone
				};

				return (convertSuccess: true, value: (TEntity)(dynamic)newEntity);
			}

			return (convertSuccess: false, value: default);
		}

		/// <summary>
		/// Converts an Entity to a Dto. Returns a tuple indicating success and the converted value.
		/// </summary>
		/// <typeparam name="Dto"></typeparam>
		/// <typeparam name="Entity"></typeparam>
		/// <param name="sourceEntity"></param>
		/// <returns></returns>
		protected (bool convertSuccess, TDto? value) ShippersEntityConverter<TDto, TEntity>(TEntity sourceEntity)
			where TDto : IDtoBase
			where TEntity : IEntityBase
		{
			var asShippers = sourceEntity as ShippersEntity;
			if (asShippers != null)
			{
				var newDto = new ShippersDto
				{
					ShipperID = asShippers.ShipperID,
					CompanyName = asShippers.CompanyName,
					Phone = asShippers.Phone
				};

				return (convertSuccess: true, value: (TDto)(dynamic)newDto);
			}

			return (convertSuccess: false, value: default);
		}

		/// <summary>
		/// Converts a Dto to an Entity. Returns a tuple indicating success and the converted value.
		/// </summary>
		/// <typeparam name="Dto"></typeparam>
		/// <typeparam name="Entity"></typeparam>
		/// <param name="sourceDto"></param>
		/// <returns></returns>
		protected (bool convertSuccess, TEntity? value) SuppliersDtoConverter<TDto, TEntity>(TDto sourceDto)
																							where TDto : IDtoBase
			where TEntity : IEntityBase
		{
			var asSuppliers = sourceDto as SuppliersDto;
			if (asSuppliers != null)
			{
				var newEntity = new SuppliersEntity
				{
					SupplierID = asSuppliers.SupplierID,
					CompanyName = asSuppliers.CompanyName,
					ContactName = asSuppliers.ContactName,
					ContactTitle = asSuppliers.ContactTitle,
					Address = asSuppliers.Address,
					City = asSuppliers.City,
					Region = asSuppliers.Region,
					PostalCode = asSuppliers.PostalCode,
					Country = asSuppliers.Country,
					Phone = asSuppliers.Phone,
					Fax = asSuppliers.Fax,
					HomePage = asSuppliers.HomePage
				};

				return (convertSuccess: true, value: (TEntity)(dynamic)newEntity);
			}

			return (convertSuccess: false, value: default);
		}

		/// <summary>
		/// Converts a Dto to an Entity. Returns a tuple indicating success and the converted value. 
		/// </summary>
		/// <typeparam name="Dto"></typeparam>
		/// <typeparam name="Entity"></typeparam>
		/// <param name="sourceEntity"></param>
		/// <returns></returns>
		protected (bool convertSuccess, TDto? value) SuppliersEntityConverter<TDto, TEntity>(TEntity sourceEntity)
																					where TDto : IDtoBase
			where TEntity : IEntityBase
		{
			var asSuppliers = sourceEntity as SuppliersEntity;
			if (asSuppliers != null)
			{
				var newDto = new SuppliersDto
				{
					SupplierID = asSuppliers.SupplierID,
					CompanyName = asSuppliers.CompanyName,
					ContactName = asSuppliers.ContactName,
					ContactTitle = asSuppliers.ContactTitle,
					Address = asSuppliers.Address,
					City = asSuppliers.City,
					Region = asSuppliers.Region,
					PostalCode = asSuppliers.PostalCode,
					Country = asSuppliers.Country,
					Phone = asSuppliers.Phone,
					Fax = asSuppliers.Fax,
					HomePage = asSuppliers.HomePage
				};

				return (convertSuccess: true, value: (TDto)(dynamic)newDto);
			}

			return (convertSuccess: false, value: default);
		}
	}
}
