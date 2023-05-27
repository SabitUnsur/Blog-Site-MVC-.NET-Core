using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DailyBlogUI.Areas.Admin.ViewComponents.Statistics
{
    public class Statistic2:ViewComponent
    {
        Context db = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.lastBlog = db.Blogs.OrderByDescending(x=>x.BlogID).Select(x=>x.BlogTitle).Take(1).FirstOrDefault();
            ViewBag.commentTotalCount = db.Comments.Count();
            return View();
        }
    }
}
