using BusinessLayer.Abstract;
using DailyBlogUI.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DailyBlogUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        Context db=new Context();

        public IActionResult ExportDynamicExcelBlogList()
        {
            var blogs = db.Blogs.ToList();
            var stream = new MemoryStream(); // bellekteki geçici veri akışı
            using (var package = new OfficeOpenXml.ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Blogs"); // Excel sayfası oluşturma

                // Kolonları başlık olarak ekleme
                worksheet.Cells[1, 1].Value = "Blog ID";
                worksheet.Cells[1, 5].Value = "Title";
                worksheet.Cells[1, 9].Value = "Content";

                // Verileri satır olarak ekleme
                int row = 2;
                foreach (var blog in blogs)
                {
                    worksheet.Cells[row, 1].Value = blog.BlogID;
                    worksheet.Cells[row, 5].Value = blog.BlogTitle;
                    worksheet.Cells[row, 9].Value = blog.BlogContent;
                    row++;
                }

                package.Save();
            }

            // Dosya adı oluşturma
            string fileName = "blogs_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        public IActionResult BlogTiteListExcel()
        {
            return View();
        }
    }
}
