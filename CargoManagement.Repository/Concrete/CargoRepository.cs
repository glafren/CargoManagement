using CargoManagement.Data;
using CargoManagement.Model;
using CargoManagement.Repository.Abstract;
using CargoManagement.Repository.Shared.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagement.Repository.Concrete
{
	public class CargoRepository : Repository<Cargo>, ICargoRepository
	{
		private readonly ApplicationDbContext _db;

		public CargoRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public Cargo GetCargoInfo(string trackingNumber)
		{
			return _db.Cargos.Include(x => x.Status).Include(x => x.Branch).FirstOrDefault(x=>x.TrackingNumber == trackingNumber);
		}
	}
}
