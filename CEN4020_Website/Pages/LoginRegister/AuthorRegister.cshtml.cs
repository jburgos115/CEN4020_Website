using CEN4020_Website.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.ListOfAuth
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        public Model.Author Author { get; set; }

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
                await _db.Author.AddAsync(Author);
                await _db.SaveChangesAsync();
                TempData["success"] = "Registration was Successful";
                return RedirectToPage("/LoginRegister/Login");
            }

            return Page();
        }
    }
}
