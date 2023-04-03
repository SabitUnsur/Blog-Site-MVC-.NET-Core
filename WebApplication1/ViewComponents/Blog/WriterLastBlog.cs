using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewComponents.Blog
{
	public class WriterLastBlog:ViewComponent
	{
		BlogManager _blogManager = new BlogManager(new EfBlogRepository());

		public IViewComponentResult Invoke()
		{
			var values = _blogManager.GetBlogListByWriter(1);
			return View(values);
		}

	}
}
