using System;
using System.Collections.Generic;
using System.Text;

namespace System.Standard.Models.AdminDefault
{
	public partial interface IPSeudoDeletable
	{
		///	This is used for partially deleting a record
		bool Delete { get; set; }
	}
}
