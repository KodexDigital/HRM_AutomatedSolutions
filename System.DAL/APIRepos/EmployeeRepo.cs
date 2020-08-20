using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Standard.DAL.Admin.IRepos;
using System.Standard.DAL.Admin.Repos;
using System.Standard.DAL.Data;
using System.Standard.DAL.IAPIRepos;
using System.Standard.Models.DataModels;
using System.Text;
using System.Threading.Tasks;

namespace System.Standard.DAL.APIRepos
{
	public class EmployeeRepo : AdminRepository<Employee>, IEmployeeRepo
	{
		private readonly ApplicationDBContext appDbContex;

		public EmployeeRepo(ApplicationDBContext appDbContex) : base(appDbContex)
		{
			this.appDbContex = appDbContex;
		}

		public async Task<Employee> CreateEmployee(Employee employee)
		{
			var result = await appDbContex.Employees.AddAsync(employee);
			await appDbContex.SaveChangesAsync();
			return result.Entity;
		}

		public async Task<Employee> GetEmployeeByEmail(string serchByEmail)
		{
			return await appDbContex.Employees.SingleOrDefaultAsync(e => e.Email.Equals(serchByEmail));
		}

		public async Task<Employee> GetEmployeeByName(string serchByName)
		{
			return await appDbContex.Employees.SingleOrDefaultAsync(e => e.Name.Equals(serchByName));
		}

		public async Task<Employee> GetEmployeeByPhone(string serchByPhone)
		{
			return await appDbContex.Employees.SingleOrDefaultAsync(e => e.Email.Equals(serchByPhone));
		}

		public IEnumerable<SelectListItem> GetEmployeeForDropDown()
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Employee>> GetEmployees()
		{
			return await appDbContex.Employees.ToListAsync();
		}

		public void Update(Employee employee)
		{
			var objFromDB = appDbContex.Employees.FirstOrDefault(e => e.Id.Equals(employee.Id));
			if (objFromDB != null) 
			{
				objFromDB.Name = employee.Name;
				objFromDB.ContactAddress = employee.ContactAddress;
				objFromDB.CurrentStatus = employee.CurrentStatus;
				objFromDB.DateOfEmployment = employee.DateOfEmployment;
				objFromDB.Email = employee.Email;
				objFromDB.EmergencyContactNumber = employee.EmergencyContactNumber;
				objFromDB.MaritalStatus = employee.MaritalStatus;
				objFromDB.PhoneNumber = employee.PhoneNumber;
				objFromDB.PreviousPlaceOfWork = employee.PreviousPlaceOfWork;
				objFromDB.PreviousSalaryEarned = employee.PreviousSalaryEarned;
			}
			appDbContex.SaveChanges();
		}


		public void Dispose()
		{
			appDbContex.Dispose();
		}

	}
}
