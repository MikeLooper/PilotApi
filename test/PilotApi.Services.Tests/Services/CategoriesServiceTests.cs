using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using PilotApi.Repositories.Contracts.Repository;
using PilotApi.Services.Contracts;
using PilotApi.Services.Services;
using System;

namespace PilotApi.Services.Tests.Services
{
	[TestFixture]
	public class CategoriesServiceTests
	{
		[Test]
		public void CategoriesService_CanCreateCategoriesService_WithNullDependencies_Throws_Test()
		{
			var ex = Assert.Throws<System.Reflection.TargetInvocationException>(() => Activator.CreateInstance(
				typeof(PilotApi.Services.Services.CategoriesService),
				null, null, null));

			Assert.IsInstanceOf<ArgumentNullException>(ex?.InnerException);
		}

		[Test]
		public void CategoriesService_Constructor_Succeeds_Test()
		{
			// arrange
			var loggerFactory = new Mock<ILoggerFactory>();
			var repository = new Mock<ICategoriesRepository>();
			var handler = new Mock<IDataMapperHandler>();

			// act
			var testObject = new CategoriesService(
				loggerFactory.Object,
				repository.Object,
				handler.Object);

			// assert
			Console.WriteLine($"testObject: {testObject}");
			Assert.IsNotNull(testObject);
		}
	}
}

