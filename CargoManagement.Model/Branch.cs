using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagement.Model
{
	public class Branch:BaseModel
	{
		public ICollection<Cargo> Cargos { get; set; }
	}
}
