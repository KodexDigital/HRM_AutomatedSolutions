using System;
using System.Collections.Generic;
using System.Text;

namespace System.Standard.Models.AdminDefault
{
	public partial class BaseModel : IDBModel
	{
		public Guid Id { get; set; }
		public DateTime CreatedDate { get; set; }

		public BaseModel()
		{
			CreatedDate = DateTime.Now;
		}
	}
}
