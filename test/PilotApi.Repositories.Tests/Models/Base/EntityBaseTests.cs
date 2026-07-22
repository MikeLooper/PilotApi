using NUnit.Framework;
using PilotApi.Repositories.Models.Base;

namespace PilotApi.Repositories.Tests.Models.Base
{
	[TestFixture]
	public class EntityBaseTests : TestBase
	{
		// Concrete implementation of abstract EntityBase for testing
		private class ConcreteEntity : EntityBase
		{
		}

		[Test]
		public void EntityBase_CanInstantiateConcreteImplementation_Test()
		{
			// Act
			var entity = new ConcreteEntity();

			// Assert
			Assert.That(entity, Is.Not.Null);
			Assert.That(entity, Is.InstanceOf<EntityBase>());
		}

		[Test]
		public void EntityBase_IsAbstract_Test()
		{
			// Arrange
			var entityType = typeof(EntityBase);

			// Assert
			Assert.That(entityType.IsAbstract, Is.True);
		}
	}
}


