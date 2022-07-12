using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.Reviewers
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Reviewer Reviewer { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Reviewer = _db.Reviewer.Find(id);
        }

        public async Task<IActionResult> OnPost(Model.Reviewer reviewer)
        {
            if (ModelState.IsValid)
            {
                _db.Reviewer.Update(reviewer);
                await _db.SaveChangesAsync();
                TempData["success"] = "Reviewer Edited Successfully";
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}
