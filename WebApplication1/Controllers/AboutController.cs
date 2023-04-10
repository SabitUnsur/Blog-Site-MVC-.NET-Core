using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
	public class AboutController : Controller
	{
		AboutManager _aboutManager = new AboutManager(new EfAboutRepository());
		public IActionResult Index()
		{
            var values = _aboutManager.GetListAll();
            return View(values);
		}

		public PartialViewResult SocialMediaAbout()
		{

			return PartialView();
		}
	}
}
