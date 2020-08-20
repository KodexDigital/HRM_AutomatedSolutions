using System;
using System.Collections.Generic;
using System.Text;

namespace System.Standard.Utility.Globals
{
	public static class CodeGenerator
	{
		static DateTime dt = new DateTime();
		static int Month = dt.Month;
		static int Year = dt.Year;

		static Guid TruckEmpID = Guid.Empty;

		public static readonly string EmployeeShorCode = Month.ToString() + Year.ToString() + "/" + TruckEmpID.ToString().Substring(0, 3).ToUpper();
	}
}
