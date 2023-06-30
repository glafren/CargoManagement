using CargoManagement.Model;
using CargoManagement.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
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

		[Authorize]
		[HttpPost]
		public IActionResult Create(Status status)
		{
			if (status != null)
			{
				unitOfWork.Statuses.Add(status);
				unitOfWork.Save();
				return Ok();
			}
			else
				return BadRequest();
		}

		[Authorize]
		[HttpPost]
		public IActionResult Update(Status status)
		{
			Status asil = unitOfWork.Statuses.GetFirstOrDefault(x => x.Id == status.Id);
			asil.Name = status.Name;
			unitOfWork.Statuses.Update(asil);
			unitOfWork.Save();
			return Ok();
		}

		public IActionResult GetById(Guid id)
		{
			return Json(unitOfWork.Statuses.GetById(id));
		}
	}
}
