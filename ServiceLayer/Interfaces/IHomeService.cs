using DbLayer.Data.Models;
using DbLayer.Helper;

namespace ServiceLayer.Interfaces
{
	public interface IHomeService
	{
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
	}
}
