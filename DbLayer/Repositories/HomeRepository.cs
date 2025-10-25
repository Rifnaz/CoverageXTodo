using DbLayer.Data;
using DbLayer.Data.Models;
using DbLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DbLayer.Repositories
{
	public class HomeRepository : IHomeRepository
	{
		private readonly AppDbContext _dbContext;

		public HomeRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task<List<Tasks>> GetTasks()
		{
			return await _dbContext.Tasks.ToListAsync();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Tasks> GetTaskById(int id)
		{
			var task = await _dbContext.Tasks.FindAsync(id);

			if(task != null)
				return task;

			return new Tasks();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		public async Task<(bool succeed, string message)> Add(Tasks task)
		{
			try
			{
				_dbContext.Tasks.Add(task);

				await _dbContext.SaveChangesAsync();

				return (true, "Task Added.");
			}
			catch (Exception ex)
			{
				return (false, ex.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		public async Task<(bool succeed, string message)> Update(Tasks task)
		{
			try
			{
				var exisitngTask = await _dbContext.Tasks.FindAsync(task.Id);

				if (exisitngTask == null)
					return (false, "Task not found.");

				exisitngTask.Title       = task.Title;
				exisitngTask.Description = task.Description;
				exisitngTask.OsId		 = task.OsId;
				exisitngTask.UpdatedDate = DateTime.Now;

				_dbContext.Tasks.Update(exisitngTask);

				await _dbContext.SaveChangesAsync();

				return (true, "Task Updated.");
			}
			catch (Exception ex)
			{
				return (false, ex.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<(bool succeed, string message)> Delete(int id)
		{
			try
			{
				var task = await _dbContext.Tasks.FindAsync(id);

				if (task == null)
					return (false, "Task not found.");

				_dbContext.Tasks.Remove(task);

				await _dbContext.SaveChangesAsync();

				return (true, "Task Deleted.");
			}
			catch (Exception ex)
			{
				return (false, ex.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="title"></param>
		/// <returns></returns>
		public async Task<bool> IsTitleExist(string title)
		{
			return await _dbContext.Tasks.AnyAsync(t => t.Title == title);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<bool> IsTaskExists(int id)
		{
			return await _dbContext.Tasks.AnyAsync(t => t.Id == id);
		}
	}
}
