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
	public class OrderDetailsServiceTests
	{
		[Test]
		public void OrderDetailsService_Constructor_Throws_When_Null_Args_Test()
		{
			var ex = Assert.Throws<System.Reflection.TargetInvocationException>(() => Activator.CreateInstance(
				typeof(PilotApi.Services.Services.OrderDetailsService),
				null, null, null));

			Assert.IsInstanceOf<ArgumentNullException>(ex?.InnerException);
		}

		[Test]
		public void OrderDetailsService_Constructor_Succeeds_Test()
		{
			// arrange
			var loggerFactory = new Mock<ILoggerFactory>();
			var repository = new Mock<IOrderDetailsRepository>();
			var handler = new Mock<IDataMapperHandler>();

			// act
			var testObject = new OrderDetailsService(
				loggerFactory.Object,
				repository.Object,
				handler.Object);

			// assert
			Console.WriteLine($"testObject: {testObject}");
			Assert.IsNotNull(testObject);
		}
	}
}

