using NUnit.Framework;
using PilotApi.Shared.Configuration;
using PilotApi.Shared.Contracts.Configuration;
using PilotApi.Shared.OpenApi.Transformers;
using System;

namespace PilotApi.Shared.Tests.OpenApi.Transformers
{
	[TestFixture]
	public class DocumentInfoTransformerTests
	{
		private IApplicationConfiguration applicationConfiguration;
		private DocumentInfoTransformer transformer;

		[SetUp]
		public void Setup()
		{
			applicationConfiguration = new ApplicationConfiguration
			{
				OpenApi = new OpenApiConfiguration
				{
					Title = "Test API",
					Version = "1.0.0",
					Description = "Test Description",
					Summary = "Test Summary",
					License = "MIT",
					Contact = new OpenApiContactConfiguration
					{
						Name = "Support Team",
						Email = "support@example.com",
						URL = "https://example.com/support"
					}
				}
			};

			transformer = new DocumentInfoTransformer(applicationConfiguration);
		}

		[Test]
		public void DocumentInfoTransformer_Constructor_WithValidApplicationConfiguration_ShouldInitialize_Test()
		{
			// Arrange & Act - constructor called in Setup

			// Assert
			Assert.NotNull(transformer);
			Assert.NotNull(transformer.ApplicationConfiguration);
		}

		[Test]
		public void DocumentInfoTransformer_Constructor_WithNullApplicationConfiguration_ShouldInitializeWithNull_Test()
		{
			// Arrange & Act
			var transformerWithNull = new DocumentInfoTransformer(null);

			// Assert
			Assert.NotNull(transformerWithNull);
			Assert.Null(transformerWithNull.ApplicationConfiguration);
		}

		[Test]
		public void DocumentInfoTransformer_ApplicationConfiguration_ShouldBeAccessible_Test()
		{
			// Arrange & Act
			var config = transformer.ApplicationConfiguration;

			// Assert
			Assert.NotNull(config);
			Assert.That(config.OpenApi.Title, Is.EqualTo("Test API"));
			Assert.That(config.OpenApi.Version, Is.EqualTo("1.0.0"));
			Assert.That(config.OpenApi.Description, Is.EqualTo("Test Description"));
		}

		[Test]
		public void DocumentInfoTransformer_Transformer_IsIOpenApiDocumentTransformer_Test()
		{
			// Arrange & Act
			var isTransformer = transformer is Microsoft.AspNetCore.OpenApi.IOpenApiDocumentTransformer;

			// Assert
			Assert.That(isTransformer, Is.True);
		}
	}
}

