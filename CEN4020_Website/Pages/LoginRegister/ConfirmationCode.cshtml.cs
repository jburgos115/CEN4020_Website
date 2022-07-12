using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CEN4020_Website.Pages.LoginRegister
{
    //Checks that the User is who they say they are by checking the sent confirmation code
    public class ConfirmationCodeModel : PageModel
    {
        [BindProperty]
        public ConfirmationCodeInfo ConfirmationCodeInfo { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            string confCode = "98";
            //If Author sends them to Author Page
            if(ConfirmationCodeInfo.Code == confCode && TempData["Author"].ToString() == "true")
            {
                return RedirectToPage("/LoginRegister/ResetPasswordAuthor");
            }
            //If Author sends them to Reviwer Page
            else if (ConfirmationCodeInfo.Code == confCode && TempData["Reviewer"].ToString() == "true")
            {
                return RedirectToPage("/LoginRegister/ResetPasswordReviewer");
            }

            ModelState.AddModelError("", "Incorrect Confirmation Code");
            return Page();
        }
    }

    public class ConfirmationCodeInfo
    {
        [Required]
        public string Code { get; set; }
    }
}
