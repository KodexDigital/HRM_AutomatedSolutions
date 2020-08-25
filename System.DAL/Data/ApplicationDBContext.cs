
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

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<ApplicationUserExtended> ApplicationUsers { get; set; }
		public DbSet<TodoItem> TodoItems { get; set; }

	}
}
