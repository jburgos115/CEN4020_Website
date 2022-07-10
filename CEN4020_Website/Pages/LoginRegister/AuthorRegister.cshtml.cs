using CEN4020_Website.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.ListOfAuth
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        [BindProperty]
        public Model.Author Author { get; set; }
        public RegisterModel(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var userAuthor = new IdentityUser()
                {
                    

                };

                var result = await userManager.CreateAsync(userAuthor, Author.Password);
                if(result.Succeeded)
                {
                    return RedirectToPage("/LoginRegister/Login");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("AuthorRegister", error.Description);
                    }

                    return Page();
                }
                
            }

            return Page();
        }
    }
}
