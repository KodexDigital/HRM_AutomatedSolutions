using System;
using System.Collections.Generic;
using System.Text;

namespace HRM_Automated.Core.Transfers
{
	public class ResponeBody : IResponeBody
	{
		public string Id { get; set; }
		public string Stause { get; set; }
		public string Messagge { get; set; }
	}
}
