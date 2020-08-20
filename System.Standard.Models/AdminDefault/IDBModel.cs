using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace System.Standard.Models.AdminDefault
{
	public partial interface IDBModel
	{
		[Key]
		Guid Id { get; set; }
		DateTime CreatedDate { get; set; }
	}
}
