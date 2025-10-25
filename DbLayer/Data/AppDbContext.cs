using DbLayer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DbLayer.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{		
		}

		public DbSet<Tasks> Tasks { get; set; }

		public DbSet<OperationalStatus> OperationalStatuses { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			//builder.Entity<Tasks>()
			//	.HasOne(t => t.Status)
			//	.WithMany(s => s.Tasks)
			//	.HasForeignKey(t => t.OsId);


			base.OnModelCreating(builder);
		}
	}
}
