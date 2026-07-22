using NUnit.Framework;
using PilotApi.Web.Extensions;
using System;

namespace PilotApi.Web.Tests.Extensions
{
	[TestFixture]
	public class ApplicationInjectionExtensionsTests
	{
		[Test]
		public void ApplicationInjectionExtensions_ApplicationRegistration_WithNullBuilder_ThrowsArgumentException_Test()
		{
			Assert.Throws<ArgumentException>(() => ApplicationInjectionExtensions.ApplicationRegistration(null!));
		}
	}
}

