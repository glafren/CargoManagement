using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagement.Model
{
	public class User : BaseModel
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public Guid AuthorizationRoleId { get; set; }
		public virtual AuthorizationRole AuthorizationRole { get; set; }
	}
}
