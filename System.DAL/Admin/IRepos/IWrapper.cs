using System;
using System.Collections.Generic;
using System.Standard.DAL.IAPIRepos;
using System.Text;
using System.Threading.Tasks;

namespace System.Standard.DAL.Admin.IRepos
{
	/// <summary>
	/// Unit of work for all the APIs
	/// </summary>
	public interface IWrapper : IDisposable
	{
		IEmployeeRepo Employee { get;}
		void Save();
		Task SaveChangesAsync();
	}
}
