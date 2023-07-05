using CargoManagement.Model;
using CargoManagement.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagement.Repository.Abstract
{
	public interface ICargoRepository: IRepository<Cargo>
	{
		Cargo GetCargoInfo(string trackingNumber);
	}
}
