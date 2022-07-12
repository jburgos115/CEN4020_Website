using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.LoginRegister
{
    //Allows the Reviewer to reset their password if correctly inputted reset code
    [BindProperties]
    public class ResetPasswordReviewerModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Reviewer Reviewer { get; set; }

        public ResetPasswordReviewerModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Reviewer = _db.Reviewer.Find(TempData["Password"]);
        }

        public async Task<IActionResult> OnPost(Model.Reviewer reviewer)
        {
            if (ModelState.IsValid)
            {
                _db.Reviewer.Update(reviewer);
                await _db.SaveChangesAsync();
                TempData["success"] = "Password Successfully Reset";
                return Page();
            }
            return Page();

        }
    }
}
