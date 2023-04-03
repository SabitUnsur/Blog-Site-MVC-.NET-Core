using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class CommentController : Controller
    {
        CommentManager _commentManager=new CommentManager(new EfCommentRepository());
        
        [HttpGet]        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult PartialAddComment(Comment comment)
        {
            comment.CommentStatus = true;
            comment.BlogID = 3;
            _commentManager.AddComment(comment);
            return PartialView();
        }
    }
}
