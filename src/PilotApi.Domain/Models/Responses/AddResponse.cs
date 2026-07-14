namespace PilotApi.Domain.Models.Dto
{
	/// <summary>
	/// A response model for the Add method.
	/// </summary>
	public class AddResponse
	{
		/// <summary>
		/// Instantiate a <see cref="AddResponse"/> object.
		/// </summary>
		public AddResponse()
		{
		}

		/// <summary>
		/// Instantiate a <see cref="AddResponse"/> object.
		/// </summary>
		/// <param name="recordId">
		/// The Id of the new record, or a 0 if the add failed.
		/// </param>
		public AddResponse(long recordId)
		{
			this.Id = recordId;
		}

		/// <summary>
		/// The Id of the new record, or 0 if the add failed.
		/// </summary>
		public long Id { get; set; }
	}
}
