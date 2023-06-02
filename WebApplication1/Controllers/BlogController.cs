using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Controllers
{

    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        Context db = new Context();

        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }

        [AllowAnonymous]
        public IActionResult BlogReadAll(int BlogId)
        {
            var values = blogManager.GetBlogByID(BlogId);
            ViewBag.blogID = BlogId;
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var userMail = User.Identity.Name;
            var writerID = db.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = blogManager.GetListWithCategoryByWriter(writerID);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
          
            List<SelectListItem> categoryvalues = (from x in categoryManager.GetListAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()

                                                   }).ToList();

            ViewBag.CategoryValues = categoryvalues;

            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            var userMail = User.Identity.Name;
            var writerID = db.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            BlogValidator validation = new BlogValidator();
            ValidationResult validationResult = validation.Validate(blog);

            if (validationResult.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.SpecifyKind(DateTime.Parse(DateTime.UtcNow.ToString()), DateTimeKind.Utc);
                blog.WriterID = writerID;
                blogManager.Add(blog);

                return RedirectToAction("BlogListByWriter", "Blog");
            }

            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteBlog(int blogID)
        {
            var blogToDelete = blogManager.GetByID(blogID);
            blogManager.Delete(blogToDelete);
            return RedirectToAction("BlogListByWriter");

        }


        [HttpGet]
        public IActionResult EditBlog(int blogID)
        { 
            var blogValues=blogManager.GetByID(blogID);

            List<SelectListItem> categoryvalues = (from x in categoryManager.GetListAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()

                                                   }).ToList();

            ViewBag.CategoryValues = categoryvalues;

            return View(blogValues); 
        }


        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            var userMail = User.Identity.Name;
            var writerID = db.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            blog.WriterID= writerID;
            blogManager.Update(blog);
            return RedirectToAction("BlogListByWriter");
        }



    }
}
