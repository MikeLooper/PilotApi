using NUnit.Framework;
using PilotApi.Domain.Contracts.Services.Base;
using PilotApi.Domain.Models.Dto;
using PilotApi.Web.Controllers;
using PilotApi.Web.Tests.TestDoubles;
using System.Reflection;

namespace PilotApi.Web.Tests.Controllers.Base
{
	[TestFixture]
	public class CrudControllerBaseTests
	{
		[Test]
		public void CrudControllerBase_Constructor_WithService_SetsProtectedServiceProperty_Test()
		{
			var service = ProxyFactory.Create<IServiceBase<CategoriesDto>>();
			var controller = new CrudControllerBase<CategoriesDto>(service);

			var serviceProperty = typeof(CrudControllerBase<CategoriesDto>)
				.GetProperty("Service", BindingFlags.Instance | BindingFlags.NonPublic);
			var serviceValue = serviceProperty?.GetValue(controller);

			Assert.That(serviceProperty, Is.Not.Null);
			Assert.That(serviceValue, Is.SameAs(service));
		}

		[Test]
		public void CrudControllerBase_ApiVersion_SetValue_GetReturnsSameValue_Test()
		{
			var service = ProxyFactory.Create<IServiceBase<CategoriesDto>>();
			var controller = new CrudControllerBase<CategoriesDto>(service)
			{
				ApiVersion = "1.0"
			};

			Assert.That(controller.ApiVersion, Is.EqualTo("1.0"));
		}
	}
}

