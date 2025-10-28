using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using WebAPI.Models;
using DbLayer.Data.Models;
using DbLayer.Helper;
using Azure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		private readonly IHomeService _homeService;

		public HomeController(IHomeService homeService)
		{
			_homeService = homeService;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<List<TasksDto>> Get()
		{
			var tasks = await _homeService.GetTasks();

			return await MakeTaskDtoList(tasks);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public async Task<TasksDto> Get(int id)
		{
			var task = await _homeService.GetTaskById(id);

			return await MakeTaskDto(task);
		}

		/// <summary>
        /// 
        /// </summary>
        /// <param name="osId"></param>
        /// <returns></returns>
		[HttpGet("byOs/{osId}")]
		public async Task<List<TasksDto>> GetByOsId(int osId)
		{
			var tasks = await _homeService.GetTaskByStatus((OStatus)osId);

			return await MakeTaskDtoList(tasks);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] TasksDto model)
		{
			if (!ModelState.IsValid)
				return BadRequest("Model is not valid");

			var task = await MakeTask(model);

			var result = await _homeService.Add(task);

			if(!result.Succeed)
				return BadRequest(result);

			return Ok(result);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] TasksDto model)
		{
			if (!ModelState.IsValid)
				return BadRequest("Model is not valid");

			var task = await MakeTask(model);

			var result = await _homeService.Update(task);

			if (!result.Succeed)
				return BadRequest(result);

			return Ok(result);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _homeService.Delete(id);

			if(!result.Succeed)
				BadRequest(result);

			return Ok(result);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		[HttpPut("{id}/{osId}")]
		public async Task<IActionResult> UpdateStatus(int id, int osId)
		{
			var status = osId == (int)OStatus.Completed ? OStatus.Pending : OStatus.Completed;

			var result = await _homeService.UpdateStatus(id, status);

			if (!result.Succeed)
				return BadRequest(result);

			return Ok(result);
		}

		#region Helper Methods

		/// <summary>
        /// 
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
		private async Task<List<TasksDto>> MakeTaskDtoList(List<Tasks> tasks)
		{
			var result = new List<TasksDto>();

			if (tasks != null && tasks.Any())
			{
				foreach (var task in tasks)
				{
					var dto = await MakeTaskDto(task);

					result.Add(dto);
				}
			}

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		private async Task<TasksDto> MakeTaskDto(Tasks task)
		{
			if (task == null)
				return new TasksDto();

			return new TasksDto
			{
				Id = task.Id,
				Title = task.Title,
				Description = task.Description,
				OsId = task.OsId
			};
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		private async Task<Tasks> MakeTask(TasksDto task)
		{
			return new Tasks
			{
				Id = task.Id,
				Title = task.Title,
				Description = task.Description,
				OsId = task.OsId
			};
		}
		
		#endregion
	}
}
