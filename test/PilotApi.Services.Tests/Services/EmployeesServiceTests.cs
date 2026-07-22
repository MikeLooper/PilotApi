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
	public class EmployeesServiceTests
	{
		[Test]
		public void EmployeesService_Constructor_Throws_When_Null_Args_Test()
		{
			var ex = Assert.Throws<System.Reflection.TargetInvocationException>(() => Activator.CreateInstance(
				typeof(PilotApi.Services.Services.EmployeesService),
				null, null, null));

			Assert.IsInstanceOf<ArgumentNullException>(ex?.InnerException);
		}

		[Test]
		public void EmployeesService_Constructor_Succeeds_Test()
		{
			// arrange
			var loggerFactory = new Mock<ILoggerFactory>();
			var repository = new Mock<IEmployeesRepository>();
			var handler = new Mock<IDataMapperHandler>();

			// act
			var testObject = new EmployeesService(
				loggerFactory.Object,
				repository.Object,
				handler.Object);

			// assert
			Console.WriteLine($"testObject: {testObject}");
			Assert.IsNotNull(testObject);
		}
	}
}

