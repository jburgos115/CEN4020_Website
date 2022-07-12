using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.Reviewers
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Reviewer Reviewer { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Reviewer = _db.Reviewer.Find(id);
        }

        public async Task<IActionResult> OnPost(Model.Reviewer reviewer)
        {
            var reviewerFromDb = _db.Reviewer.Find(reviewer.ReviewerID);
            if(reviewerFromDb != null)
            {
                _db.Reviewer.Remove(reviewerFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Reviewer Deleted Successfully";
                return RedirectToPage("Index");
            }
            
            return Page();

        }
    }
}
