using System.Collections.Generic;

namespace PilotApi.Shared.Constants
{
	/// <summary>
	/// Constants for the available key column data types.
	/// </summary>
	public static class KeyColumnDataTypeConstants
	{
		/// <summary>
		/// int.
		/// </summary>
		public const string Int = "int";

		/// <summary>
		/// string.
		/// </summary>
		public const string String = "string";

		/// <summary>
		/// string.
		/// </summary>
		public static List<string> AvailableOptions = new List<string>
		{
			Int,
			String
		};
	}
}
