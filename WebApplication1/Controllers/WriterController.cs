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


    }
}
