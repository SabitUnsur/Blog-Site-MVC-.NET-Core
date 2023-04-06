using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Writer writer)
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

                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }
        }
    }
}

/*[HttpPost]
		[AllowAnonymous]
        public async Task<IActionResult> Index(Writer writer)
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

				var userIdentity=  new ClaimsIdentity(claims,"User");

				ClaimsPrincipal userPrincipal = new ClaimsPrincipal(userIdentity);

				await HttpContext.SignInAsync(userPrincipal);

				return RedirectToAction("Index","Writer");
			}
			else
			{
				return View();
			}

        }*/