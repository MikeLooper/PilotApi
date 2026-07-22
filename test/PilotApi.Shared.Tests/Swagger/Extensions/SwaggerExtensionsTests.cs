using NUnit.Framework;
using Microsoft.AspNetCore.Builder;
using PilotApi.Shared.Swagger.Extensions;
using System;

namespace PilotApi.Shared.Tests.Swagger.Extensions
{
	[TestFixture]
	public class SwaggerExtensionsTests
	{
		[Test]
		public void SwaggerExtensions_SwaggerWebApplication_WithNullWebApp_ShouldThrow_Test()
		{
			// Arrange & Act & Assert
			var exception = Assert.Throws<ArgumentException>(() =>
				SwaggerExtensions.SwaggerWebApplication(null));
			Assert.That(exception.Message, Does.Contain("webApp"));
		}

		[Test]
		public void SwaggerExtensions_SwaggerWebApplication_WithValidWebApp_ShouldNotThrow_Test()
		{
			// Arrange
			var builder = WebApplication.CreateBuilder();
			var app = builder.Build();

			// Act & Assert
			Assert.DoesNotThrow(() => app.SwaggerWebApplication());
		}

		[Test]
		public void SwaggerExtensions_SwaggerWebApplication_IsExtensionMethod_Test()
		{
			// Arrange
			var builder = WebApplication.CreateBuilder();
			var app = builder.Build();

			// Act & Assert
			Assert.DoesNotThrow(() => app.SwaggerWebApplication());
		}

		[Test]
		public void SwaggerExtensions_SwaggerWebApplication_ExceptionMessage_ShouldContainWebApplicationType_Test()
		{
			// Arrange & Act & Assert
			var exception = Assert.Throws<ArgumentException>(() =>
				SwaggerExtensions.SwaggerWebApplication(null));
			Assert.That(exception.Message, Does.Contain("WebApplication"));
		}
	}
}

