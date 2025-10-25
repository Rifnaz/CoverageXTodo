using DbLayer.Data.Models;

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
	}
}
