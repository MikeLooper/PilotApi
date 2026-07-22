using NUnit.Framework;
using PilotApi.Shared.OpenApi.Transformers;
using System;

namespace PilotApi.Shared.Tests.OpenApi.Transformers
{
	[TestFixture]
	public class GlobalOperationTransformerTests
	{
		private GlobalOperationTransformer transformer;

		[SetUp]
		public void Setup()
		{
			transformer = new GlobalOperationTransformer();
		}

		[Test]
		public void GlobalOperationTransformer_Constructor_ShouldInitialize_Test()
		{
			// Arrange & Act - constructor called in Setup

			// Assert
			Assert.NotNull(transformer);
		}

		[Test]
		public void GlobalOperationTransformer_Transformer_IsIOpenApiOperationTransformer_Test()
		{
			// Arrange & Act
			var isTransformer = transformer is Microsoft.AspNetCore.OpenApi.IOpenApiOperationTransformer;

			// Assert
			Assert.That(isTransformer, Is.True);
		}

		[Test]
		public void GlobalOperationTransformer_Transformer_CanBeCreatedMultipleTimes_Test()
		{
			// Arrange & Act
			var transformer1 = new GlobalOperationTransformer();
			var transformer2 = new GlobalOperationTransformer();

			// Assert
			Assert.NotNull(transformer1);
			Assert.NotNull(transformer2);
			Assert.AreNotSame(transformer1, transformer2);
		}
	}
}

