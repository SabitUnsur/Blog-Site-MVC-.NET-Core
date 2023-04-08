using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    
    public class WriterController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }


    }
}
