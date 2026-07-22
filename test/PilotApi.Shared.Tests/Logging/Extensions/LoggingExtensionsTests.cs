using NUnit.Framework;
using Microsoft.AspNetCore.Builder;
using PilotApi.Shared.Logging.Extensions;
using System;

namespace PilotApi.Shared.Tests.Logging.Extensions
{
	[TestFixture]
	public class LoggingExtensionsTests
	{
		[Test]
		public void LoggingExtensions_LoggingWebApplication_WithNullWebApp_ShouldThrow_Test()
		{
			// Arrange & Act & Assert
			var exception = Assert.Throws<ArgumentException>(() =>
				LoggingExtensions.LoggingWebApplication(null));
			Assert.That(exception.Message, Does.Contain("webApp"));
		}

		[Test]
		public void LoggingExtensions_LoggingWebApplication_WithValidWebApp_ShouldNotThrow_Test()
		{
			// Arrange
			var builder = WebApplication.CreateBuilder();
			var app = builder.Build();

			// Act & Assert
			Assert.DoesNotThrow(() => app.LoggingWebApplication());
		}

		[Test]
		public void LoggingExtensions_LoggingWebApplicationBuilder_WithNullBuilder_ShouldThrow_Test()
		{
			// Arrange & Act & Assert
			var exception = Assert.Throws<ArgumentException>(() =>
				LoggingExtensions.LoggingWebApplicationBuilder(null));
			Assert.That(exception.Message, Does.Contain("builder"));
		}

		[Test]
		public void LoggingExtensions_LoggingWebApplicationBuilder_WithValidBuilder_ShouldNotThrow_Test()
		{
			// Arrange
			var builder = WebApplication.CreateBuilder();

			// Act & Assert
			Assert.DoesNotThrow(() => builder.LoggingWebApplicationBuilder());
		}

		[Test]
		public void LoggingExtensions_LoggingWebApplication_IsExtensionMethod_Test()
		{
			// Arrange
			var builder = WebApplication.CreateBuilder();
			var app = builder.Build();

			// Act & Assert
			Assert.DoesNotThrow(() => app.LoggingWebApplication());
		}

		[Test]
		public void LoggingExtensions_LoggingWebApplicationBuilder_IsExtensionMethod_Test()
		{
			// Arrange
			var builder = WebApplication.CreateBuilder();

			// Act & Assert
			Assert.DoesNotThrow(() => builder.LoggingWebApplicationBuilder());
		}

		[Test]
		public void LoggingExtensions_LoggingWebApplication_ExceptionMessage_ShouldContainWebApplicationType_Test()
		{
			// Arrange & Act & Assert
			var exception = Assert.Throws<ArgumentException>(() =>
				LoggingExtensions.LoggingWebApplication(null));
			Assert.That(exception.Message, Does.Contain("WebApplication"));
		}

		[Test]
		public void LoggingExtensions_LoggingWebApplicationBuilder_ExceptionMessage_ShouldContainWebApplicationBuilderType_Test()
		{
			// Arrange & Act & Assert
			var exception = Assert.Throws<ArgumentException>(() =>
				LoggingExtensions.LoggingWebApplicationBuilder(null));
			Assert.That(exception.Message, Does.Contain("WebApplicationBuilder"));
		}
	}
}

