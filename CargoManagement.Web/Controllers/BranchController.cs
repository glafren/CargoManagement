using CargoManagement.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CargoManagement.Web.Controllers
{
	public class BranchController : Controller
	{
		private readonly IUnitOfWork unitOfWork;

		public BranchController(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult GetAll()
		{
			return Json(new { data = unitOfWork.Branches.GetAll() });
		}

		[HttpPost]
		public IActionResult Remove(Guid id)
		{
			unitOfWork.Branches.Remove(id);
			unitOfWork.Save();
			return Ok();
		}
	}
}
