using System;
using System.Collections.Generic;

namespace PilotApi.Shared.Contracts.Configuration.Base
{
	/// <summary>
	/// An interface for the base configuration class.
	/// </summary>
	public interface IConfigurationBase
	{
		/// <summary>
		/// Gets or sets a flag that indicates whether this settigs object is active.
		/// </summary>
		bool Active { get; set; }

		/// <summary>
		/// Validate the data in the current obect.
		/// </summary>
		/// <param name="exceptions">
		/// A list of exceptions.
		/// </param>
		void Validate(ref List<Exception> exceptions);
	}
}
