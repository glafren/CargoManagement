using CargoManagement.Model;
using CargoManagement.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

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
			return Json(new { data = unitOfWork.Cargos.GetAll().Include(c => c.Branch).Include(c => c.Status) });
		}

		[HttpPost]
		public IActionResult GetById(Guid id)
		{
			return Json(unitOfWork.Cargos.GetById(id));
		}

		[HttpPost]
		public IActionResult GetCargo(Guid id)
		{
			return Json(unitOfWork.Cargos.GetAll(x => x.Id == id).Include(c => c.Branch).Include(c => c.Status));
		}

		public IActionResult Entry()
		{
			return View();
		}

		
	}
}
