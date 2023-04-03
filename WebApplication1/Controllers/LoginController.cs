using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
