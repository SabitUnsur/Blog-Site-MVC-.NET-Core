using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class DashboardController : Controller
    {
        private readonly Context _db;

        public DashboardController(Context db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            BlogManager blogManager = new BlogManager(new EfBlogRepository());
            CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());

            var userName = User.Identity.Name;
            var userMail = _db.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID=_db.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            ViewBag.TotalBlogCount=blogManager.GetListAll().Count();
            ViewBag.WriterBlogCount=blogManager.GetBlogListByWriter(writerID).Count();
            ViewBag.TotalCategory = categoryManager.GetListAll().Count();

            return View();
        }
    }
}
