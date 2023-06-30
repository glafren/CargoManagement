using CargoManagement.Data;
using CargoManagement.Model;
using CargoManagement.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagement.Repository.Shared.Concrete
{
	public class UnitOfWork : IUnitOfWork
	{
		public IRepository<User> Users { get; private set; }

		public IRepository<Cargo> Cargos {get; private set;}

		public IRepository<Branch> Branches {get; private set;}

		public IRepository<AuthorizationRole> AuthorizationRoles {get; private set;}
		public IRepository<Status> Statuses { get; private set;}

		private readonly ApplicationDbContext _db;

		public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
			Users = new Repository<User>(db);
			Cargos = new Repository<Cargo>(db);
			Branches = new Repository<Branch>(db);
			AuthorizationRoles = new Repository<AuthorizationRole>(db);
			Statuses = new Repository<Status>(db);
		}

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
