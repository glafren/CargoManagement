using CargoManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagement.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<AuthorizationRole> AuthorizationRoles { get; set; }
		public virtual DbSet<Cargo> Cargos { get; set; }
		public virtual DbSet<Branch> Branches { get; set; }
	}
}
