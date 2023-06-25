using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagement.Model
{
	public class AuthorizationRole : BaseModel
	{
		public virtual ICollection<User> Users { get; set; }
	}
}
