using DbLayer.Data.Models;

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
		Task<(bool succeed, string message)> Add(Tasks task);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		Task<(bool succeed, string message)> Update(Tasks task);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<(bool succeed, string message)> Delete(int id);
	}
}
