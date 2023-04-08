using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ViewComponents.Blog
{
    public class BlogLast3Post:ViewComponent
    {
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            var values = _blogManager.GetLatestBlog();
            return View(values);
        }
    }
}
