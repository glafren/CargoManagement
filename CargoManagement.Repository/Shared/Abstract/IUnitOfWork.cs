﻿using CargoManagement.Model;
using CargoManagement.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagement.Repository.Shared.Abstract
{
	public interface IUnitOfWork
	{
		IRepository<User> Users { get; }
		ICargoRepository Cargos { get; }
		IRepository<Branch> Branches { get; }
		IRepository<AuthorizationRole> AuthorizationRoles { get; }
		IRepository<Status> Statuses { get; }

		void Save();
	}
}
