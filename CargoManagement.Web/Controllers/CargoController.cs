using CargoManagement.Model;
using CargoManagement.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

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

		[Authorize]
		public IActionResult Entry()
		{
			return View();
		}

		[Authorize]
		public IActionResult Status()
		{
			return View();
		}

		[Authorize(Roles ="Admin, Teslimat")]
		[HttpPost]
		public IActionResult ChangeStatus(Cargo cargoState)
		{
			Cargo asil = unitOfWork.Cargos.GetFirstOrDefault(x => x.Id == cargoState.Id);
			asil.StatusId = cargoState.StatusId;
			unitOfWork.Cargos.Update(asil);
			unitOfWork.Save();
			return Ok();
		}
	}
}
