using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        Context db = new Context();

        private readonly UserManager<AppUser> _userManager;

		public WriterAboutOnDashboard(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public IViewComponentResult Invoke()
        {
           
            var userName = User.Identity.Name;
            ViewBag.User = userName;

            var userMail = db.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();

            var writerID = db.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = writerManager.GetWriterByID(writerID);
            return View(values);
        }
    

    }
}
