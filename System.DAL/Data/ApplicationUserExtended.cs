

using Microsoft.AspNetCore.Identity;

namespace System.Standard.DAL.Data
{
	public partial class ApplicationUserExtended : IdentityUser
	{
		public string Street { get; set; }
	}
}
