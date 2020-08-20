using System;
using System.Collections.Generic;
using System.Standard.DAL.Admin.IRepos;
using System.Standard.DAL.APIRepos;
using System.Standard.DAL.Data;
using System.Standard.DAL.IAPIRepos;
using System.Standard.Models.DataModels;
using System.Text;
using System.Threading.Tasks;

namespace System.Standard.DAL.Admin.Repos
{
	/// <summary>
	/// Impplementing the Unit of work interface
	/// </summary>
	public class Wrapper : IWrapper
	{
		private readonly ApplicationDBContext db;
		public Wrapper(ApplicationDBContext db)
		{
			this.db = db;
			Employee = new EmployeeRepo(db);
		}

		public IEmployeeRepo Employee { get; private set; }

		public void Save()
		{
			db.SaveChanges();
		}

		public void Dispose()
		{
			db.Dispose();
		}

		public async Task SaveChangesAsync()
		{
			await db.SaveChangesAsync();
		}
	}
}
