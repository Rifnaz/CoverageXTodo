using DbLayer.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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
			base.OnModelCreating(builder);
		}
	}
}
