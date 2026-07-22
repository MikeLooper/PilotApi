using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace PilotApi.Services.Tests.Extensions
{
	[TestFixture]
	public class ServicesInjectionExtensionsTests
	{
		[Test]
		public void ServicesInjectionExtensions_ServicesRegistration_Method_Throws_ArgumentException_When_Builder_Null_Test()
		{
			var type = typeof(PilotApi.Services.Extensions.ServicesInjectionExtensions);
			Assert.IsNotNull(type, "ServicesInjectionExtensions type not found");

			var method = type.GetMethod("ServicesRegistration", BindingFlags.Public | BindingFlags.Static);
			Assert.IsNotNull(method, "ServicesRegistration method not found");

			var ex = Assert.Throws<TargetInvocationException>(() => method.Invoke(null, new object[] { null }));
			Assert.IsNotNull(ex?.InnerException);
			Assert.IsInstanceOf<ArgumentException>(ex?.InnerException);
		}
	}
}

