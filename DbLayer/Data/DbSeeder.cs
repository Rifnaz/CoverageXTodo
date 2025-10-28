using DbLayer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DbLayer.Data
{
	public static class DbSeeder
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		public static void SeedData(AppDbContext context)
		{
			try
			{
				SeedOperationalStatuses(context);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Seeding failed: {ex.Message}");
				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		private static void SeedOperationalStatuses(AppDbContext context)
		{
			if (!context.OperationalStatuses.Any())
			{
				using (var transaction = context.Database.BeginTransaction())
				{
					try
					{
						// Enable inserting explicit ID values
						context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT OperationalStatuses ON");

						var statuses = new List<OperationalStatus>
						{
							new OperationalStatus
							{
								Id = 1,
								Title = "Pending",
								Description = "Task to be started",
								AddedDate = DateTime.UtcNow
							},
							new OperationalStatus
							{
								Id = 3,
								Title = "Completed",
								Description = "Task has been completed",
								AddedDate = DateTime.UtcNow
							}
						};

						context.OperationalStatuses.AddRange(statuses);
						context.SaveChanges();

						// Disable inserting explicit ID values
						context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT OperationalStatuses OFF");

						transaction.Commit();

						Console.WriteLine("✓ Seeded OperationalStatus data with IDs: 1, 2, 3");
					}
					catch
					{
						transaction.Rollback();
						throw;
					}
				}
			}
			else
			{
				Console.WriteLine("✓ OperationalStatus data already exists");
			}
		}
	}
}

