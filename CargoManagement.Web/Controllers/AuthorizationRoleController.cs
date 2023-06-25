using CargoManagement.Repository.Shared.Abstract;
using CargoManagement.Repository.Shared.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CargoManagement.Web.Controllers
{
	public class AuthorizationRoleController : Controller
	{
		private readonly IUnitOfWork unitOfWork;

		public AuthorizationRoleController(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult GetAll()
		{
			return Json(new { data = unitOfWork.AuthorizationRoles.GetAll() });
		}

		[HttpPost]
		public IActionResult Remove(Guid id)
		{
			unitOfWork.AuthorizationRoles.Remove(id);
			unitOfWork.Save();
			return Ok();
		}
	}
}
