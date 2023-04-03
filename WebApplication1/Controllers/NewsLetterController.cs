using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class NewsLetterController : Controller
    {
        NewsLetterManager _newsLetterManager=new NewsLetterManager(new EfNewsLetterRepository());

        [HttpGet]
        public IActionResult SubscribeMail()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter request)
        {
            request.MailStatus = true;
            _newsLetterManager.AddNewsLetter(request);
            Response.Redirect("/Blog/Index");
            return PartialView();
        }
    }
}
