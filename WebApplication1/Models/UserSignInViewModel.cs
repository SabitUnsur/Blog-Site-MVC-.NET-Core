using Microsoft.Build.Framework;


namespace DailyBlogUI.Models
{
    public class UserSignInViewModel
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
