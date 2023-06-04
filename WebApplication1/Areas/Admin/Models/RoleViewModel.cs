using System.ComponentModel.DataAnnotations;

namespace DailyBlogUI.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Type a role name")]
        public string RoleName { get; set; }
    }
}
