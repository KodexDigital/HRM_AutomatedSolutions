
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Standard.Models.DataModels;

namespace System.Standard.DAL.Data
{
	public class ApplicationDBContext : IdentityDbContext<ApplicationUserExtended>
	{
		public ApplicationDBContext()
		{

		}
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> contextOptions) : base(contextOptions)
		{
		}

		public DbSet<Employee> Employees { get; set; }

	}
}
