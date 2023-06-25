using CargoManagement.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagement.Repository.Shared.Concrete
{
	public class Repository<T> :IRepository<T> where T : class
	{
	}
}
