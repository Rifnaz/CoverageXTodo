using DbLayer.Data.Models;
using DbLayer.Helper;
using DbLayer.Interfaces;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
	public class HomeService : IHomeService
	{
		private readonly IHomeRepository _homeRepository;

		public HomeService(IHomeRepository homeRepository)
		{
			_homeRepository = homeRepository;
		}

		/// <summary>
		/// Get all tasks
		/// </summary>
		/// <returns></returns>
		public async Task<List<Tasks>> GetTasks()
		{
			return await _homeRepository.GetTasks();
		}

		/// <summary>
		/// Get task by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Tasks> GetTaskById(int id)
		{
			return await _homeRepository.GetTaskById(id);
		}

		/// <summary>
		/// Get task by status
		/// </summary>
		/// <param name="status"></param>
		/// <returns></returns>
		public async Task<List<Tasks>> GetTaskByStatus(OStatus status)
		{
			return await _homeRepository.GetTaskByStatus(status);
		}

		/// <summary>
		/// Add new task if title not exist otherwise return error response
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		public async Task<Response> Add(Tasks task)
		{
			if(await _homeRepository.IsTitleExist(task.Title))
				return new Response(false, "Task title already taken.");

			return await _homeRepository.Add(task);
		}

		/// <summary>
		/// Update task if exists and title not taken otherwise return error response
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		public async Task<Response> Update(Tasks task)
		{
			if (!await _homeRepository.IsTaskExists(task.Id))
				return new Response(false, "Task not found.");

			var title = await _homeRepository.GetTaskTitleById(task.Id);

			if (title != task.Title && await _homeRepository.IsTitleExist(task.Title))
				return new Response(false, "Task title already taken.");			

			return await _homeRepository.Update(task);
		}

		/// <summary>
		/// Delete task if exists otherwise return error response
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Response> Delete(int id)
		{
			if (!await _homeRepository.IsTaskExists(id))
				return new Response(false, "Task not found.");

			return await _homeRepository.Delete(id);
		}

		/// <summary>
		/// Update task status if exists otherwise return error response
		/// </summary>
		/// <param name="id"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		public async Task<Response> UpdateStatus(int id, OStatus status)
		{
			if (!await _homeRepository.IsTaskExists(id))
				return new Response(false, "Task not found.");

			return await _homeRepository.UpdateStatus(id, status);
		}
	}
}
