using DailyBlogUI.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DailyBlogUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        Context db = new Context();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = db.Categories
             .Select(c => new CategoryClass
             {
                 categoryname = c.CategoryName,
                 categorycount = c.CategoryName.Count(),
             })
             .ToList();

            return Json( new { jsonlist = list });
        }

    }
}
