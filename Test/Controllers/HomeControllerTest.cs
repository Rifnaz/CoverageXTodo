using DbLayer.Data.Models;
using DbLayer.Helper;
using Moq;
using ServiceLayer.Interfaces;
using WebAPI.Controllers;

namespace Test.Controllers
{
	public class HomeControllerTest
	{
		private readonly Mock<IHomeService> _mockService;
		private readonly HomeController _controller;

		public HomeControllerTest()
		{
			_mockService = new Mock<IHomeService>();
			_controller = new HomeController(_mockService.Object);
		}

		/// <summary>
		/// Test for Get method to ensure it returns list of TasksDto
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task Get_ShouldReturnListOfTasksDto()
		{
			// Arrange
			_mockService.Setup(s => s.GetTasks()).ReturnsAsync(new List<Tasks>
			{
				new Tasks { Id = 1, Title = "Test", Description = "Desc", OsId = 1 }
			});

			// Act
			var result = await _controller.Get();

			// Assert
			Assert.NotNull(result);
			Assert.Single(result);
			Assert.Equal("Test", result[0].Title);
		}

		/// <summary>
		/// Test for GetByOsId method to ensure it returns list of Tasks by OsId
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task Get_ShouldReturnListofTasksByOsId()
		{
			// Arrange
			_mockService.Setup(s => s.GetTaskByStatus((OStatus)1)).ReturnsAsync(new List<Tasks>
			{
				new Tasks { Id = 2, Title = "Test2", Description = "Desc2", OsId = 1 }
			});

			// Act
			var result = await _controller.GetByOsId((int)OStatus.Pending);

			// Assert
			Assert.NotNull(result);
			Assert.Equal((int)OStatus.Pending, result[0].OsId);
		}
	}
}
