using System;
using System.Collections.Generic;
using System.Text;

namespace System.Standard.Utility.Api
{
	public static partial class EndpointConnect
	{
		public static readonly string BaseAddress = "https://localhost:44338/";

		//Employee services endoints
		public static readonly string GetAllEmployee = "api/Employee/get-all-employee";
		public static readonly string GetEmployeeById = "api/Employee/get-employee-by-Id";
		public static readonly string GetEmployeeByName = "api/Employee/get-employee-by-name";
		public static readonly string GetEmployeeByNumber = "api/Employee/get-employee-by-phone-number";
		public static readonly string GetEmployeeByEmail = "api/Employee/get-employee-by-email";
		public static readonly string CreateNewEmployee = "api/Employee/create-new-employee";


	}
}

