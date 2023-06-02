using System.ComponentModel.DataAnnotations;

namespace DailyBlogUI.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name="Name Surname")]
        [Required(ErrorMessage = "Please type your Name and Surname")]
        public string nameSurname { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please type your password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage ="Passwords don't match! ")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail Adress")]
        [Required(ErrorMessage = "Please type your email")]
        public string Mail { get; set; }


        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please type your username")]
        public string UserName { get; set; }


    }
}
