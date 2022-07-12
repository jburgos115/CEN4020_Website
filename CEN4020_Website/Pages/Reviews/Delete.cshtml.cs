using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.Reviews
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Review Review { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Review = _db.Review.Find(id);
        }

        public async Task<IActionResult> OnPost(Model.Review review)
        {
            var reviewerFromDb = _db.Review.Find(review.ReviewID);
            if(reviewerFromDb != null)
            {
                _db.Review.Remove(reviewerFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Review Deleted Successfully";
                return RedirectToPage("Index");
            }
            
            return Page();

        }
    }
}
