using CargoManagement.Model;
using CargoManagement.Repository.Shared.Abstract;
using CargoManagement.Repository.Shared.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CargoManagement.Web.Controllers
{
	[Authorize]
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

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public IActionResult Remove(Guid id)
		{
			unitOfWork.AuthorizationRoles.Remove(id);
			unitOfWork.Save();
			return Ok();
		}

		[HttpPost]
		public IActionResult GetById(Guid id)
		{
			return Json(unitOfWork.AuthorizationRoles.GetById(id));
		}

		[Authorize(Roles ="Admin")]
		[HttpPost]
		public IActionResult Update(AuthorizationRole role)
		{
			AuthorizationRole asil = unitOfWork.AuthorizationRoles.GetFirstOrDefault(x => x.Id == role.Id);
			if (asil != null)
			{
				asil.Name = role.Name;
				unitOfWork.AuthorizationRoles.Update(asil);
				unitOfWork.Save();
				return Ok();
			}
			else
				return BadRequest();
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public IActionResult Create (AuthorizationRole role)
		{
			if(role.Name != null)
			{
				unitOfWork.AuthorizationRoles.Add(role);
				unitOfWork.Save();
				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}
	}
}
