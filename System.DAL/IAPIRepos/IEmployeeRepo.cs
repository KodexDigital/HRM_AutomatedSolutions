using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Standard.DAL.Admin.IRepos;
using System.Standard.Models.DataModels;
using System.Text;
using System.Threading.Tasks;

namespace System.Standard.DAL.IAPIRepos
{
	public partial interface IEmployeeRepo : IDisposable, IAdminRepository<Employee>
	{
		Task<IEnumerable<Employee>> GetEmployees();
		Task<Employee> GetEmployeeByName(string serchByName);
		Task<Employee> GetEmployeeByEmail(string serchByEmail);
		Task<Employee> GetEmployeeByPhone(string serchByPhone);
		Task<Employee> CreateEmployee(Employee employee);
		IEnumerable<SelectListItem> GetEmployeeForDropDown();
		void Update(Employee employee);
	}
}
