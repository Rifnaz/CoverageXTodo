using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbLayer.Data.Models
{
	public class Tasks
	{

		[Key]
		public int Id                 { get; set; }

		public string Title            { get; set; }

		public string Description      { get; set; }

		public DateTime AddedDate               { get; set; }

		public DateTime? UpdatedDate            { get; set; }

		public int OsId                         { get; set; }
		
		[ForeignKey(nameof(OsId))]
		public OperationalStatus Status{ get; set; }
	}
}
