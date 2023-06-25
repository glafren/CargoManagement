using CargoManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagement.Repository.Shared.Abstract
{
	public interface IRepository<T> where T : BaseModel
	{
		IQueryable<T> GetAll();
		IQueryable<T> GetAll(Expression<Func<T, bool>> filter);

		void Add(T entity);
		void Update(T entity);
		void Remove(Guid id);

		T GetById(Guid id);

		void AddRange(IEnumerable<T> entities);
		void UpdateRange(IEnumerable<T> entities);
		void RemoveRange(IEnumerable<T> entities);

		T GetFirstOrDefault(Expression<Func<T, bool>> filter);
	}
}
