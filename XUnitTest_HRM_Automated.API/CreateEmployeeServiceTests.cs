using Microsoft.Extensions.DependencyInjection;
using System;
using System.Standard.DAL.Admin.IRepos;
using System.Standard.DAL.IAPIRepos;
using System.Standard.Models.DataModels;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest_HRM_Automated.API
{
	public class CreateEmployeeServiceTests
	{
		[Fact]
		public async Task CreateEmployee()
		{
			var services = new ServiceCollection();
			//services.BuildServiceProvider();
			var serviceProvider = services.BuildServiceProvider();
			var service = serviceProvider.GetRequiredService<IWrapper>();

			var createdTask = await service.Employee.CreateEmployee(new Employee
			{
				Name = "Testing",
				PhoneNumber = "04583",
				ContactAddress ="new testin",
			});

			Assert.Equal("201", "404");
		}

		[Fact]
		public async Task GetAllEmployee()
		{
			var services = new ServiceCollection();
			var serviceProvider = services.BuildServiceProvider();
			var service = serviceProvider.GetRequiredService<IEmployeeRepo>();

			var task = await service.GetEmployees();
			Assert.NotEmpty(task);
		}


		//[Fact]
		//public async Task Delete_Todo()
		//{
		//	var services = new ServiceCollection();
		//	services.UseServices();
		//	var serviceProvider = services.BuildServiceProvider();

		//	var service = serviceProvider.GetRequiredService<ITodoService>();

		//	await service.DeleteTodoAsync(1);
		//}

		//[Fact]
		//public async Task Get_Existing_Todo()
		//{
		//	var services = new ServiceCollection();
		//	services.UseServices();
		//	var serviceProvider = services.BuildServiceProvider();

		//	var service = serviceProvider.GetRequiredService<ITodoService>();

		//	var task = await service.GetTodoAsync(1);

		//	Assert.NotNull(task);
		//}

		//[Fact]
		//public async Task Update_Todo()
		//{
		//	var services = new ServiceCollection();
		//	services.UseServices();
		//	var serviceProvider = services.BuildServiceProvider();

		//	var service = serviceProvider.GetRequiredService<ITodoService>();

		//	var updatedTask = await service.UpdateTodoAsync(new Todo
		//	{
		//		Id = 1,
		//		UserId = 1,
		//		Title = "something",
		//		IsCompleted = true
		//	});

		//	Assert.True(updatedTask.IsCompleted);
		//}

	}
}
