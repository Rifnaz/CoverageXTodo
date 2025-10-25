using System.ComponentModel.DataAnnotations;

namespace DbLayer.Data.Models
{
	public class OperationalStatus
	{
		[Key]
		public int Id                            { get; set; }

		public required string Title             { get; set; }

		public required string Description       { get; set; }

		public DateTime AddedDate                { get; set; }

		public DateTime? UpdatedDate             { get; set; }

		public ICollection<Tasks> Tasks          { get; set; }
	} 
}
