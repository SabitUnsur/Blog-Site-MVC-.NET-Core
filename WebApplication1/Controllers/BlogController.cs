﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
	public class BlogController : Controller
	{
		BlogManager blogManager=new BlogManager(new EfBlogRepository());
		public IActionResult Index()
		{
			var values = blogManager.GetBlogListWithCategory();
			return View(values);
		}

        public IActionResult BlogReadAll(int BlogId)
		{
			var values=blogManager.GetBlogByID(BlogId);
			return View(values);
		}
    }
}
