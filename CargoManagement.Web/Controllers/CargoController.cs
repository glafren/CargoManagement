using CargoManagement.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;

namespace CargoManagement.Web.Controllers
{
	public class CargoController : Controller
	{
		private readonly IUnitOfWork unitOfWork;

		public CargoController(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult GetAll()
		{
			return Json(new { data = unitOfWork.Cargos.GetAll() });
		}
	}
}
