using NUnit.Framework;
using PilotApi.Shared.Configuration.Base;
using System;
using System.Collections.Generic;

namespace PilotApi.Shared.Tests.Configuration.Base
{
	[TestFixture]
	public class ConfigurationBaseTests
	{
		private class ConcreteConfiguration : ConfigurationBase
		{
			public override void Validate(ref List<Exception> exceptions)
			{
				// Concrete implementation for testing base class
			}
		}

		[Test]
		public void ConfigurationBase_Constructor_ShouldInitializeActiveToTrue_Test()
		{
			// Arrange & Act
			var config = new ConcreteConfiguration();

			// Assert
			Assert.That(config.Active, Is.True);
		}

		[Test]
		public void ConfigurationBase_Active_ShouldBeSettable_Test()
		{
			// Arrange
			var config = new ConcreteConfiguration();

			// Act
			config.Active = false;

			// Assert
			Assert.That(config.Active, Is.False);
		}

		[Test]
		public void ConfigurationBase_Active_ShouldBePersistable_Test()
		{
			// Arrange
			var config = new ConcreteConfiguration();
			config.Active = false;

			// Act
			var activeValue = config.Active;

			// Assert
			Assert.That(activeValue, Is.False);
		}

		[Test]
		public void ConfigurationBase_Validate_ShouldAcceptExceptionsList_Test()
		{
			// Arrange
			var config = new ConcreteConfiguration();
			var exceptions = new List<Exception>();

			// Act & Assert (should not throw)
			Assert.DoesNotThrow(() => config.Validate(ref exceptions));
		}

		[Test]
		public void ConfigurationBase_Multiple_Instances_ShouldHaveIndependentActiveStates_Test()
		{
			// Arrange
			var config1 = new ConcreteConfiguration();
			var config2 = new ConcreteConfiguration();

			// Act
			config1.Active = true;
			config2.Active = false;

			// Assert
			Assert.That(config1.Active, Is.True);
			Assert.That(config2.Active, Is.False);
		}
	}
}

