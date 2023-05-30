using BusinessLayer.Concrete;
using DailyBlogUI.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DailyBlogUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        Context db = new Context();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetWriterByID (int writerID) 
        {
            var findWriter = db.Writers.Select(x => x.WriterID == writerID).FirstOrDefault();
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }

        public IActionResult WriterList()
        {
             writerlist = db.Writers
             .Select(c => new WriterClass
             {
                 Name = c.WriterName,
                 Id = c.WriterID,
             })
             .ToList();

            var jsonWriters = JsonConvert.SerializeObject(writerlist);
            return Json(jsonWriters);
        }

        public IActionResult DeleteWriter(int id)
        {
            var writerToDelete = writerlist.FirstOrDefault(x => x.Id == id);
            writerlist.Remove(writerToDelete);
            return Json(writerToDelete);
        }


        [HttpPost]
        public IActionResult AddWriter(WriterClass writer)
        {
            writerlist.Add(writer);
            var jsonWriters = JsonConvert.SerializeObject(writerlist);
            return Json(jsonWriters);
        }


        public IActionResult UpdateWriter(WriterClass writer)
        {
            var writerToUpdate = writerlist.FirstOrDefault(x => x.Id == writer.Id);
            writerToUpdate.Name=writer.Name;
            var jsonWriters = JsonConvert.SerializeObject(writer);
            return Json(jsonWriters);
        }



        public static List<WriterClass> writerlist = new List<WriterClass>();

    }
}
