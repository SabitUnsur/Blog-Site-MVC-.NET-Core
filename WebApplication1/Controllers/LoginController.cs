using DailyBlogUI.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel userToLogin )
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userToLogin.userName, userToLogin.Password, false, true);
                if (result.Succeeded)
                {
					return RedirectToAction("Index", "Dashboard");
				}
                else
                {
                    return RedirectToAction("Index", "Login");
                }

			}
                               
            return View();
        }


        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        //[HttpPost]
        //[AllowAnonymous]
        /*public async Task<IActionResult> Index(Writer writer)
        {
            Context context = new Context();
            var dataValue = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail &&
            x.WriterPassword == writer.WriterPassword);
            if (dataValue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,writer.WriterMail)
                };

                var userIdentity = new ClaimsIdentity(claims, "User");

                ClaimsPrincipal userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View();
            }
        }*/
    }
}

