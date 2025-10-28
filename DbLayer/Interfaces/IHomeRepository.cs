using DbLayer.Data.Models;
using DbLayer.Helper;

namespace DbLayer.Interfaces
{
	public interface IHomeRepository
	{
		/// <summary>
		/// Get all tasks ordered by AddedDate descending (latest on top)
		/// </summary>
		/// <returns></returns>
		Task<List<Tasks>> GetTasks();

		/// <summary>
		/// Get task by Id if exists else return new Tasks object
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Tasks> GetTaskById(int id);

		/// <summary>
		/// Get tasks by status ordered by AddedDate descending (latest on top)
		/// </summary>
		/// <param name="status"></param>
		/// <returns></returns>
		Task<List<Tasks>> GetTaskByStatus(OStatus status);

		/// <summary>
		/// Add new task to database with current date time as AddedDate and Pending as status
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		Task<Response> Add(Tasks task);

		/// <summary>
		/// Update task if exists by Id and new details
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		Task<Response> Update(Tasks task);

		/// <summary>
		/// Delete task by id if exists
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Response> Delete(int id);

		/// <summary>
		/// Update task status by Id and status and set UpdatedDate to current date time
		/// </summary>
		/// <param name="id"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		Task<Response> UpdateStatus(int id, OStatus status);

		/// <summary>
		/// Check if Title already exists
		/// </summary>
		/// <param name="title"></param>
		/// <returns></returns>
		Task<bool> IsTitleExist(string title);

		/// <summary>
		/// Check if Task exists by Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<bool> IsTaskExists(int id);

		/// <summary>
		/// Get Task Title by Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<string> GetTaskTitleById(int id);
	}
}
