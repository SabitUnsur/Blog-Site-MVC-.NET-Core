using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {   
        CategoryManager categoryManager=new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var values=categoryManager.GetCategoryList();
            return View(values);
        }

    }
}
