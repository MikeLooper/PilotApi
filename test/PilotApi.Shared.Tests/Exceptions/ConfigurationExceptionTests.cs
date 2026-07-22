using NUnit.Framework;
using PilotApi.Shared.Exceptions;
using System;
using System.IO;

namespace PilotApi.Shared.Tests.Exceptions
{
	[TestFixture]
	public class ConfigurationExceptionTests
	{
		[Test]
		public void ConfigurationException_Constructor_Default_ShouldCreateValidException_Test()
		{
			// Arrange & Act
			var exception = new ConfigurationException();

			// Assert
			Assert.NotNull(exception);
			Assert.IsInstanceOf<Exception>(exception);
			Assert.That(exception.Message, Is.EqualTo("Exception of type 'PilotApi.Shared.Exceptions.ConfigurationException' was thrown."));
		}

		[Test]
		public void ConfigurationException_Constructor_WithMessage_ShouldIncludeMessage_Test()
		{
			// Arrange
			var message = "Test configuration error";

			// Act
			var exception = new ConfigurationException(message);

			// Assert
			Assert.NotNull(exception);
			Assert.That(exception.Message, Is.EqualTo(message));
		}

		[Test]
		public void ConfigurationException_Constructor_WithEmptyMessage_ShouldAcceptEmptyString_Test()
		{
			// Arrange
			var message = "";

			// Act
			var exception = new ConfigurationException(message);

			// Assert
			Assert.NotNull(exception);
			Assert.That(exception.Message, Is.EqualTo(message));
		}

		[Test]
		public void ConfigurationException_Constructor_WithNullMessage_ShouldHandleNull_Test()
		{
			// Arrange & Act
			var exception = new ConfigurationException(null);

			// Assert
			Assert.NotNull(exception);
		}

		[Test]
		public void ConfigurationException_Constructor_WithMessageAndInnerException_ShouldIncludeBoth_Test()
		{
			// Arrange
			var message = "Outer exception";
			var innerException = new InvalidOperationException("Inner exception");

			// Act
			var exception = new ConfigurationException(message, innerException);

			// Assert
			Assert.NotNull(exception);
			Assert.That(exception.Message, Is.EqualTo(message));
			Assert.NotNull(exception.InnerException);
			Assert.That(exception.InnerException.Message, Is.EqualTo("Inner exception"));
		}

		[Test]
		public void ConfigurationException_InnerException_ShouldBeAccessible_Test()
		{
			// Arrange
			var innerException = new IOException("File not found");
			var exception = new ConfigurationException("Configuration file error", innerException);

			// Act
			var result = exception.InnerException;

			// Assert
			Assert.That(result, Is.SameAs(innerException));
		}

		[Test]
		public void ConfigurationException_Exception_ShouldBeSerializable_Test()
		{
			// Arrange
			var exception = new ConfigurationException("Test message");

			// Act
			var isSerializable = exception.GetType().IsSerializable;

			// Assert
			Assert.That(isSerializable, Is.True);
		}

		[Test]
		public void ConfigurationException_Exception_ShouldHaveSerializableAttribute_Test()
		{
			// Arrange & Act
			var attribute = typeof(ConfigurationException).GetCustomAttributes(typeof(SerializableAttribute), false);

			// Assert
			Assert.That(attribute.Length, Is.EqualTo(1));
		}

		[Test]
		public void ConfigurationException_ToString_ShouldReturnFormattedString_Test()
		{
			// Arrange
			var message = "Configuration validation failed";
			var exception = new ConfigurationException(message);

			// Act
			var result = exception.ToString();

			// Assert
			Assert.NotNull(result);
			Assert.That(result, Does.Contain("ConfigurationException"));
			Assert.That(result, Does.Contain(message));
		}

		[Test]
		public void ConfigurationException_ToString_WithInnerException_ShouldIncludeInnerDetails_Test()
		{
			// Arrange
			var message = "Outer error";
			var innerException = new ArgumentException("Invalid argument");
			var exception = new ConfigurationException(message, innerException);

			// Act
			var result = exception.ToString();

			// Assert
			Assert.NotNull(result);
			Assert.That(result, Does.Contain(message));
			Assert.That(result, Does.Contain("ArgumentException"));
		}

		[Test]
		public void ConfigurationException_Exception_CanBeThrownAndCaught_Test()
		{
			// Arrange & Act & Assert
			var exception = Assert.Throws<ConfigurationException>(() =>
			{
				throw new ConfigurationException("Test error message");
			});

			Assert.That(exception.Message, Is.EqualTo("Test error message"));
		}

		[Test]
		public void ConfigurationException_Exception_CanBeCaughtAsBaseException_Test()
		{
			// Arrange & Act & Assert
			try
			{
				throw new ConfigurationException("Test error message");
			}
			catch (Exception caughtAsException)
			{
				Assert.IsInstanceOf<ConfigurationException>(caughtAsException);
			}
		}

		[Test]
		public void ConfigurationException_MultipleInstances_ShouldBeIndependent_Test()
		{
			// Arrange & Act
			var exception1 = new ConfigurationException("Error 1");
			var exception2 = new ConfigurationException("Error 2");

			// Assert
			Assert.That(exception1.Message, Is.EqualTo("Error 1"));
			Assert.That(exception2.Message, Is.EqualTo("Error 2"));
			Assert.AreNotEqual(exception1.Message, exception2.Message);
		}
	}
}

