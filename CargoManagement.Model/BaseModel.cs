using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagement.Model
{
	public class BaseModel
	{
		public Guid Id { get; set; } = new Guid();
		public string? Name { get; set; }
		public DateTime? DateCreated { get; set; } = DateTime.Now;
		public DateTime? DateModified { get; set; }
		public bool? isActive { get; set;} = true;
		public bool? isDeleted { get; set; } = false;	
	}
}
