using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.LoginRegister
{
    //Allows the Author to reset their password if correctly inputted reset code
    [BindProperties]
    public class ResetPasswordAuthorModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Author Author { get; set; }

        public ResetPasswordAuthorModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Author = _db.Author.Find(TempData["Password"]);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Author.Update(Author);
                await _db.SaveChangesAsync();
                TempData["success"] = "Password Successfully Reset";
                return Page();
            }
            return Page();

        }
    }
}
