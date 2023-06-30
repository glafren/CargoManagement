using CargoManagement.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CargoManagement.Web.Controllers
{
	public class StatusController : Controller
	{
		private readonly IUnitOfWork unitOfWork;

		public StatusController(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult GetAll()
		{
			return Json(new { data = unitOfWork.Statuses.GetAll() });
		}

		[HttpPost]
		public IActionResult Remove(Guid id)
		{
			unitOfWork.Statuses.Remove(id);
			unitOfWork.Save();
			return Ok();
		}
	}
}
