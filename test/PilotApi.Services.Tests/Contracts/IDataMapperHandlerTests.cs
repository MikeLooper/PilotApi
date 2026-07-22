using NUnit.Framework;
using System;
using System.Linq;

namespace PilotApi.Services.Tests.Contracts
{
	[TestFixture]
	public class IDataMapperHandlerTests
	{
		[Test]
		public void IDataMapperHandler_Interface_Exists_Test()
		{
			var type = typeof(PilotApi.Services.Contracts.IDataMapperHandler);

			Assert.IsNotNull(type, "IDataMapperHandler interface not found");
			Assert.IsTrue(type.IsInterface, "IDataMapperHandler is not an interface");
		}
	}
}

