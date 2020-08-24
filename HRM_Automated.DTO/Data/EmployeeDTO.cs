using HRM_Automated.Core.Transfers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Standard.Utility.Enums;
using System.Text;

namespace HRM_Automated.DTO.Data
{
	[DataContract]
	public class EmployeeDTO : ResponeBody
	{
		[DataMember(Name ="Name")]
		public string Name { get; set; }

		[Display(Name ="Phone number")]
		[DataMember(Name = "PhoneNumber")]
		public string PhoneNumber { get; set; }

		[Display(Name = "Emergency contact number")]
		[DataMember(Name = "EmergencyContactNumber")]
		public string EmergencyContactNumber { get; set; }

		[Display(Name = "Email address")]
		[DataMember(Name = "Email")]
		public string Email { get; set; }

		[Display(Name = "Contact address")]
		[DataMember(Name = "ContactAddress")]
		public string ContactAddress { get; set; }

		[Display(Name = "Previous place of work")]
		[DataMember(Name = "PreviousPlaceOfWork")]
		public string PreviousPlaceOfWork { get; set; }

		[Display(Name = "Previous salary earned")]
		[DataMember(Name = "PreviousSalaryEarned")]
		public string PreviousSalaryEarned { get; set; }

		[Display(Name = "Current status")]
		[DataMember(Name = "CurrentStatus")]
		public EmployeeCurrentStatus CurrentStatus { get; set; }

		[Display(Name = "Marital status")]
		[DataMember(Name = "MaritalStatus")]
		public MaritalStatus MaritalStatus { get; set; }

		[Display(Name = "Employee Id")]
		[DataMember(Name = "EmployeeUniqeId")]
		public string EmployeeUniqeId { get; set; }

		[Display(Name = "Date of employment")]
		[DataMember(Name = "DateOfEmployment")]
		public string DateOfEmployment { get; set; }

		[Display(Name = "Created date")]
		[DataMember(Name = "DateCreated")]
		public string DateCreated { get; set; }
	}
}
