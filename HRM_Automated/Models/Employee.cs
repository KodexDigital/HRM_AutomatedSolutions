using System;
using System.Collections.Generic;
using System.Linq;
using System.Standard.Utility.Enums;
using System.Threading.Tasks;

namespace HRM_Automated.Models
{
	public class Employee
	{
		public string Name { get; set; }
		public string PhoneNumber { get; set; }
		public string EmergencyContactNumber { get; set; }
		public string Email { get; set; }
		public string ContactAddress { get; set; }
		public string PreviousPlaceOfWork { get; set; }
		public string PreviousSalaryEarned { get; set; }
		public EmployeeCurrentStatus CurrentStatus { get; set; }
		public MaritalStatus MaritalStatus { get; set; }
		public string EmployeeUniqeId { get; set; }
		public string DateOfEmployment { get; set; }
		public string ToStringField { get; set; }
		public bool Delete { get; set; }
	}
}
