using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CEN4020_Website.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginInfo Login { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {

        }
    }

    public class LoginInfo
    {
        [Required]
        [Display(Name = "User Name")]
        public string Username { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
