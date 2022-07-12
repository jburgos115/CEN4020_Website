using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.LoginRegister
{
    [BindProperties]
    public class UserSettingReviewerModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Reviewer Reviewer { get; set; }

        public UserSettingReviewerModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Reviewer = _db.Reviewer.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Reviewer.Update(Reviewer);
                await _db.SaveChangesAsync();
                TempData["success"] = "Profile Edited Successfully";
                return Page();
            }
            return Page();

        }
    }
}
