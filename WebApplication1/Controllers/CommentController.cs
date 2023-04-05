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
            // comment.CommentDate=DateTime.Parse(DateTime.UtcNow.ToString());

            //Bu kod, şu anda geçerli olan UTC zamanını temsil eden bir DateTime nesnesi oluşturur ve DateTimeKind özelliğini Utc olarak ayarlar.
            //Bu DateTime nesnesi, bir işlemin öncelikle UTC zaman diliminde çalışması gereken durumlarda kullanılabilir.
            //DateTimeKind, .NET Framework'teki DateTime yapısının bir özelliğidir. DateTime yapısı, belirli bir tarih ve saat değerini tutar,
            //ancak bu değerin kaynağı belirtilmemişse (yerel saatten başka bir yerden mi alındı, zaman dilimi neydi, vs.) bu değerin doğru bir şekilde işlenmesi zorlaşabilir.
            //DateTimeKind, DateTime değerinin kaynağını belirtmek için kullanılır.
            //Bu sayede DateTime değerleri yerel saate dönüştürülebilir ya da diğer zaman dilimlerine göre ayarlanabilir.
            //Bu, farklı bilgisayarlar arasında yapılan veri paylaşımı veya veritabanı işlemlerinde çok yararlıdır.

            comment.CommentDate = DateTime.SpecifyKind(DateTime.Parse(DateTime.UtcNow.ToString()), DateTimeKind.Utc);

            comment.CommentStatus = true;
            comment.BlogID = 3;
            _commentManager.AddComment(comment);
            return PartialView();

            //SpecifyKind metodu belirtilen bir DateTime değerinin tarih/zaman bilgisini belirtilen DateTimeKind'e göre ayarlar. Bu metodun kullanımı,
            //özellikle farklı zaman dilimleri arasında veri aktarımında tarih/zaman bilgisinin tutarlılığını sağlamak için önemlidir.
            //Örneğin, bir web uygulaması,
            //sunucu zaman diliminden farklı bir zaman dilimindeki bir kullanıcıya tarih/zaman verisi gönderirken SpecifyKind metodu kullanılabilir
            //ve böylece tarih/zaman bilgisinin doğru zaman dilimine göre ayarlanması sağlanabilir.
            //C# Parse metodu, bir dizeyi veya başka bir veri tipini, belirli bir formata göre çözümlemek ve yorumlamak için kullanılır.
            //Örneğin, bir dizeyi sayıya veya tarihe dönüştürmek için Parse metodu kullanılabilir
        }
    }
}
