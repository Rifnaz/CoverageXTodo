using DbLayer.Data;
using DbLayer.Data.Models;
using DbLayer.Helper;
using DbLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
		/// Get all tasks ordered by AddedDate descending (latest on top)
		/// </summary>
		/// <returns></returns>
		public async Task<List<Tasks>> GetTasks()
		{
			return await _dbContext.Tasks.OrderByDescending(x => x.AddedDate).ToListAsync();
		}

		/// <summary>
		/// Get task by Id if exists else return new Tasks object
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Tasks> GetTaskById(int id)
		{
			var task = await _dbContext.Tasks.FindAsync(id);

			if (task != null)
				return task;

			return new Tasks();
		}

		/// <summary>
		/// Get tasks by status ordered by AddedDate descending (latest on top)
		/// </summary>
		/// <param name="status"></param>
		/// <returns></returns>
		public async Task<List<Tasks>> GetTaskByStatus(OStatus status)
		{
			return await _dbContext.Tasks.Where(x => x.OsId == (int)status)
										 .OrderByDescending(x => x.AddedDate)
										 .ToListAsync();
		}

		/// <summary>
		/// Add new task to database with current date time as AddedDate and Pending as status
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		public async Task<Response> Add(Tasks task)
		{
			try
			{
				task.AddedDate = DateTime.Now;
				task.OsId      = (int)OStatus.Pending;

				_dbContext.Tasks.Add(task);

				await _dbContext.SaveChangesAsync();

				return new Response(true, "Task Added.");
			}
			catch (Exception ex)
			{
				return new Response(false, ex.Message);
			}
		}

		/// <summary>
		/// Update task if exists by Id and new details
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		public async Task<Response> Update(Tasks task)
		{
			try
			{
				var exisitngTask = await _dbContext.Tasks.FindAsync(task.Id);

				if (exisitngTask == null)
					return new Response(false, "Task not found.");

				exisitngTask.Title       = task.Title;
				exisitngTask.Description = task.Description;
				exisitngTask.OsId        = task.OsId;
				exisitngTask.UpdatedDate = DateTime.Now;

				_dbContext.Tasks.Update(exisitngTask);

				await _dbContext.SaveChangesAsync();

				return new Response(true, "Task Updated.");
			}
			catch (Exception ex)
			{
				return new Response(false, ex.Message);
			}
		}

		/// <summary>
		/// Delete task by id if exists
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Response> Delete(int id)
		{
			try
			{
				var task = await _dbContext.Tasks.FindAsync(id);

				if (task == null)
					return new Response(false, "Task not found.");

				_dbContext.Tasks.Remove(task);

				await _dbContext.SaveChangesAsync();

				return new Response(true, "Task Deleted.");
			}
			catch (Exception ex)
			{
				return new Response(false, ex.Message);
			}
		}

		/// <summary>
		/// Update task status by Id and status and set UpdatedDate to current date time
		/// </summary>
		/// <param name="id"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		public async Task<Response> UpdateStatus(int id, OStatus status)
		{
			try
			{
				var task = await _dbContext.Tasks.FindAsync(id);

				if (task == null)
					return new Response(false, "Task not found.");

				task.OsId        = (int)status;
				task.UpdatedDate = DateTime.Now;

				_dbContext.Tasks.Update(task);

				await _dbContext.SaveChangesAsync();

				return new Response(true, "Task Updated.");
			}
			catch (Exception ex)
			{
				return new Response(false, ex.Message);
			}
		}

		/// <summary>
		/// Check if Title already exists
		/// </summary>
		/// <param name="title"></param>
		/// <returns></returns>
		public async Task<bool> IsTitleExist(string title)
		{
			return await _dbContext.Tasks.AnyAsync(t => t.Title == title);
		}

		/// <summary>
		/// Check if Task exists by Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<bool> IsTaskExists(int id)
		{
			return await _dbContext.Tasks.AnyAsync(t => t.Id == id);
		}

		/// <summary>
		/// Get Task Title by Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> GetTaskTitleById(int id)
		{
			return await _dbContext.Tasks.Where(x => x.Id == id).Select(x => x.Title).FirstOrDefaultAsync();
		}
	}
}
