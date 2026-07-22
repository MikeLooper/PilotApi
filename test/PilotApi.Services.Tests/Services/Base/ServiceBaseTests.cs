using NUnit.Framework;
using System;
using System.Linq;

namespace PilotApi.Services.Tests.Services.Base
{
	[TestFixture]
	public class ServiceBaseTests
	{
		[Test]
		public void ServiceBase_GenericType_Exists_InAssembly_Test()
		{
			var type = typeof(PilotApi.Services.Services.Base.ServiceBase<,>);

			Assert.IsNotNull(type, "ServiceBase generic type not found");
		}
	}
}

