using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagement.Model
{
	public class Cargo: BaseModel
	{
		public string? TrackingNumber { get; set; }
		public string? Status { get; set; }
		public DateTime? ExitDate { get; set; } 
		public string? DeliveryAddress { get; set; }
		public string? SenderName { get; set; }
		public string? SenderSurname { get; set; }
		public string? SenderPhone { get; set; }
		public string? SenderEmail { get; set; }
		public string? RecipientName { get; set; }
		public string? RecipientSurname { get; set; }
		public string? RecipientPhone { get; set; }
		public string? RecipientEmail { get; set; }
		public Guid? BranchId { get; set; }
		public virtual Branch Branch { get; set; }
	}
}
