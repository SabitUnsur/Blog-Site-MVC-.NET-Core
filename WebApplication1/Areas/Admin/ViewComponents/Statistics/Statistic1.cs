using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace DailyBlogUI.Areas.Admin.ViewComponents.Statistics
{
    public class Statistic1:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        Context db= new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.blogTotalCount = blogManager.GetListAll().Count();
            ViewBag.contactCount= db.Contacts.Count();
            ViewBag.commentTotalCount= db.Comments.Count();

            /*string api = "3cf2f67d5459c24564acff9e35e3c371";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&unitsmetric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.temperature = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;*/


            return View();
        }
    }
}
