using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        NewsLetterManager _newsLetterManager=new NewsLetterManager(new EfNewsLetterRepository());

        [HttpGet]
        public IActionResult SubscribeMail()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult  SubscribeMail(NewsLetter request)
        {
            if((_newsLetterManager.IsEmailSubscribed(request)) == true)
            {
                request.MailStatus = true;
                _newsLetterManager.AddNewsLetter(request);
            }
            //Response.Redirect("/Blog/Index");

            return PartialView();
        }
  
    }
}
