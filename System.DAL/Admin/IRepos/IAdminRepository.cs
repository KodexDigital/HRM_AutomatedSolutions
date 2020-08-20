using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace System.Standard.DAL.Admin.IRepos
{
	public interface IAdminRepository<T> where T : class
	{
		T Get(int id);
		T Get(Guid id);
		T Get(string id);
		IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, 
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
			string includeProperties = null);
		T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, 
			string includeProperties = null);
		void Add(T entity);
		void Remove(int id);
		void Remove(Guid id);
		void Remove(string id);
		void Remove(T entity);

	}
}
