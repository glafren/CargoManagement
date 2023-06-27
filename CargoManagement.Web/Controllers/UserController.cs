using CargoManagement.Model;
using CargoManagement.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace CargoManagement.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(new { data = unitOfWork.Users.GetAll() });
        }

        [HttpPost]
        public IActionResult Remove(Guid id)
        {
            unitOfWork.Users.Remove(id);
            unitOfWork.Save();
            return Ok();
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout(User user)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (user != null)
            {
                User usr = unitOfWork.Users.GetFirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password && u.isActive == true && u.isDeleted == false);
                if (usr != null)
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, usr.Name));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, usr.Id.ToString()));

                    if (usr.AuthorizationRoleId.ToString() == "1404b528-74f0-413a-963d-909315bbfd21")
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    }
                    else if (usr.AuthorizationRoleId.ToString() == "dabe2585-1ca7-4224-9f36-d696283b6167")
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "Teslimat"));
                    }
                    else if (usr.AuthorizationRoleId.ToString() == "32d82003-06a0-4b04-a585-c9ba20279c6a")
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "Vezne"));
                    }

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }

            else
            { 
                return View(); 
            }
        }

    }
}
