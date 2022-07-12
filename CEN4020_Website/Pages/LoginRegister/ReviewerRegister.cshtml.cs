using CEN4020_Website.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.Reviewers
{
    //Allows a Reviewer to Register
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        public Model.Reviewer Reviewer { get; set; }

        public RegisterModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Reviewer.AddAsync(Reviewer);
                await _db.SaveChangesAsync();
                TempData["success"] = "Registration was Successful";
                return RedirectToPage("/LoginRegister/Login");
            }

            return Page();
        }
    }
}
