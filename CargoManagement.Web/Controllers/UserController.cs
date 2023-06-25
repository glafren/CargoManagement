using CargoManagement.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CargoManagement.Web.Controllers
{
	public class UserController : Controller
	{
		private readonly IUnitOfWork unitOfWork;

		public UserController(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			return View();
		}
		
		public IActionResult GetAll(){
			return Json(new { data = unitOfWork.Users.GetAll() });
		}

		public IActionResult Remove(Guid id){
			unitOfWork.Users.Remove(id);
			unitOfWork.Save();
			return Ok();
		}
	}
}
