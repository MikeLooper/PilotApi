using NUnit.Framework;
using PilotApi.Shared.OpenApi.Transformers;
using System;
using System.IO;
using System.Xml.Linq;

namespace PilotApi.Shared.Tests.OpenApi.Transformers
{
	[TestFixture]
	public class ManualXmlCommentsOperationTransformerTests
	{
		private string xmlFilePath;

		[SetUp]
		public void Setup()
		{
			// Create a temporary XML file for testing
			xmlFilePath = Path.Combine(Path.GetTempPath(), "TestComments.xml");

			var xmlDocument = new XDocument(
				new XElement("doc",
					new XElement("members",
						new XElement("member",
							new XAttribute("name", "M:TestNamespace.TestClass.TestMethod"),
							new XElement("summary", "This is a test method"),
							new XElement("returns", "A test result")
						)
					)
				)
			);

			xmlDocument.Save(xmlFilePath);
		}

		[Test]
		public void ManualXmlCommentsOperationTransformer_Constructor_WithValidXmlPath_ShouldInitialize_Test()
		{
			// Arrange & Act
			var transformer = new ManualXmlCommentsOperationTransformer(xmlFilePath);

			// Assert
			Assert.NotNull(transformer);
		}

		[Test]
		public void ManualXmlCommentsOperationTransformer_Constructor_WithNonExistentXmlPath_ShouldThrow_Test()
		{
			// Arrange
			var invalidPath = Path.Combine(Path.GetTempPath(), "NonExistent_" + Guid.NewGuid() + ".xml");

			// Act & Assert
			Assert.Throws<FileNotFoundException>(() =>
				new ManualXmlCommentsOperationTransformer(invalidPath));
		}

		[Test]
		public void ManualXmlCommentsOperationTransformer_Constructor_WithNullXmlPath_ShouldThrow_Test()
		{
			// Arrange & Act & Assert
			Assert.Throws<ArgumentNullException>(() =>
				new ManualXmlCommentsOperationTransformer(null));
		}

		[Test]
		public void ManualXmlCommentsOperationTransformer_Constructor_WithEmptyXmlPath_ShouldThrow_Test()
		{
			// Arrange & Act & Assert
			Assert.Throws(typeof(System.InvalidOperationException), () =>
				new ManualXmlCommentsOperationTransformer(""));
		}

		[Test]
		public void ManualXmlCommentsOperationTransformer_Constructor_LoadsXmlDocument_Test()
		{
			// Arrange & Act
			var transformer = new ManualXmlCommentsOperationTransformer(xmlFilePath);

			// Assert
			Assert.NotNull(transformer);
		}

		[Test]
		public void ManualXmlCommentsOperationTransformer_Transformer_IsIOpenApiOperationTransformer_Test()
		{
			// Arrange & Act
			var transformer = new ManualXmlCommentsOperationTransformer(xmlFilePath);

			// Assert
			Assert.IsInstanceOf<Microsoft.AspNetCore.OpenApi.IOpenApiOperationTransformer>(transformer);
		}

		[Test]
		public void ManualXmlCommentsOperationTransformer_Transformer_CanBeCreatedMultipleTimes_Test()
		{
			// Arrange & Act
			var transformer1 = new ManualXmlCommentsOperationTransformer(xmlFilePath);
			var transformer2 = new ManualXmlCommentsOperationTransformer(xmlFilePath);

			// Assert
			Assert.NotNull(transformer1);
			Assert.NotNull(transformer2);
			Assert.AreNotSame(transformer1, transformer2);
		}

		[Test]
		public void ManualXmlCommentsOperationTransformer_Transformer_WithWellFormedXml_ShouldParse_Test()
		{
			// Arrange
			var wellFormedXmlPath = Path.Combine(Path.GetTempPath(), "WellFormed_" + Guid.NewGuid() + ".xml");
			var xmlDocument = new XDocument(
				new XElement("doc",
					new XElement("members",
						new XElement("member",
							new XAttribute("name", "M:Namespace.Class.Method"),
							new XElement("summary", "Summary text")
						)
					)
				)
			);
			xmlDocument.Save(wellFormedXmlPath);

			// Act & Assert
			Assert.DoesNotThrow(() =>
				new ManualXmlCommentsOperationTransformer(wellFormedXmlPath));

			// Cleanup
			if (File.Exists(wellFormedXmlPath))
				File.Delete(wellFormedXmlPath);
		}

		[Test]
		public void ManualXmlCommentsOperationTransformer_Transformer_WithMalformedXml_ShouldThrow_Test()
		{
			// Arrange
			var malformedXmlPath = Path.Combine(Path.GetTempPath(), "Malformed_" + Guid.NewGuid() + ".xml");
			File.WriteAllText(malformedXmlPath, "<doc><unclosed>");

			// Act & Assert
			Assert.Throws(typeof(System.Xml.XmlException), () =>
				new ManualXmlCommentsOperationTransformer(malformedXmlPath));

			// Cleanup
			if (File.Exists(malformedXmlPath))
				File.Delete(malformedXmlPath);
		}

		[Test]
		public void ManualXmlCommentsOperationTransformer_Transformer_WithComplexXmlStructure_ShouldLoadSuccessfully_Test()
		{
			// Arrange
			var complexXmlPath = Path.Combine(Path.GetTempPath(), "Complex_" + Guid.NewGuid() + ".xml");
			var xmlDocument = new XDocument(
				new XElement("doc",
					new XElement("members",
						new XElement("member",
							new XAttribute("name", "M:Namespace.Class.Method1"),
							new XElement("summary", "Summary 1"),
							new XElement("param", new XAttribute("name", "arg1"), "Parameter 1"),
							new XElement("returns", "Return value 1")
						),
						new XElement("member",
							new XAttribute("name", "M:Namespace.Class.Method2"),
							new XElement("summary", "Summary 2"),
							new XElement("remarks", "Additional remarks")
						)
					)
				)
			);
			xmlDocument.Save(complexXmlPath);

			// Act & Assert
			Assert.DoesNotThrow(() =>
				new ManualXmlCommentsOperationTransformer(complexXmlPath));

			// Cleanup
			if (File.Exists(complexXmlPath))
				File.Delete(complexXmlPath);
		}

		[TearDown]
		public void Cleanup()
		{
			if (File.Exists(xmlFilePath))
			{
				File.Delete(xmlFilePath);
			}
		}
	}
}

