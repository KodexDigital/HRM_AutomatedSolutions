using System;
using System.Collections.Generic;
using System.Standard.Models.AdminDefault;
using System.Standard.Utility.Enums;
using System.Standard.Utility.Globals;
using System.Text;

namespace System.Standard.Models.DataModels
{
	public partial class Employee : BaseModel
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
		public string ToStringField
		{
			get { return EmployeeUniqeId = string.Format($"EMP/{CodeGenerator.EmployeeShorCode}"); }
		}

		//Employee file creator: TO DO
	}
}
