using CargoManagement.Data;
using CargoManagement.Model;
using CargoManagement.Repository.Shared.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagement.Repository.Shared.Concrete
{
	public class Repository<T> : IRepository<T> where T : BaseModel
	{
		private readonly ApplicationDbContext _db;
		internal DbSet<T> dbSet;
		public Repository(ApplicationDbContext db)
		{
			_db = db;
			dbSet = db.Set<T>();
		}

		
		public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public void AddRange(IEnumerable<T> entities)
		{
			dbSet.AddRange(entities);
		}

		public IQueryable<T> GetAll()
		{
			return dbSet.Where(x => x.isDeleted == false);
		}

		public IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
		{
			return GetAll().Where(filter);
		}

		public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
		{
			return dbSet.Where(t => t.isDeleted == false).AsNoTracking().FirstOrDefault(filter);
		}

		public void Remove(Guid id)
		{
			T Entity = GetFirstOrDefault(t => t.Id == id);
			Entity.isDeleted = true;
			dbSet.Update(Entity);
		}

		public virtual T GetById(Guid id)
		{
			return dbSet.Find(id);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			foreach (T item in entities)
			{
				item.isDeleted = true;
				item.DateModified = DateTime.Now;
			}
			dbSet.UpdateRange(entities);
		}

		public void Update(T entity)
		{
			entity.DateModified = DateTime.Now;
			dbSet.Update(entity);
		}

		public void UpdateRange(IEnumerable<T> entities)
		{
			foreach (T item in entities)
			{
				item.DateModified = DateTime.Now;
			}
			dbSet.UpdateRange(entities);
		}
	}
}
