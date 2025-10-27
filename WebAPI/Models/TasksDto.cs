using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
	public class TasksDto
	{
		public int Id                      { get; set; }

		[Required]
		public string Title       { get; set; }

		[Required]
		public string Description { get; set; }

		public int OsId                    { get; set; }
	}
}
