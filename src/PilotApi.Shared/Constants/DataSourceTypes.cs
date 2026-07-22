namespace PilotApi.Shared.Constants
{
	/// <summary>
	/// Enums for the available data sources.
	/// </summary>
	public enum DataSourceTypes
	{
		/// <summary>
		/// Not a valid value - used to indicate failure to assign.
		/// </summary>
		Unrecognized,
		/// <summary>
		/// PostGreSQL
		/// </summary>
		PostgreSQL,
		/// <summary>
		/// Microsoft SQL Server
		/// </summary>
		SqlServer
	}
}
