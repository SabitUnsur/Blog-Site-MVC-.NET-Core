using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Controllers
{
    public class MessageController : Controller
    {
        
        Message2Manager message2Manager = new Message2Manager(new EfMessage2Repository());

        [AllowAnonymous]
        public IActionResult InBox()
        {
            int receiverID = 3;
            var values = message2Manager.GetInboxListByWriter(receiverID);
            return View(values);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult MessageDetails(int messageID)
        {
          var values= message2Manager.GetByID(messageID);
            return View(values);
        }

    }
}
