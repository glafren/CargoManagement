using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagement.Model
{
	public class Status : BaseModel
	{
		public virtual Cargo Cargo { get; set; }
	}
}
