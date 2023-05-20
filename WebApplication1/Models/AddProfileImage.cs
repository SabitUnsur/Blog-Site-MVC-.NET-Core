using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class AddProfileImage
    {
        //Entityde değişiklik yapılmaması adına buraya tasarlandı.
        [Key] public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public IFormFile WriterImage { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }

        [CompareAttribute("WriterPassword",ErrorMessage ="Yanlis veya hatali")] 
        public string ConfirmWriterPassword { get; set; }
        public bool WriterStatus { get; set; }
    }
}
