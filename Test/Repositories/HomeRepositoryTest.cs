using DbLayer.Data;
using DbLayer.Data.Models;
using DbLayer.Helper;
using DbLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Test.Repositories
{
	public class HomeRepositoryTest
	{
		private AppDbContext GetDbContext()
		{
			var options = new DbContextOptionsBuilder<AppDbContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // unique for each test
				.Options;

			var context = new AppDbContext(options);
			return context;
		}

		private HomeRepository GetRepository(AppDbContext context)
		{
			return new HomeRepository(context);
		}

		/// <summary>
		/// Test for GetTasks method to ensure it returns all tasks
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task GetTasks_ReturnsAllTasks()
		{
			// Arrange
			var context = GetDbContext();
			context.Tasks.Add(new Tasks { Title = "Task 1", Description = "Test Description", AddedDate = DateTime.Now });
			context.Tasks.Add(new Tasks { Title = "Task 2", Description = "Test Description", AddedDate = DateTime.Now });
			await context.SaveChangesAsync();
			var repository = GetRepository(context);

			// Act
			var tasks = await repository.GetTasks();

			// Assert
			Assert.Equal(2, tasks.Count);
		}

		/// <summary>
		/// Test for Add method to ensure it adds a new task
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task Add_ShouldAddNewTask()
		{
			// Arrange
			var context = GetDbContext();
			var repo = new HomeRepository(context);

			var task = new Tasks 
			{ 
				Title       = "New Task", 
				Description = "Testing Add",
				AddedDate   = DateTime.Now,
				OsId        = (int)OStatus.Pending
			};

			// Act
			var result = await repo.Add(task);
			var saved = context.Tasks.FirstOrDefault();

			// Assert
			Assert.True(result.Succeed);
			Assert.NotNull(saved);
			Assert.Equal("New Task", saved.Title);
		}

		/// <summary>
		/// Test for Update Method modify existing task
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task Update_ShouldModifyTask()
		{
			// Arrange
			var context = GetDbContext();
			var task = new Tasks
			{
				Title       = "Task 3",
				Description = "Test Description",
				OsId        = (int)OStatus.Pending,
				AddedDate   = DateTime.Now
			};

			context.Tasks.Add(task);
			await context.SaveChangesAsync();

			var updatedTitle = "Task 4";

			// Act
			var repo = GetRepository(context);
			task.Title = updatedTitle;

			var result = await repo.Update(task);
			var saved = await context.Tasks.FindAsync(task.Id);

			// Assert
			Assert.True(result.Succeed);
			Assert.Equal(updatedTitle, saved.Title);
		}

		/// <summary>
		/// Test for Delete method, removes the task
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task Delete_ShouldRemoveTask()
		{
			// Arrange
			var context = GetDbContext();
			var task = new Tasks
			{
				Title       = "Task 5",
				Description = "Test Description",
				OsId        = (int)OStatus.Pending,
				AddedDate   = DateTime.Now
			};

			context.Tasks.Add(task);
			await context.SaveChangesAsync();

			// Act
			var repo = new HomeRepository(context);
			var result = await repo.Delete(task.Id);

			// Assert
			Assert.True(result.Succeed);
			Assert.Empty(context.Tasks);
		}
		
		/// <summary>
		/// Test for Update the operational status
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task UpdateStatus_ShouldChangeStatus()
		{
			// Arrange
			var context = GetDbContext();
			var task = new Tasks
			{
				Title       = "Task 6",
				Description = "Test Description",
				OsId        = (int)OStatus.Pending,
				AddedDate   = DateTime.Now
			};

			context.Tasks.Add(task);
			await context.SaveChangesAsync();

			var updatedStatus = OStatus.Completed;

			// Act
			var repo = new HomeRepository(context);
			var result = await repo.UpdateStatus(task.Id, updatedStatus);
			var saved = await context.Tasks.FindAsync(task.Id);

			// Assert
			Assert.True(result.Succeed);
			Assert.Equal((int)updatedStatus, saved.OsId);
		}
	}

}
