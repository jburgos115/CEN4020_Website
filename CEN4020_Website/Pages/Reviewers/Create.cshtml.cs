using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.Reviewers
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Reviewer Reviewer { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(Model.Reviewer reviewer)
        {
            if (ModelState.IsValid)
            {
                await _db.Reviewer.AddAsync(reviewer);
                await _db.SaveChangesAsync();
                TempData["success"] = "New Reviewer Created Successfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
