using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Standard.DAL.Admin.IRepos;
using System.Text;

namespace System.Standard.DAL.Admin.Repos
{
	public class AdminRepository<T> : IAdminRepository<T> where T : class
	{
		private readonly DbContext dbContext;
		internal DbSet<T> dbSet;

		public AdminRepository(DbContext dbContext)
		{
			this.dbContext = dbContext;
			dbSet = dbContext.Set<T>();
		}
		public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public T Get(int id)
		{
			return dbSet.Find(id);
		}

		public T Get(Guid id)
		{
			return dbSet.Find(id);
		}

		public T Get(string id)
		{
			return dbSet.Find(id);
		}

		public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			if (filter != null)
				query.Where(filter);
			if (orderBy != null)
				return orderBy(query).ToList();
			if (includeProperties != null)
				foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
					query.Include(includeProperty);
			return query.ToList();

		}

		public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			if (filter != null)
				query.Where(filter);
			if (includeProperties != null)
				foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
					query.Include(includeProperty);
			return query.FirstOrDefault();
		}

		public void Remove(int id)
		{
			var removeById =  dbSet.Find(id);
			dbSet.Remove(removeById);
		}

		public void Remove(Guid id)
		{
			var removeByGuid = dbSet.Find(id);
			dbSet.Remove(removeByGuid);
		}

		public void Remove(string id)
		{
			var removeByString = dbSet.Find(id);
			dbSet.Remove(removeByString);
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}
	}
}
