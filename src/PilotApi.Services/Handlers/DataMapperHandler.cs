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
		public async Task<Entity?> MapDtoToEntity<Dto, Entity>(Dto? dto)
			where Dto : IDtoBase
			where Entity : IEntityBase
		{
			if (dto == null)
			{
				return default;
			}

			(bool convertSuccess, Entity? value) = CategoriesDtoConverter<Dto, Entity>(dto);
			if (convertSuccess)
			{
				return value;
			}

			(convertSuccess, value) = CustomersDtoConverter<Dto, Entity>(dto);
			if (convertSuccess)
			{
				return value;
			}

			(convertSuccess, value) = EmployeesDtoConverter<Dto, Entity>(dto);
			if (convertSuccess)
			{
				return value;
			}

			(convertSuccess, value) = OrderDetailsDtoConverter<Dto, Entity>(dto);
			if (convertSuccess)
			{
				return value;
			}

			(convertSuccess, value) = OrdersDtoConverter<Dto, Entity>(dto);
			if (convertSuccess)
			{
				return value;
			}

			(convertSuccess, value) = ProductsDtoConverter<Dto, Entity>(dto);
			if (convertSuccess)
			{
				return value;
			}

			(convertSuccess, value) = ShippersDtoConverter<Dto, Entity>(dto);
			if (convertSuccess)
			{
				return value;
			}

			(convertSuccess, value) = SuppliersDtoConverter<Dto, Entity>(dto);
			if (convertSuccess)
			{
				return value;
			}

			return default;
		}

		public async Task<Dto?> MapEntityToDto<Dto, Entity>(Entity? entity)
			where Dto : IDtoBase
			where Entity : IEntityBase
		{
			if (entity == null)
			{
				return default;
			}

			(bool convertSuccess, Dto? value) = CategoriesEntityConverter<Dto, Entity>(entity);
			if (convertSuccess)
			{
				return value;
			}

			(convertSuccess, value) = CustomersEntityConverter<Dto, Entity>(entity);
			if (convertSuccess)
			{
				return value;
			}

			(convertSuccess, value) = EmployeesEntityConverter<Dto, Entity>(entity);
			if (convertSuccess)
			{
				return value;
			}

			(convertSuccess, value) = OrderDetailsEntityConverter<Dto, Entity>(entity);
			if (convertSuccess)
			{
				return value;
			}

			(convertSuccess, value) = OrdersEntityConverter<Dto, Entity>(entity);
			if (convertSuccess)
			{
				return value;
			}

			(convertSuccess, value) = ProductsEntityConverter<Dto, Entity>(entity);
			if (convertSuccess)
			{
				return value;
			}

			(convertSuccess, value) = ShippersEntityConverter<Dto, Entity>(entity);
			if (convertSuccess)
			{
				return value;
			}

			(convertSuccess, value) = SuppliersEntityConverter<Dto, Entity>(entity);
			if (convertSuccess)
			{
				return value;
			}

			return default;
		}

		public async Task<IEnumerable<Dto>?> MapEntityToDtoList<Dto, Entity>(IEnumerable<Entity>? entities)
			where Dto : IDtoBase
			where Entity : IEntityBase
		{
			if (entities == null)
			{
				return default;
			}

			var dtoList = new List<Dto>();
			foreach (var entity in entities)
			{
				var dto = await MapEntityToDto<Dto, Entity>(entity);
				if (dto != null)
				{
					dtoList.Add(dto);
				}
			}

			return dtoList;
		}

		protected (bool convertSuccess, Entity? value) CategoriesDtoConverter<Dto, Entity>(Dto sourceDto)
			where Dto : IDtoBase
			where Entity : IEntityBase
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

				return (convertSuccess: true, value: (Entity)(dynamic)newEntity);
			}

			return (convertSuccess: false, value: default);
		}

		protected (bool convertSuccess, Dto? value) CategoriesEntityConverter<Dto, Entity>(Entity sourceEntity)
			where Dto : IDtoBase
			where Entity : IEntityBase
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

				return (convertSuccess: true, value: (Dto)(dynamic)newDto);
			}

			return (convertSuccess: false, value: default);
		}

		protected (bool convertSuccess, Entity? value) CustomersDtoConverter<Dto, Entity>(Dto sourceDto)
					where Dto : IDtoBase
			where Entity : IEntityBase
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

				return (convertSuccess: true, value: (Entity)(dynamic)newEntity);
			}

			return (convertSuccess: false, value: default);
		}

		protected (bool convertSuccess, Dto? value) CustomersEntityConverter<Dto, Entity>(Entity sourceEntity)
			where Dto : IDtoBase
			where Entity : IEntityBase
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

				return (convertSuccess: true, value: (Dto)(dynamic)newDto);
			}

			return (convertSuccess: false, value: default);
		}

		protected (bool convertSuccess, Entity? value) EmployeesDtoConverter<Dto, Entity>(Dto sourceDto)
					where Dto : IDtoBase
			where Entity : IEntityBase
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

				return (convertSuccess: true, value: (Entity)(dynamic)newEntity);
			}

			return (convertSuccess: false, value: default);
		}

		protected (bool convertSuccess, Dto? value) EmployeesEntityConverter<Dto, Entity>(Entity sourceEntity)
			where Dto : IDtoBase
			where Entity : IEntityBase
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

				return (convertSuccess: true, value: (Dto)(dynamic)newDto);
			}

			return (convertSuccess: false, value: default);
		}

		protected (bool convertSuccess, Entity? value) OrderDetailsDtoConverter<Dto, Entity>(Dto sourceDto)
					where Dto : IDtoBase
			where Entity : IEntityBase
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

				return (convertSuccess: true, value: (Entity)(dynamic)newEntity);
			}

			return (convertSuccess: false, value: default);
		}

		protected (bool convertSuccess, Dto? value) OrderDetailsEntityConverter<Dto, Entity>(Entity sourceEntity)
			where Dto : IDtoBase
			where Entity : IEntityBase
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

				return (convertSuccess: true, value: (Dto)(dynamic)newDto);
			}

			return (convertSuccess: false, value: default);
		}

		protected (bool convertSuccess, Entity? value) OrdersDtoConverter<Dto, Entity>(Dto sourceDto)
					where Dto : IDtoBase
			where Entity : IEntityBase
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

				return (convertSuccess: true, value: (Entity)(dynamic)newEntity);
			}

			return (convertSuccess: false, value: default);
		}

		protected (bool convertSuccess, Dto? value) OrdersEntityConverter<Dto, Entity>(Entity sourceEntity)
			where Dto : IDtoBase
			where Entity : IEntityBase
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

				return (convertSuccess: true, value: (Dto)(dynamic)newDto);
			}

			return (convertSuccess: false, value: default);
		}

		protected (bool convertSuccess, Entity? value) ProductsDtoConverter<Dto, Entity>(Dto sourceDto)
					where Dto : IDtoBase
			where Entity : IEntityBase
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

				return (convertSuccess: true, value: (Entity)(dynamic)newEntity);
			}

			return (convertSuccess: false, value: default);
		}

		protected (bool convertSuccess, Dto? value) ProductsEntityConverter<Dto, Entity>(Entity sourceEntity)
			where Dto : IDtoBase
			where Entity : IEntityBase
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

				return (convertSuccess: true, value: (Dto)(dynamic)newDto);
			}

			return (convertSuccess: false, value: default);
		}

		protected (bool convertSuccess, Entity? value) ShippersDtoConverter<Dto, Entity>(Dto sourceDto)
					where Dto : IDtoBase
			where Entity : IEntityBase
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

				return (convertSuccess: true, value: (Entity)(dynamic)newEntity);
			}

			return (convertSuccess: false, value: default);
		}

		protected (bool convertSuccess, Dto? value) ShippersEntityConverter<Dto, Entity>(Entity sourceEntity)
			where Dto : IDtoBase
			where Entity : IEntityBase
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

				return (convertSuccess: true, value: (Dto)(dynamic)newDto);
			}

			return (convertSuccess: false, value: default);
		}

		protected (bool convertSuccess, Entity? value) SuppliersDtoConverter<Dto, Entity>(Dto sourceDto)
																							where Dto : IDtoBase
			where Entity : IEntityBase
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

				return (convertSuccess: true, value: (Entity)(dynamic)newEntity);
			}

			return (convertSuccess: false, value: default);
		}
		protected (bool convertSuccess, Dto? value) SuppliersEntityConverter<Dto, Entity>(Entity sourceEntity)
																					where Dto : IDtoBase
			where Entity : IEntityBase
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

				return (convertSuccess: true, value: (Dto)(dynamic)newDto);
			}

			return (convertSuccess: false, value: default);
		}
	}
}
