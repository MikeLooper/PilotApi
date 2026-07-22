using NUnit.Framework;
using PilotApi.Shared.Constants;
using PilotApi.Shared.Utilities;
using System;
using System.Collections.Generic;

namespace PilotApi.Shared.Tests.Utilities
{
	[TestFixture]
	public class DataSourceUtilitiesTests
	{
		[Test]
		public void DataSourceUtilities_DelimitName_WithSqlServerAndNoDelimiters_ShouldAddBrackets_Test()
		{
			// Arrange
			var sourceName = "Users";

			// Act
			var result = DataSourceUtilities.DelimitName(sourceName, DataSourceTypes.SqlServer);

			// Assert
			Assert.That(result, Is.EqualTo("[Users]"));
		}

		[Test]
		public void DataSourceUtilities_DelimitName_WithSqlServerAndExistingBrackets_ShouldNotDuplicate_Test()
		{
			// Arrange
			var sourceName = "[Users]";

			// Act
			var result = DataSourceUtilities.DelimitName(sourceName, DataSourceTypes.SqlServer);

			// Assert
			Assert.That(result, Is.EqualTo("[Users]"));
		}

		[Test]
		public void DataSourceUtilities_DelimitName_WithSqlServerPartialBrackets_ShouldCompleteBrackets_Test()
		{
			// Arrange
			var sourceName = "Users]";

			// Act
			var result = DataSourceUtilities.DelimitName(sourceName, DataSourceTypes.SqlServer);

			// Assert
			Assert.That(result, Is.EqualTo("[Users]"));
		}

		[Test]
		public void DataSourceUtilities_DelimitName_WithPostgreSqlAndNoDelimiters_ShouldAddQuotes_Test()
		{
			// Arrange
			var sourceName = "users";

			// Act
			var result = DataSourceUtilities.DelimitName(sourceName, DataSourceTypes.PostgreSQL);

			// Assert
			Assert.That(result, Is.EqualTo("\"users\""));
		}

		[Test]
		public void DataSourceUtilities_DelimitName_WithPostgreSqlAndExistingQuotes_ShouldNotDuplicate_Test()
		{
			// Arrange
			var sourceName = "\"users\"";

			// Act
			var result = DataSourceUtilities.DelimitName(sourceName, DataSourceTypes.PostgreSQL);

			// Assert
			Assert.That(result, Is.EqualTo("\"users\""));
		}

		[Test]
		public void DataSourceUtilities_DelimitName_WithNullSourceName_ShouldThrowArgumentException_Test()
		{
			// Arrange
			string sourceName = null;

			// Act & Assert
			var ex = Assert.Throws<ArgumentException>(() =>
				DataSourceUtilities.DelimitName(sourceName, DataSourceTypes.SqlServer));
			Assert.That(ex.Message, Does.Contain("Invalid argument"));
		}

		[Test]
		public void DataSourceUtilities_DelimitName_WithEmptySourceName_ShouldThrowArgumentException_Test()
		{
			// Arrange
			var sourceName = "";

			// Act & Assert
			var ex = Assert.Throws<ArgumentException>(() =>
				DataSourceUtilities.DelimitName(sourceName, DataSourceTypes.SqlServer));
			Assert.That(ex.Message, Does.Contain("Invalid argument"));
		}

		[Test]
		public void DataSourceUtilities_DelimitName_WithWhitespaceOnlySourceName_ShouldThrowArgumentException_Test()
		{
			// Arrange
			var sourceName = "   ";

			// Act & Assert
			var ex = Assert.Throws<ArgumentException>(() =>
				DataSourceUtilities.DelimitName(sourceName, DataSourceTypes.SqlServer));
			Assert.That(ex.Message, Does.Contain("Invalid argument"));
		}

		[Test]
		public void DataSourceUtilities_DelimitName_WithUnrecognizedDataSourceType_ShouldThrow_Test()
		{
			// Arrange
			var sourceName = "Users";

			// Act & Assert
			var exception = Assert.Throws<ArgumentException>(() =>
				DataSourceUtilities.DelimitName(sourceName, DataSourceTypes.Unrecognized));
			Assert.That(exception.Message, Does.Contain("Invalid argument"));
		}

		[Test]
		public void DataSourceUtilities_DelimitNames_WithMultipleSqlServerNames_ShouldDelimitAll_Test()
		{
			// Arrange
			var sourceNames = new List<string> { "Users", "Orders", "Products" };

			// Act
			var result = DataSourceUtilities.DelimitNames(sourceNames, DataSourceTypes.SqlServer);

			// Assert
			Assert.That(result.Count, Is.EqualTo(3));
			Assert.That(result[0], Is.EqualTo("[Users]"));
			Assert.That(result[1], Is.EqualTo("[Orders]"));
			Assert.That(result[2], Is.EqualTo("[Products]"));
		}

		[Test]
		public void DataSourceUtilities_DelimitNames_WithMultiplePostgreSqlNames_ShouldDelimitAll_Test()
		{
			// Arrange
			var sourceNames = new List<string> { "users", "orders", "products" };

			// Act
			var result = DataSourceUtilities.DelimitNames(sourceNames, DataSourceTypes.PostgreSQL);

			// Assert
			Assert.That(result.Count, Is.EqualTo(3));
			Assert.That(result[0], Is.EqualTo("\"users\""));
			Assert.That(result[1], Is.EqualTo("\"orders\""));
			Assert.That(result[2], Is.EqualTo("\"products\""));
		}

		[Test]
		public void DataSourceUtilities_DelimitNames_WithNullList_ShouldThrowArgumentException_Test()
		{
			// Arrange
			List<string> sourceNames = null;

			// Act & Assert
			var ex = Assert.Throws<ArgumentException>(() =>
				DataSourceUtilities.DelimitNames(sourceNames, DataSourceTypes.SqlServer));
			Assert.That(ex.Message, Does.Contain("Invalid argument"));
		}

		[Test]
		public void DataSourceUtilities_DelimitNames_WithEmptyList_ShouldReturnEmptyList_Test()
		{
			// Arrange
			var sourceNames = new List<string>();

			// Act
			var result = DataSourceUtilities.DelimitNames(sourceNames, DataSourceTypes.SqlServer);

			// Assert
			Assert.NotNull(result);
			Assert.That(result.Count, Is.EqualTo(0));
		}

		[Test]
		public void DataSourceUtilities_GetAvailableDataSourcesList_ShouldReturnCommaSeperatedList_Test()
		{
			// Arrange & Act
			var result = DataSourceUtilities.GetAvailableDataSourcesList();

			// Assert
			Assert.NotNull(result);
			Assert.That(result, Does.Contain("PostgreSQL"));
			Assert.That(result, Does.Contain("SqlServer"));
			Assert.That(result, Does.Contain(","));
		}

		[Test]
		public void DataSourceUtilities_MinimizeName_WithSqlServerBrackets_ShouldRemoveBrackets_Test()
		{
			// Arrange
			var sourceName = "[Users]";

			// Act
			var result = DataSourceUtilities.MinimizeName(sourceName);

			// Assert
			Assert.That(result, Is.EqualTo("Users"));
		}

		[Test]
		public void DataSourceUtilities_MinimizeName_WithPostgreSqlQuotes_ShouldRemoveQuotes_Test()
		{
			// Arrange
			var sourceName = "\"users\"";

			// Act
			var result = DataSourceUtilities.MinimizeName(sourceName);

			// Assert
			Assert.That(result, Is.EqualTo("users"));
		}

		[Test]
		public void DataSourceUtilities_MinimizeName_WithMixedDelimiters_ShouldRemoveAll_Test()
		{
			// Arrange
			var sourceName = "[Us\"ers]";

			// Act
			var result = DataSourceUtilities.MinimizeName(sourceName);

			// Assert
			Assert.That(result, Is.EqualTo("Users"));
		}

		[Test]
		public void DataSourceUtilities_MinimizeName_WithNoDelimiters_ShouldReturnUnchanged_Test()
		{
			// Arrange
			var sourceName = "Users";

			// Act
			var result = DataSourceUtilities.MinimizeName(sourceName);

			// Assert
			Assert.That(result, Is.EqualTo("Users"));
		}

		[Test]
		public void DataSourceUtilities_MinimizeName_WithNullSourceName_ShouldThrowArgumentException_Test()
		{
			// Arrange
			string sourceName = null;

			// Act & Assert
			var ex = Assert.Throws<ArgumentException>(() =>
				DataSourceUtilities.MinimizeName(sourceName));
			Assert.That(ex.Message, Does.Contain("Invalid argument"));
		}

		[Test]
		public void DataSourceUtilities_MinimizeNames_WithMultipleDelimitedNames_ShouldMinimizeAll_Test()
		{
			// Arrange
			var sourceNames = new List<string> { "[Users]", "\"orders\"", "[Products]" };

			// Act
			var result = DataSourceUtilities.MinimizeNames(sourceNames);

			// Assert
			Assert.That(result.Count, Is.EqualTo(3));
			Assert.That(result[0], Is.EqualTo("Users"));
			Assert.That(result[1], Is.EqualTo("orders"));
			Assert.That(result[2], Is.EqualTo("Products"));
		}

		[Test]
		public void DataSourceUtilities_MinimizeNames_WithNullList_ShouldThrowArgumentException_Test()
		{
			// Arrange
			List<string> sourceNames = null;

			// Act & Assert
			var ex = Assert.Throws<ArgumentException>(() =>
				DataSourceUtilities.MinimizeNames(sourceNames));
			Assert.That(ex.Message, Does.Contain("Invalid argument"));
		}

		[Test]
		public void DataSourceUtilities_MinimizeNames_WithEmptyList_ShouldReturnEmptyList_Test()
		{
			// Arrange
			var sourceNames = new List<string>();

			// Act
			var result = DataSourceUtilities.MinimizeNames(sourceNames);

			// Assert
			Assert.NotNull(result);
			Assert.That(result.Count, Is.EqualTo(0));
		}

		[Test]
		public void DataSourceUtilities_ResolveDataSources_WithSqlServer_ShouldReturnSqlServerType_Test()
		{
			// Arrange & Act
			var result = DataSourceUtilities.ResolveDataSources("SqlServer");

			// Assert
			Assert.That(result, Is.EqualTo(DataSourceTypes.SqlServer));
		}

		[Test]
		public void DataSourceUtilities_ResolveDataSources_WithPostgreSQL_ShouldReturnPostgreSQLType_Test()
		{
			// Arrange & Act
			var result = DataSourceUtilities.ResolveDataSources("PostgreSQL");

			// Assert
			Assert.That(result, Is.EqualTo(DataSourceTypes.PostgreSQL));
		}

		[Test]
		public void DataSourceUtilities_ResolveDataSources_WithCaseInsensitiveSqlServer_ShouldResolve_Test()
		{
			// Arrange & Act
			var result = DataSourceUtilities.ResolveDataSources("sqlserver");

			// Assert
			Assert.That(result, Is.EqualTo(DataSourceTypes.SqlServer));
		}

		[Test]
		public void DataSourceUtilities_ResolveDataSources_WithCaseInsensitivePostgreSQL_ShouldResolve_Test()
		{
			// Arrange & Act
			var result = DataSourceUtilities.ResolveDataSources("postgresql");

			// Assert
			Assert.That(result, Is.EqualTo(DataSourceTypes.PostgreSQL));
		}

		[Test]
		public void DataSourceUtilities_ResolveDataSources_WithInvalidType_ShouldReturnUnrecognized_Test()
		{
			// Arrange & Act
			var result = DataSourceUtilities.ResolveDataSources("InvalidType");

			// Assert
			Assert.That(result, Is.EqualTo(DataSourceTypes.Unrecognized));
		}

		[Test]
		public void DataSourceUtilities_ResolveDataSources_WithEmptyString_ShouldThrowArgumentException_Test()
		{
			// Arrange & Act & Assert
			var ex = Assert.Throws<ArgumentException>(() =>
				DataSourceUtilities.ResolveDataSources(""));
			Assert.That(ex.Message, Does.Contain("Invalid argument"));
		}

		[Test]
		public void DataSourceUtilities_ResolveDataSources_WithNull_ShouldThrowArgumentException_Test()
		{
			// Arrange & Act & Assert
			var ex = Assert.Throws<ArgumentException>(() =>
				DataSourceUtilities.ResolveDataSources(null));
			Assert.That(ex.Message, Does.Contain("Invalid argument"));
		}
	}
}

