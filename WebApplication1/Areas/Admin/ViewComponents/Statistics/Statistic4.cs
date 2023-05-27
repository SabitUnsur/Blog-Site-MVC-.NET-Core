using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DailyBlogUI.Areas.Admin.ViewComponents.Statistics
{
    public class Statistic4:ViewComponent
    {
        Context db = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.Admins = db.Admins.Where(x=>x.AdminID==2).Select(x=>x.Name).FirstOrDefault();
            ViewBag.AdminImage = db.Admins.Where(x=>x.AdminID==2).Select(x=>x.ImageURL).FirstOrDefault();
            ViewBag.AdminDescription = db.Admins.Where(x=>x.AdminID==2).Select(x=>x.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
