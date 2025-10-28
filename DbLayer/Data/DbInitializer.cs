using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DbLayer.Data
{
	public static class DbInitializer
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var scope = serviceProvider.CreateScope())
			{
				var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

				try
				{
					Console.WriteLine("=== Starting Database Setup ===");

					// Apply migrations (this will create the database and tables if they don't exist)
					Console.WriteLine("Applying database migrations...");
					db.Database.Migrate();
					Console.WriteLine("✓ Database migrations completed successfully");

					// Seed data
					Console.WriteLine("Starting database seeding...");
					DbSeeder.SeedData(db);
					Console.WriteLine("✓ Database seeding completed successfully");

					Console.WriteLine("=== Database Setup Complete ===");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"❌ Database setup failed: {ex.Message}");
					Console.WriteLine($"Stack trace: {ex.StackTrace}");

					if (ex.InnerException != null)
					{
						Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
					}

					throw; // Re-throw to prevent app from starting with broken DB
				}
			}
		}
	}
}