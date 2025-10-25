namespace WebAPI.Models
{
	public class OperationalStatusDto
	{
		public int Id { get; set; }

		public required string Title { get; set; }

		public required string Description { get; set; }

		public DateTime AddedDate { get; set; }

		public DateTime? UpdatedDate { get; set; }
	}
}
