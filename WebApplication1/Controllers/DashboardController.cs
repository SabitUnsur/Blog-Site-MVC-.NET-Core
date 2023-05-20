using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            BlogManager blogManager = new BlogManager(new EfBlogRepository());
            CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());

            ViewBag.TotalBlogCount=blogManager.GetListAll().Count();
            ViewBag.WriterBlogCount=blogManager.GetBlogListByWriter(1).Count();
            ViewBag.TotalCategory = categoryManager.GetListAll().Count();

            return View();
        }
    }
}
