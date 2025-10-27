using DbLayer.Data.Models;
using DbLayer.Helper;

namespace DbLayer.Interfaces
{
	public interface IHomeRepository
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		Task<List<Tasks>> GetTasks();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Tasks> GetTaskById(int id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="status"></param>
		/// <returns></returns>
		Task<List<Tasks>> GetTaskByStatus(OStatus status);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		Task<Response> Add(Tasks task);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		Task<Response> Update(Tasks task);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Response> Delete(int id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		Task<Response> UpdateStatus(int id, OStatus status);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="title"></param>
		/// <returns></returns>
		Task<bool> IsTitleExist(string title);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<bool> IsTaskExists(int id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<string> GetTaskTitleById(int id);
	}
}
