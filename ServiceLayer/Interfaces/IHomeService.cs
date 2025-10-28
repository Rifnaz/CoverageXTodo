using DbLayer.Data.Models;
using DbLayer.Helper;

namespace ServiceLayer.Interfaces
{
	public interface IHomeService
	{
		Task<List<Tasks>> GetTasks();

		/// <summary>
		/// Get all tasks
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Tasks> GetTaskById(int id);

		/// <summary>
		/// Get task by id
		/// </summary>
		/// <param name="status"></param>
		/// <returns></returns>
		Task<List<Tasks>> GetTaskByStatus(OStatus status);

		/// <summary>
		/// Get task by status
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		Task<Response> Add(Tasks task);

		/// <summary>
		/// Add new task if title not exist otherwise return error response
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		Task<Response> Update(Tasks task);

		/// <summary>
		/// Update task if exists and title not taken otherwise return error response
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Response> Delete(int id);

		/// <summary>
		/// Delete task if exists otherwise return error response
		/// </summary>
		/// <param name="id"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		Task<Response> UpdateStatus(int id, OStatus status);
	}
}
