

using Microsoft.AspNetCore.Identity;
using System.Standard.Models.AdminDefault;

namespace System.Standard.DAL.Data
{
	public partial class ApplicationUserExtended : IdentityUser, IPSeudoDeletable
	{
		public string Street { get; set; }
		public DateTime DateOfBirth { get; set; }
		public bool Delete { get; set; }
	}
}
