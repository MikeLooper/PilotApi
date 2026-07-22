using NUnit.Framework;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace PilotApi.Services.Tests.Services
{
	[TestFixture]
	public class ServiceBaseTests
	{
		[Test]
		public void ServiceBase_AbstractType_Exists_Test()
		{
			var type = typeof(PilotApi.Services.Services.Base.ServiceBase<,>);

			Assert.IsNotNull(type, "ServiceBase generic type not found");
		}
	}
}

