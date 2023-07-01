using CargoManagement.Model;
using CargoManagement.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
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

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public IActionResult Create(Branch branch)
		{
			if (branch.Name != null)
			{
				unitOfWork.Branches.Add(branch);
				unitOfWork.Save();
				return Ok();
			}
			else
				return BadRequest();
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public IActionResult Update(Branch branch)
		{
			if (branch.Name != null)
			{
				Branch asil = unitOfWork.Branches.GetFirstOrDefault(x => x.Id == branch.Id);
				asil.Name = branch.Name;
				unitOfWork.Branches.Update(asil);
				unitOfWork.Save();
				return Ok();
			}
			else { return BadRequest(); }

		}

		[HttpPost]
		public IActionResult GetById(Guid id)
		{
			return Json(unitOfWork.Branches.GetById(id));
		}
	}
}
